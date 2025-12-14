using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WpCalendar
{
	public partial class FmMain : Form
	{
		private struct TStartupParam
		{
			public const string
				//None = "",		//廃止
				//Daily = "-daily",	//廃止
				Once = "-once";
		}

		/*	Programへ移動
		//private const string APP_VER = "ver. 1.30";	//2019/11/06	令和対応
		//private const string APP_VER = "ver. 1.40";	//2023/11/14	スタートアップ登録機能を廃止
		*/

		private const string AppSettingFilename = @"wpcalendar.setting";
		private const string AppCalendarFilename = @"wpcalendar.bmp";

		private string appSettingFile;  //データ保存ファイル
		private string appCalendarFile; //カレンダー描画済みの壁紙ファイル

		//オブジェクト
		private SettingData settingData;	//保存データ
		private	SettingManager settingMgr;	//データ管理
		private WindowsWallpaper wallpaper;	//壁紙制御
		private	CalendarRenderer renderer;	//カレンダー描画
		private DayStringOffsetManager dayStrMgr;	//日にち描画の位置調整

		//コンストラクタ
		public FmMain()
		{
			InitializeComponent();
			this.Text = Application.ProductName;
			pnlIcon.BackgroundImage = this.Icon.ToBitmap(); //アイコン画像をBitmapに変換してアプリ内にワンポイントとして描く

			//tab-Layout, tab-Advanced
			Size screenSize = Screen.PrimaryScreen.Bounds.Size;
			var udNumWidthList  = new List<NumericUpDown>
				{ udMonthToMonth, udDayHolizon, udOriginX, udDayCellWidth, udDayStrOffsetX };
			var udNumHeightList = new List<NumericUpDown>
				{ udYMToWeek, udWeekToDay, udDayVertical, udOriginY, udDayCellHeight, udDayStrOffsetY };
			foreach (var udNum in udNumWidthList) { udNum.Maximum = screenSize.Width; udNum.Minimum = -udNum.Maximum; }
			foreach (var udNum in udNumHeightList) { udNum.Maximum = screenSize.Height; udNum.Minimum = -udNum.Maximum; }
			udDayCellWidth.Minimum = udDayCellHeight.Minimum = 0;

			//tab-Format
			lblYearMonthFormat.Text = Label_YearMonthFormat_Text;
			lblYearMonthFormat.Top =
				lblYearMonthFormat.Parent.Height - lblYearMonthFormat.Parent.Padding.Bottom - lblYearMonthFormat.Height;
			int height = lblYearMonthFormat.Height;
			lblYearMonthFormat.AutoSize = false;
			lblYearMonthFormat.Width = lblYearMonthFormat.Parent.Width - lblYearMonthFormat.Left * 2;
			lblYearMonthFormat.Height = height;
		}
		//
		private static readonly string Label_YearMonthFormat_Text =
			@"<記号>
			yyyy:西暦4桁　yy:西暦2桁　jj:和暦
			mmmm:January　mmm:Jan　mm:01～12　m:1～12
			<例>
			mmmm yyyy → January 2048,　yyyy/mm → 2048/01,
			'yy mmm → '48 Jan,　令和jj年 m月 → 令和30年 1月".Replace("\t", "");

		//フォームロード
		private void FmMain_Load(object sender, EventArgs e)
		{
			//オブジェクトを準備する
			settingMgr = new SettingManager();
			wallpaper = new WindowsWallpaper();
			renderer = new CalendarRenderer();
			dayStrMgr = new DayStringOffsetManager();

			//システムから割り当てられた、このアプリ固有のディレクトリを取得する
			/*	説明
			Application.LocalUserAppDataPath ==> "C:\Users\<ユーザー名>\AppData\Local\＜CompanyName＞\＜ProductName＞\＜ProductVersion＞"
			Path.GetDirectoryName(path) ==> pathの親ディレクトリのパスが得られる
			*/
			string appVersionDirectory = Application.LocalUserAppDataPath;
			string appDirectory = Path.GetDirectoryName(appVersionDirectory);
			Directory.Delete(appVersionDirectory);    //バージョン名のディレクトリを削除する
			/*	Debugフォルダをアプリのディレクトリとする↓	*/
			//appDirectory = Path.GetDirectoryName(Application.ExecutablePath);	//debug

			//このアプリ固有のファイル（フルパス）を設定する
			appSettingFile = Path.Combine(appDirectory, AppSettingFilename);
			appCalendarFile = Path.Combine(appDirectory, AppCalendarFilename);

			//設定データを読み込む
			settingData = settingMgr.LoadFromXml(appSettingFile);

			//設定値に基づきコントロールを初期化する
			InitTabLayout();
			InitTabFormat();
			InitTabColorSetting();
			InitTabSpecialDay();
			InitTabAdvanced();

			//引数付きの起動だった場合、カレンダーを描いて終了する
			if (Environment.GetCommandLineArgs().Contains<string>(TStartupParam.Once))
			{
				UpdateCalendar();
				this.Close();
			}
			
			//引数なし、または無関係な引数だった場合、動作を続行する
		}

		//壁紙にカレンダーを描画して変更する
		private void UpdateCalendar()
		{
			//現在システムに設定されている壁紙ファイルのフルパスを取得する
			/*	説明
			appTmpImageFileと比較して何が判断できる？
			・現在の壁紙がこのアプリでカレンダーを描画したファイルならば、パスはappTmpImageFileと一致する。
			・パスがappTmpImageFileと異なるならば、まだこのアプリでカレンダーを描画していないファイルということになる。
				→カレンダーを日々描画するため／カレンダーなしの元の壁紙へ戻すときのため、オリジナル画像のファイルパスは保存しておく必要がある。
			*/
			string currentWpFile = wallpaper.GetImageFile();
			if (currentWpFile != appCalendarFile) { settingData.OriginalImageFile = currentWpFile; }

			//カレンダーの描画先となるベース画像を作成する
			/*	説明
			カレンダーはデスクトップと同じサイズの画像に描画して壁紙に設定する仕様なので、
			小さい画像をタイルパターンで壁紙にしているなどの場合、デスクトップサイズの1枚の画像として準備する必要がある。
			*/
			Bitmap orgBmp = settingMgr.GetOriginalWallpaperImage();
			Bitmap wpBmp = wallpaper.CreateWallpaperBaseImage(orgBmp);

			//画像にカレンダーを描画する
			if (!renderer.Draw(wpBmp, settingData, settingMgr)) { goto FINISH; }

			//カレンダー描画済みの画像をアプリのフォルダに保存し、その保存したファイルを壁紙に指定する
			try { wpBmp.Save(appCalendarFile, ImageFormat.Bmp); }
			catch { goto FINISH; }
			wallpaper.SetImage(appCalendarFile);

		FINISH:
			orgBmp?.Dispose();
			wpBmp?.Dispose();
		}

		//カレンダーを描画する
		private void btnDoDraw_Click(object sender, EventArgs e)
		{
			UpdateCalendar();
		}

		//カレンダーを消去する
		private void btnCaClear_Click(object sender, EventArgs e)
		{
			string imageFile = settingData.OriginalImageFile;
			if (File.Exists(imageFile)) { wallpaper.SetImage(imageFile); }
		}

		//フォームクローズ中
		private void FmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			//タスクスケジューラによる起動（描画するだけ）だった場合、終了処理はない
			//ユーザー操作による起動（設定内容変更の可能性あり）だった場合、データを保存する
			if (Environment.GetCommandLineArgs().Contains<string>(TStartupParam.Once)) { /*処理なし*/ }
			else { settingMgr.SaveToXml(settingData, appSettingFile); }
		}

		//フォームクローズ後
		private void FmMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			//アプリ内にワンポイントとして描いたBitmapの後始末
			pnlIcon.BackgroundImage?.Dispose();
		}

		//バージョン情報
		private void btnAbout_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				//string.Format("壁紙カレンダー {0}\n{1}\n(C)RK Software, 2013-", Application.ProductName, APP_VER),	//2025/12 del
				string.Format("壁紙カレンダー {0}\n{1}\n@jsdiy, 2013-", Application.ProductName, Program.AppVer),	//2025/12 add
				Application.ProductName + " について", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#region TabLayout

		//TabLayoutを初期化する
		private void InitTabLayout()
		{
			Init_ComboBox(cbMonthOrder);
			SetGrpMonthChangeAvailable();

			Init_RadioButton(grpMonthOrder);
			Init_RadioButton(grpMonthChange);
			Init_RadioButton(grpStartWeek);

			Init_NumericUpDown(grpCharGap);
			Init_NumericUpDown(grpLocation);
		}

		//グループボックス内のラジオボタンを初期化する
		//・GroupBox.Tagに、このグループボックスがグループ化しているラジオボタンに対応するSettingDataのプロパティ名が記述されている。
		//・保存データにはRadioButton.Nameが保存されているので、グループ内のラジオボタンでNameが一致したものについてChecked=Trueとする。
		private void Init_RadioButton(GroupBox grp)
		{
			Type t = settingData.GetType();
			PropertyInfo pi = t.GetProperty(grp.Tag as string);
			if (pi == null) { return; }		//Tagにラベルが記述されていない場合は無関係なグループボックスである
			foreach (Control ctrl in grp.Controls)
			{
				RadioButton rbtn = ctrl as RadioButton;
				if (rbtn == null) { continue; }
				try
				{
					object rbVal = Enum.Parse(pi.PropertyType, rbtn.Tag as string);
					rbtn.Checked = ((int)rbVal == (int)pi.GetValue(settingData));
				}
				catch { rbtn.Checked = false; radioButtonInGroupBox_CheckedChanged(rbtn, null); }
				/*
				プロパティのEnum型は複数種類あり特定できないので、PropertyInfo.GetValue()の値(object)をEnum型にキャストして比較はできない。
				よって、Enum型をint値として比較する。
				RadioButton.Tagに記述するのは該当するEnum型メンバー名でも、それと同値の整数でも構わない。
				→Enum.Parse()はどちらでも対応できる。
				*/
			}
		}

		//グループボックス内の数値ボックスを初期化する
		private void Init_NumericUpDown(GroupBox grp)
		{
			Type t = settingData.GetType();
			foreach (Control ctrl in grp.Controls)
			{
				NumericUpDown numUd = ctrl as NumericUpDown;
				if (numUd == null) { continue; }
				PropertyInfo pi = t.GetProperty(numUd.Tag as string);
				if (pi == null) { continue; }
				try { numUd.Value = (decimal)(int)pi.GetValue(settingData); }	//※
				catch { numUd.Value = Math.Max(0m, numUd.Minimum); udControl_ValueChanged(numUd, null); }
				/*
				※該当するプロパティはint型なのでpi.GetValue()は一旦int型でキャストする必要がある。
				直接decimal型でキャストすると例外'System.InvalidCastException'が発生する。
				*/
			}
		}

		//グループボックス内のラジオボタンのチェック状態を変更した
		private void radioButtonInGroupBox_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton rbtn = sender as RadioButton;
			if (rbtn == null || !rbtn.Checked) { return; }
			GroupBox grp = rbtn.Parent as GroupBox;
			if (grp == null) { return; }

			Type t = settingData.GetType();
			PropertyInfo pi = t.GetProperty(grp.Tag as string);
			if (pi == null) { return; }
			object rbVal = Enum.Parse(pi.PropertyType, rbtn.Tag as string);
			pi.SetValue(settingData, rbVal);
		}

		//コンボボックスのアイテムを選択してリストを閉じた
		private void comboBox_DropDownClosed(object sender, EventArgs e)
		{
			ComboBox cb = sender as ComboBox;
			if (cb == null) { return; }

			Type t = settingData.GetType();
			PropertyInfo pi = t.GetProperty(cb.Tag as string);
			if (pi == null) { return; }
			object enumVal = Enum.ToObject(pi.PropertyType, cb.SelectedIndex);
			pi.SetValue(settingData, enumVal);
		}
		
		//月の並び順を指定した
		private void cbMonthOrder_DropDownClosed(object sender, EventArgs e)
		{
			comboBox_DropDownClosed(sender, e);
			SetGrpMonthChangeAvailable();
		}
		//
		private void SetGrpMonthChangeAvailable()
		{
			//「月の切り替え」に関する設定
			//・[15日目]は、[2カ月],[3カ月]で[今月-来月-…]のときのみ意味のある設定なので、それ以外では[1日目]とする。
			if (cbMonthOrder.SelectedIndex == (int)EMonthOrder.CurrentNext ||
				cbMonthOrder.SelectedIndex == (int)EMonthOrder.CurrentNextNext)
			{
				grpMonthChange.Enabled = true;
			}
			else
			{
				rbChangeFirstDay.Checked = true;
				grpMonthChange.Enabled = false;
			}
		}

		//コンボボックスを初期化する
		private void Init_ComboBox(ComboBox cb)
		{
			Type t = settingData.GetType();
			PropertyInfo pi = t.GetProperty(cb.Tag as string);
			if (pi == null) { return; }
			try { cb.SelectedIndex = (int)pi.GetValue(settingData); }
			catch { cb.SelectedIndex = 0; comboBox_DropDownClosed(cb, null); }
		}

		//数値コントロールを操作した
		private void udControl_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown numUd = sender as NumericUpDown;
			if (numUd == null) { return; }

			Type t = settingData.GetType();
			PropertyInfo pi = t.GetProperty(numUd.Tag as string);
			if (pi == null) { return; }
			pi.SetValue(settingData, (int)numUd.Value);
		}

		#endregion

		#region TabFormat

		//TabFormatを初期化する
		private void InitTabFormat()
		{
			Init_RadioButton(grpFormatYM);

			tbUserFormatYM.Text = settingData.YearMonthFormat;
			btnFmtView_Click(this, null);

			Init_ComboBox(cbUserFormatW);
		}

		//書式確認ボタンを押した
		private void btnFmtView_Click(object sender, EventArgs e)
		{
			lblFormatViewYM.Text =
				renderer.GetYearMonthTitle(tbUserFormatYM.Text, DateTime.Today.Year, DateTime.Today.Month);
			settingData.YearMonthFormat = tbUserFormatYM.Text;
		}

		//書式入力欄からフォーカスが外れた→書式編集完了と見なす
		private void tbUserFormatYM_Leave(object sender, EventArgs e)
		{
			btnFmtView_Click(sender, e);
		}

		//曜日の表示タイプを選択した
		private void cbUserFormatW_DropDownClosed(object sender, EventArgs e)
		{
			comboBox_DropDownClosed(sender, e);
			//他に処理があればここに書く
		}

		#endregion

		#region TabColorSetting

		//TabColorSettingを初期化する
		private void InitTabColorSetting()
		{
			Init_ButtonForeColor(grpColorSetting);
			Init_FontSetting();
			Init_ButtonForeColor(grpCharEffect);
			Init_NumericUpDown(grpCharEffect);
			Init_ComboBox(cbEffectTodayBg);
			Init_ComboBox(cbEffectShadow);
		}

		//グループボックス内のボタンの文字色を初期化する
		private void Init_ButtonForeColor(GroupBox grp)
		{
			Type t = settingData.GetType();
			foreach (Control ctrl in grp.Controls)
			{
				Button btn = ctrl as Button;
				if (btn == null) { continue; }
				try
				{
					PropertyInfo pi = t.GetProperty(btn.Tag as string);
					btn.ForeColor = (Color)pi.GetValue(settingData);
				}
				catch { btn.ForeColor = Program.MainForm.ForeColor; }
			}
		}
		
		//フォント設定のコントロールを初期化する
		private void Init_FontSetting()
		{
			Array ctrls = GetAllControls(grpFontSetting);
			Type t = settingData.GetType();
			foreach (Control ctrl in ctrls)
			{
				Label lbl = ctrl as Label;
				if (lbl == null) { continue; }
				Font font;
				try
				{
					PropertyInfo pi = t.GetProperty(lbl.Tag as string);
					font = (Font)pi.GetValue(settingData);
				}
				catch { font = Program.MainForm.Font; }
				LabelCentering(lbl, font);
			}
		}
		
		//カレンダーの文字色を設定する
		private void btnColorSetting_Click(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			if (btn == null) { return; }

			DialogResult res = colorDlg.ShowDialog();
			if (res != DialogResult.OK) { return; }

			Type t = settingData.GetType();
			PropertyInfo pi = t.GetProperty(btn.Tag as string);
			if (pi == null) { return; }
			pi.SetValue(settingData, colorDlg.Color);
			
			//ボタンの色に反映させる
			btn.ForeColor = colorDlg.Color;
		}

		//今日の背景色の効果の種類を変更した
		private void cbEffectTodayBg_DropDownClosed(object sender, EventArgs e)
		{
			comboBox_DropDownClosed(sender, e);

			/*	cbEffectTodayBg.Items
			[0]なし
			[1]円形 塗り			[2]円形 枠線
			[3]四角形 塗り		[4]四角形 枠線
			[5]角丸四角形 塗り		[6]角丸四角形 枠線
			*/
			EEffectTodayBg effect = settingData.EffectTodayBg;	//読み替え
			btnColorTodayBg.Enabled = (effect != EEffectTodayBg.None);
			switch(effect)
			{
			//背景なし, 塗りつぶし系
			case EEffectTodayBg.None:
			case EEffectTodayBg.FillEllipse:
			case EEffectTodayBg.FillRectangle:
			case EEffectTodayBg.FillRoundRect:
				udTodayBgWidth.Value = udTodayBgWidth.Minimum;
				udTodayBgWidth.Enabled = false;
				break;

			//枠線系
			default:	//EEffectTodayBg.DrawEllipse, DrawRectangle, DrawRoundRect
				udTodayBgWidth.Enabled = true;
				break;
			}
		}

		//影付けの効果の種類を変更した
		private void cbEffectShadow_DropDownClosed(object sender, EventArgs e)
		{
			comboBox_DropDownClosed(sender, e);

			/*	cbEffectShadow.Items
			None,
			RightBottom,
			Round
			*/
			EEffectShadow effect = settingData.EffectShadow;  //読み替え
			switch (effect)
			{
			case EEffectShadow.None:
				btnColorShadow.Enabled = false;
				udShadowWidth.Value = udShadowWidth.Minimum;
				udShadowWidth.Enabled = false;
				break;

			default:    //EEffectShadow.RightBottom, Round
				btnColorShadow.Enabled = true;
				udShadowWidth.Enabled = true;
				break;
			}
		}

		//カレンダーのフォントを設定する
		private void btnFontSetting_Click(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			if (btn == null) { return; }

			Type t = settingData.GetType();
			PropertyInfo pi = t.GetProperty(btn.Tag as string);
			if (pi == null) { return; }

			try { fontDlg.Font = (Font)pi.GetValue(settingData); }
			catch { fontDlg.Font = Program.MainForm.Font; }
			DialogResult res = fontDlg.ShowDialog();
			if (res != DialogResult.OK) { return; }
			pi.SetValue(settingData, fontDlg.Font);

			//表示例に反映させる
			Array ctrls = GetAllControls(btn.Parent);
			foreach (Control ctrl in ctrls)
			{
				Label lbl = ctrl as Label;
				if (lbl == null) { continue; }
				if (!(btn.Tag as string).Equals(lbl.Tag as string)) { continue; }
				LabelCentering(lbl, fontDlg.Font);
				break;
			}

			//「日にち」ボタンだった場合、Tab-Advancedに反映させる
			if (btnFontDay == (sender as Button)) { dayStrMgr.GetMaxDayCellSize(fontDlg.Font); }
		}
		//
		private Array GetAllControls(Control top)
		{
			ArrayList buf = new ArrayList();
			foreach (Control ctrl in top.Controls)
			{
				buf.Add(ctrl);
				buf.AddRange(GetAllControls(ctrl));
			}
			return buf.ToArray(typeof(Control));
		}
		//
		private void LabelCentering(Label lbl, Font font)
		{
			int mid = (lbl.Top + lbl.Bottom) / 2;
			lbl.Font = font;
			lbl.Top = mid - lbl.Height / 2;
		}

		#endregion

		#region TabSpecialDay

		//TabSpecialDayを初期化する
		private void InitTabSpecialDay()
		{
			cbSpdayWWeek.SelectedIndex = 0;
			lstRegistSpecialDay.Items.AddRange(settingData.SpecialDays.ToArray());
		}

		//特別日の登録形式を変更した（第n曜日形式）
		private void rbSpdaySetWeek_CheckedChanged(object sender, EventArgs e)
		{
			pnlSpdaySetWeek.Enabled = true;
			pnlSpdaySetDay.Enabled = false;
		}

		//特別日の登録形式を変更した（日付形式）
		private void rbSpdaySetDay_CheckedChanged(object sender, EventArgs e)
		{
			pnlSpdaySetWeek.Enabled = false;
			pnlSpdaySetDay.Enabled = true;
		}

		//特別日の登録ボタンを押した
		private void btnSpdayRegist_Click(object sender, EventArgs e)
		{
			string spDay;
			if (pnlSpdaySetDay.Enabled)
			{
				spDay = settingMgr.GetFormattedSpecialDay(
					(int)udSpdayMonth.Value, (int)udSpdayDay.Value	);
			}
			else
			{
				spDay = settingMgr.GetFormattedSpecialDay(
					(int)udSpdayWMonth.Value, (int)udSpdayWCount.Value, (string)cbSpdayWWeek.SelectedItem	);
			}

			if (!lstRegistSpecialDay.Items.Contains(spDay))
			{
				lstRegistSpecialDay.Items.Add(spDay);
				settingData.SpecialDays.Add(spDay);
			}
		}

		//特別日の削除ボタンを押した
		private void btnSpdayDelete_Click(object sender, EventArgs e)
		{
			for (int i = lstRegistSpecialDay.SelectedItems.Count - 1; 0 <= i; i--)
			{
				string item = lstRegistSpecialDay.SelectedItems[i] as string;
				lstRegistSpecialDay.Items.Remove(item);
				settingData.SpecialDays.Remove(item);
			}
		}

		#endregion

		#region TabAdvanced

		//TabAdvancedを初期化する
		private	void InitTabAdvanced()
		{
			Init_NumericUpDown(grpDayCellSize);
			Init_NumericUpDown(grpDayStrOffset);

			dayStrMgr.GetMaxDayCellSize(settingData.FontDay);
			btnPreviewDayStr_Click(this, null);
		}

		//パネルを描画更新する
		private void pnlCanvas_Paint(object sender, PaintEventArgs e)
		{
			var g = e.Graphics;
			g.Clear(DefaultBackColor);
			dayStrMgr.FillCellRect(g, dayStrMgr.CellRect);
			dayStrMgr.DrawDayString(g, settingData.FontDay, dayStrMgr.CellRect, dayStrMgr.StrOffset);
		}

		//日にちのマス目と文字位置を調整した状態のプレビュー
		private void btnPreviewDayStr_Click(object sender, EventArgs e)
		{
			Size cellSize = new Size(settingData.DayCellWidth, settingData.DayCellHeight);
			if (cellSize.IsEmpty)
			{
				cellSize = dayStrMgr.GetMaxDayCellSize(settingData.FontDay);
				udDayCellWidth.Value = cellSize.Width;
				udDayCellHeight.Value = cellSize.Height;
			}
			dayStrMgr.CellRect = dayStrMgr.GetCenteringRect(pnlCanvas.Size, cellSize);
			dayStrMgr.StrOffset = new Point(settingData.DayStrOffsetX, settingData.DayStrOffsetY);

			pnlCanvas.Refresh();
		}

		#endregion

	}   //class
}	//namespace
