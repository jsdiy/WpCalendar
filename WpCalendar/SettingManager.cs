using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace WpCalendar
{
	class SettingManager
	{
		private SettingData settingData;

		//コンストラクタ
		public SettingManager() { }

		//SettingDataを初期化する
		public void Initialize(SettingData settingData)
		{
			settingData.OriginalImageFile = "";

			//tab-Layout
			settingData.MonthDirection = EMonthDirection.Holizon;
			settingData.MonthChange = EMonthChange.FirstDay;
			settingData.StartWeek = EStartWeek.Sunday;

			//tab-Format
			settingData.YearMonthAlign = EAlign.Left;
			settingData.YearMonthFormat = "yyyy mmmm";
			settingData.WeekFormat = EWeekFormat.None;

			//tab-ColorSetting
			settingData.ColorYearMonth = settingData.ColorWeekday =
				settingData.ColorSaturday = settingData.ColorSunday = settingData.ColorSpecialDay =
				settingData.ColorTodayBg = settingData.ColorShadow = Color.Black;
			settingData.FontYearMonth = settingData.FontWeek = settingData.FontDay = Program.MainForm.Font;
			settingData.EffectTodayBg = EEffectTodayBg.None;
			settingData.EffectShadow = EEffectShadow.None;
			settingData.EffectTodayBgWidth = settingData.EffectShadowWidth = 1;

			//tab-SpecialDay
			settingData.SpecialDays = new List<string>();

			//tab-Advanced
			//settingData.DayCellWidth = settingData.DayCellHeight = 0;
			//settingData.DayStrOffsetX = settingData.DayStrOffsetY = 0;

			//tab-Option
			//廃止
		}

		//シリアライズ（保存）
		public void SaveToXml(SettingData settingData, string filePath)
		{
			// XMLファイルへの保存（シリアル化）
			//・UTF-8(BOMなし)で出力したい。
			var serializer = new XmlSerializer(typeof(SettingData));
			using (var writer = new StreamWriter(filePath, false, new UTF8Encoding(false)))
			{
				serializer.Serialize(writer, settingData);
			}
		}

		//デシリアライズ（読み出し）
		public SettingData LoadFromXml(string filePath)
		{
			SettingData settingData;
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(SettingData));
				using (TextReader textReader = new StreamReader(filePath))
				{
					settingData = serializer.Deserialize(textReader) as SettingData;
				}
			}
			catch
			{
				settingData = new SettingData();
				Initialize(settingData);
			}

			this.settingData = settingData; 
			return settingData;
		}

		//特別日かどうか
		public bool IsSpecialDay(int month, int day)
		{
			string spDay = GetFormattedSpecialDay(month, day);
			return settingData.SpecialDays.Contains(spDay);
		}
		//
		public bool IsSpecialDay(int month, int weekCount, string weekName)
		{
			string spDay = GetFormattedSpecialDay(month, weekCount, weekName);
			return settingData.SpecialDays.Contains(spDay);
		}

		//特別日の書式に加工する
		public string GetFormattedSpecialDay(int month, int day)
		{
			return string.Format("{0,2}/{1}", month, day);
		}
		//
		public string GetFormattedSpecialDay(int month, int weekCount, string weekName)
		{
			return string.Format("{0,2}/第{1}{2}曜", month, weekCount, weekName);
		}

		//オリジナルの壁紙ファイルを取得する
		public Bitmap GetOriginalWallpaperImage()
		{
			Bitmap bmp = null;
			try
			{
				byte[] buf = File.ReadAllBytes(settingData.OriginalImageFile);
				using (MemoryStream ms = new MemoryStream(buf))
				{
					bmp = new Bitmap(ms);
				}
			}
			catch { }

			return bmp;
		}

	}   //class
}	//namespace
