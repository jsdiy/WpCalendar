using Microsoft.Win32;	//Registry
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WpCalendar
{
	/// <summary>
	/// Windowsの壁紙設定を操作する
	/// ・レジストリを操作する。
	/// </summary>
	class WindowsWallpaper
	{
		private enum Pattern
		{
			Center = 0,
			Tile = 1,
			Stretch = 2,
			Fit = 6,
			Fill = 10,
			Span = 22	//非対応
		}

		//コンストラクタ
		public WindowsWallpaper() { }

		//指定の画像ファイルで壁紙を変更する
		//引数:	壁紙の画像ファイル（フルパス）
		public void SetImage(string filePath)
		{
			StringBuilder sb = new StringBuilder(filePath);
			SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, sb, SPIF_UPDATEINIFILE);
		}

		//現在の壁紙ファイルの場所を取得する
		//・カレンダー描画前の画像か描画後の画像かは関係ない（分からない）。とにかく最後に設定した壁紙画像の場所。
		//戻り値:	画像ファイルのフルパス
		public string GetImageFile()
		{
			StringBuilder sb = new StringBuilder(MAX_PATH);
			SystemParametersInfo(SPI_GETDESKWALLPAPER, MAX_PATH, sb, SPIF_UPDATEINIFILE);
			return sb.ToString();
		}

		//カレンダーの描画先となるベース画像を作成する
		//・デスクトップの背景色のBitmapに、システムで設定された壁紙表示パターンで元画像を転写する。
		public Bitmap CreateWallpaperBaseImage(Bitmap orgBmp)
		{
			//無地の画像を用意する
			Bitmap baseBmp = CreateDesktopSizeImage(SystemColors.Desktop);
			if (orgBmp == null) { return baseBmp; }

			//元画像を転写する
			using (Graphics g = Graphics.FromImage(baseBmp))
			{
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

				Pattern pattern = GetDisplayPattern();
				switch (pattern)
				{
				default:
				case Pattern.Center:    //拡大縮小なしで画面中央に表示する
					DrawPatternCenter(g, orgBmp, baseBmp);
					break;

				case Pattern.Tile:  //拡大縮小なしで左上起点で敷き詰める
					DrawPatternTile(g, orgBmp, baseBmp);
					break;

				case Pattern.Stretch:   //アスペクト比無視で画面に収める
					DrawPatternStretch(g, orgBmp, baseBmp);
					break;

				case Pattern.Fit:   //トリミングなし（余白あり）で画面に収める
					if (IsUltraWideImage(orgBmp))
						DrawScaleToWidth(g, orgBmp, baseBmp); //goto case Pattern.ScaleToWidth;
					else
						DrawScaleToHeight(g, orgBmp, baseBmp); //goto case Pattern.ScaleToHeight;
					break;

				case Pattern.Fill:  //トリミングあり（余白なし）で画面に収める
					if (IsUltraWideImage(orgBmp))
						DrawScaleToHeight(g, orgBmp, baseBmp); //goto case Pattern.ScaleToHeight;
					else
						DrawScaleToWidth(g, orgBmp, baseBmp); //goto case Pattern.ScaleToWidth;
					break;
				}
			}

			return baseBmp;
		}

		//デスクトップサイズのBitmapを作成する
		private Bitmap CreateDesktopSizeImage(Color color)
		{
			Size screenSize = Screen.PrimaryScreen.Bounds.Size;
			Bitmap bmp = new Bitmap(screenSize.Width, screenSize.Height);
			using (Graphics g = Graphics.FromImage(bmp)) { g.Clear(color); }
			return bmp;
		}

		//壁紙の表示パターンを取得する
		private Pattern GetDisplayPattern()
		{
			int nTile, nStyle;
			try
			{
				string szTileWallpaper, szWallpaperStyle;
				using (RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop"))
				{
					szTileWallpaper = regKey.GetValue("TileWallpaper", "0") as string;
					szWallpaperStyle = regKey.GetValue("WallpaperStyle", "0") as string;
				}
				nTile = int.Parse(szTileWallpaper);
				nStyle = int.Parse(szWallpaperStyle);
			}
			catch { nTile = nStyle = 0; }

			Pattern ptn = (Pattern)(nStyle + nTile);
			if (Enum.GetName(typeof(Pattern), ptn) == null) { ptn = Pattern.Center; }

			return ptn;
		}
		/*	壁紙の表示パターンについて
		壁紙の表示パターンは2つのレジストリキーの組み合わせで決まる。
		HKEY_CURRENT_USER\Control Panel\Desktop\WallpaperStyle, TileWallpaper

		WallpaperStyle/TileWallpaper	※Windows11/25H2で確認
		0/0	中央に表示(Center)
			・画像は拡大縮小せず。
		0/1	並べて表示(Tile)
			・画像は拡大縮小せず。
		2/0	拡大して表示(Stretch)
			・アスペクト比を維持せず、画像を画面にフィット（拡大縮小）させる。
		6/0	画面のサイズに合わせる(Fit)
			・アスペクト比を維持し、画面にちょうど収まるように拡大縮小する。画面の上下または左右に余白ができる場合がある。
		10/0	ページ幅に合わせる(Fill)	※Windowsの日本語訳が正しくない
			・アスペクト比を維持し、画面が埋まるように拡大縮小する。画像の上下または左右がはみ出る場合がある。
		22/0	スパン(Span)
			・マルチ画面に渡って表示する。アスペクト比は維持されない模様（未確認）。
		*/

		//Win32APIのSystemParametersInfoの定義
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern bool SystemParametersInfo(
			uint uiAction,
			uint uiParam,
			[MarshalAs(UnmanagedType.LPWStr)]
			StringBuilder pvParam,
			uint fWinIni
			);
		/*	引数の説明
		BOOL SystemParametersInfo(
		  UINT uiAction,  // 取得または設定するべきシステムパラメータ
		  UINT uiParam,   // 実施するべき操作によって異なる
		  PVOID pvParam,  // 実施するべき操作によって異なる
		  UINT fWinIni    // ユーザープロファイルの更新オプション
		);
		https://learn.microsoft.com/ja-jp/windows/win32/api/winuser/nf-winuser-systemparametersinfow
		*/
		//SystemParametersInfo()で使用する定数
		private const int MAX_PATH = 260;
		private const uint
			SPI_GETDESKWALLPAPER = 0x0073,
			SPI_SETDESKWALLPAPER = 0x0014,
			SPIF_UPDATEINIFILE = 0x0001;
		/*	定数の説明
		SPI_GETDESKWALLPAPER:
		デスクトップの壁紙として表示されるビットマップのフルパス名を取得します。
		pvParam パラメータで、1 個のバッファへのポインタを指定します。
		関数から制御が返ると、このバッファに、フルパス名を表す、NULL で終わる文字列が格納されます。
		uiParam パラメータで、pvParam パラメータが指すバッファのサイズを文字数単位で指定します。
		取得される文字列は、MAX_PATH 文字以内です。
		デスクトップの壁紙が指定されていない場合、空文字列が取得されます。
	
		SPI_SETDESKWALLPAPER:
		デスクトップに表示される壁紙を設定します。
		pvParam パラメータの値に基づいて、新しい壁紙が決まります。
		壁紙のビットマップを指定するには、pvParam パラメータで、ビットマップファイルの名前を表す、NULL で終わる文字列へのポインタを指定します。
		pvParam パラメータで空の文字列（""）を指定すると、壁紙は表示されなくなります。
		pvParam パラメータで SETWALLPAPER_DEFAULT または NULL を指定すると、既定の壁紙へ戻ります。

		SPIF_UPDATEINIFILE:
		システム全体のパラメータに関する新しい設定を、ユーザープロファイルに書き込みます。
		*/
		/*	壁紙操作の参考
		http://smdn.jp/programming/tips/setdeskwallpaper/
		*/

		//ベース画像を作成する
		private void DrawPatternCenter(Graphics g, Bitmap orgBmp, Bitmap baseBmp)
		{
			int posX = (baseBmp.Width - orgBmp.Width) / 2;
			int posY = (baseBmp.Height - orgBmp.Height) / 2;
			g.DrawImage(orgBmp, posX, posY);
		}

		//元画像を転写する
		private void DrawPatternTile(Graphics g, Bitmap orgBmp, Bitmap baseBmp)
		{
			for (int posY = 0; posY < baseBmp.Height; posY += orgBmp.Height)
			{
				for (int posX = 0; posX < baseBmp.Width; posX += orgBmp.Width)
				{
					g.DrawImage(orgBmp, posX, posY);
				}
			}
		}

		//元画像を転写する
		private void DrawPatternStretch(Graphics g, Bitmap orgBmp, Bitmap baseBmp)
		{
			g.DrawImage(orgBmp, 0, 0, baseBmp.Width, baseBmp.Height);
		}

		//元画像を転写する
		private void DrawScaleToWidth(Graphics g, Bitmap orgBmp, Bitmap baseBmp)
		{
			float fitScale = (float)baseBmp.Width / orgBmp.Width;
			int scaledHeight = (int)(orgBmp.Height * fitScale + 0.9f);  //端数切り上げ
			int posY = (baseBmp.Height - scaledHeight) / 2;
			g.DrawImage(orgBmp, 0, posY, baseBmp.Width, scaledHeight);
		}

		//元画像を転写する
		private void DrawScaleToHeight(Graphics g, Bitmap orgBmp, Bitmap baseBmp)
		{
			float fitScale = (float)baseBmp.Height / orgBmp.Height;
			int scaledWidth = (int)(orgBmp.Width * fitScale + 0.9f);    //端数切り上げ
			int posX = (baseBmp.Width - scaledWidth) / 2;
			g.DrawImage(orgBmp, posX, 0, scaledWidth, baseBmp.Height);
		}

		//画面の縦横比に対して横長の画像かを判断する
		private bool IsUltraWideImage(Bitmap orgBmp)
		{
			Size screenSize = Screen.PrimaryScreen.Bounds.Size;
			float screenAspectRatio = (float)screenSize.Width / screenSize.Height;
			float imageAspectRatio = (float)orgBmp.Width / orgBmp.Height;
			return (imageAspectRatio > screenAspectRatio);
		}

	}   //class
}	//namespace
