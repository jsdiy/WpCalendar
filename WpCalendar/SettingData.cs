using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Xml.Serialization;

namespace WpCalendar
{
	//ラジオボタンの内容
	public enum EMonthDirection { Holizon, Vertical }
	public enum EMonthChange { FirstDay, MidMonth }
	public enum EStartWeek { Sunday, Monday }
	public enum EAlign { Left, Center, Right }

	//コンボボックスの内容
	public enum EMonthOrder
	{
		Current,            //[0]1ヵ月 今月
		PrevCurrent,        //[1]2ヵ月 前月 - 今月
		CurrentNext,        //[2]2ヵ月 今月 - 翌月
		PrevPrevCurrent,    //[3]3ヵ月 前々月 - 前月 - 今月
		PrevCurrentNext,    //[4]3ヵ月 前月 - 今月 - 翌月
		CurrentNextNext     //[5]3ヵ月 今月 - 翌月 - 翌々月
	}

	public enum EWeekFormat
	{
		None,   //表示しない
		Jp,     //月, 火, 水,…
		Mo,     //Mo, Tu, We,…
		Mon     //Mon, Tue, Wed,…
	}

	public enum EEffectTodayBg
	{
		None,
		FillEllipse,	DrawEllipse,
		FillRectangle,	DrawRectangle,
		FillRoundRect,	DrawRoundRect
	}

	public enum EEffectShadow
	{
		None,
		RightBottom,
		Round
	}

	/// <summary>
	/// 設定値保存クラス
	/// </summary>
	[XmlRoot("SettingData")]
	public class SettingData
	{
		//カレンダー描画なしの、元の壁紙ファイル（フルパス）
		public string OriginalImageFile { get; set; }

		#region タブごとの設定項目

		//tab-Layout
		public EMonthOrder MonthOrder { get; set; }
		public EMonthDirection MonthDirection { get; set; }
		public EMonthChange MonthChange { get; set; }
		public EStartWeek StartWeek { get; set; }
		public int GapMonthToMonth { get; set; }
		public int GapYearMonthToWeek { get; set; }
		public int GapWeekToDay { get; set; }
		public int GapDayHolizon { get; set; }
		public int GapDayVertical { get; set; }
		public int OriginX { get; set; }
		public int OriginY { get; set; }

		//tab-Format
		public EAlign YearMonthAlign { get; set; }
		public string YearMonthFormat { get; set; }
		public EWeekFormat WeekFormat { get; set; }

		//tab-ColorSetting
		[XmlIgnore]
		public Color ColorYearMonth { get; set; }
		public string SColorYearMonth { get { return ToArgb(ColorYearMonth); } set { ColorYearMonth = FromArgb(value); } }
		[XmlIgnore]
		public Color ColorWeekday { get; set; }
		public string SColorWeekday { get { return ToArgb(ColorWeekday); } set { ColorWeekday = FromArgb(value); } }
		[XmlIgnore]
		public Color ColorSaturday { get; set; }
		public string SColorSaturday { get { return ToArgb(ColorSaturday); } set { ColorSaturday = FromArgb(value); } }
		[XmlIgnore]
		public Color ColorSunday { get; set; }
		public string SColorSunday { get { return ToArgb(ColorSunday); } set { ColorSunday = FromArgb(value); } }
		[XmlIgnore]
		public Color ColorHoliday { get { return ColorSunday; } }
		[XmlIgnore]
		public Color ColorSpecialDay { get; set; }
		public string SColorSpecialDay { get { return ToArgb(ColorSpecialDay); } set { ColorSpecialDay = FromArgb(value); } }
		[XmlIgnore]
		public Color ColorTodayBg { get; set; }
		public string SColorTodayBg { get { return ToArgb(ColorTodayBg); } set { ColorTodayBg = FromArgb(value); } }
		[XmlIgnore]
		public Color ColorShadow { get; set; }
		public string SColorShadow { get { return ToArgb(ColorShadow); } set { ColorShadow = FromArgb(value); } }

		public EEffectTodayBg EffectTodayBg { get; set; }
		public int EffectTodayBgWidth { get; set; }
		public EEffectShadow EffectShadow { get; set; }
		public int EffectShadowWidth { get; set; }

		[XmlIgnore]
		public Font FontYearMonth { get; set; }
		public SerializableFont SFontYearMonth { get { return new SerializableFont(FontYearMonth); } set { FontYearMonth = value.ToFont(); } }
		[XmlIgnore]
		public Font FontWeek { get; set; }
		public SerializableFont SFontWeek { get { return new SerializableFont(FontWeek); } set { FontWeek = value.ToFont(); } }
		[XmlIgnore]
		public Font FontDay { get; set; }
		public SerializableFont SFontDay { get { return new SerializableFont(FontDay); } set { FontDay = value.ToFont(); } }

		//tab-SpecialDay
		public List<string> SpecialDays { get; set; }

		//tab-Advanced
		public int DayCellWidth { get; set; }	//フォントに関係なく日にちのマス目サイズを固定値で与える
		public int DayCellHeight { get; set; }	//※グリフ（見た目の形）に対する余白が大きなフォントがあるので人為的な調整が必要。
		public int DayStrOffsetX { get; set; }	//日にち描画位置の調整値（日にちのマス目に対する計算上のセンタリング位置からのオフセット）
		public int DayStrOffsetY { get; set; }  //※グリフを計算だけでセンタリングすることは困難なので人為的な調整が必要。

		//tab-Option
		//廃止

		#endregion

		//コンストラクタ
		public SettingData() { }

		//Color型とARGB表現の相互変換
		private string ToArgb(Color color) { return color.ToArgb().ToString("X8"); }
		private Color FromArgb(string argb) { return Color.FromArgb(Int32.Parse(argb, NumberStyles.HexNumber)); }

	}	//class

	/// <summary>
	/// Font型プロパティ変換クラス
	/// ・XMLシリアライズ対象の一部なのでpublic classとする必要がある。
	/// </summary>
	public class SerializableFont
	{
		//XMLシリアライズされるプロパティ
		public string Name { get; set; }
		public float Size { get; set; }
		public FontStyle Style { get; set; }

		// XmlSerializerに必要な既定のコンストラクター
		public SerializableFont() { }

		// Fontオブジェクトからの変換を容易にするコンストラクター
		public SerializableFont(Font font)
		{
			if (font == null) { font = Program.MainForm.Font; }
			Name = font.Name;
			Size = font.Size;
			Style = font.Style;
		}

		// Fontオブジェクトへ変換するメソッド
		public Font ToFont()
		{
			Font font;
			try { font = new Font(Name, Size, Style); }
			catch { font = Program.MainForm.Font; }
			return font;
		}

	}	//class

}   //namespace
