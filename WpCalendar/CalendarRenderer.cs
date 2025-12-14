using JapaneseCalendar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization; //Calendar,CultureInfo,DateTimeFormatInfo
using System.Linq;
using System.Windows.Forms;

namespace WpCalendar
{
	/// <summary>
	/// 壁紙となるBitmapにカレンダーを描画する
	/// </summary>
	class CalendarRenderer
	{
		//DateTime.ToString("フォーマット")
		//http://msdn.microsoft.com/ja-jp/library/k494fzbf(v=vs.80).aspx

		//日にちの描画属性
		private class DayAttribute
		{
			public static int Year, Month;
			//public static Size cell;

			public int day;
			public string sDay;
			public Size strSize;
			public int weekIndex;	//0(日),1(月),2(火),…,6(土)
			public int weekCount;	//第n○曜日 のn
			public Color color;		//平日、土曜、日曜の区別のみ。祝日、特別日は考慮しない。
			//public Point pos;	//マス目の位置
		}

		//曜日を表すインデックス
		private struct WeekIndex
		{
			public const int Sun = 0, Mon = 1, Tue = 2, Wed = 3, Thu = 4, Fri = 5, Sat = 6;
		}

		//曜日名の表示パターン
		private static readonly string[][] WeekNameList =
		{
			null,	//「表示しない」の場合
			new string[] { "日", "月", "火", "水", "木", "金", "土", "日" },
			new string[] { "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" },
			new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" }
		};

		//定数
		private const int WeekLength = 7;

		//オブジェクト
		private SettingData settingData;
		private SettingManager settingMgr;

		//コンストラクタ
		public CalendarRenderer() {	}

		//Bitmapにカレンダーを描画する
		//戻り値：	描画成功／失敗
		public bool Draw(Bitmap distBmp, SettingData settingData, SettingManager settingMgr)
		{
			this.settingData = settingData;
			this.settingMgr = settingMgr;

			//{前々月,前月,今月,来月,来々月}を描く／描かない、を決める
			bool[] targetMonths;
			switch (settingData.MonthOrder)
			{
			default:
			case EMonthOrder.Current: targetMonths = new bool[] { false, false, true, false, false };	break;
			case EMonthOrder.PrevCurrent: targetMonths = new bool[] { false, true, true, false, false }; break;
			case EMonthOrder.CurrentNext: targetMonths = new bool[] { false, false, true, true, false }; break;
			case EMonthOrder.PrevPrevCurrent: targetMonths = new bool[] { true, true, true, false, false }; break;
			case EMonthOrder.PrevCurrentNext: targetMonths = new bool[] { false, true, true, true, false }; break;
			case EMonthOrder.CurrentNextNext: targetMonths = new bool[] { false, false, true, true, true }; break;
			}

			//月ごとにカレンダーを描く
			Rectangle calendarRect = new Rectangle(settingData.OriginX, settingData.OriginY, 1, 1);
			int startPart = ((settingData.MonthChange == EMonthChange.MidMonth) && (DateTime.Today.Day < 15)) ? -3 : -2;
			for (int monthPart = startPart, i = 0; i < targetMonths.Length; i++, monthPart++)
			{
				//描画対象外の月なら次の月へ
				if (!targetMonths[i]) { continue; }

				//１カ月分のカレンダーを描く
				if (!DrawOneMonth(distBmp, monthPart, ref calendarRect)) { return false; }

				//次の月を描く位置を決める
				calendarRect = (settingData.MonthDirection == EMonthDirection.Holizon)
					?	new Rectangle(calendarRect.Right + settingData.GapMonthToMonth, calendarRect.Top, 1, 1)		//水平方向
					:	new Rectangle(calendarRect.Left, calendarRect.Bottom + settingData.GapMonthToMonth, 1, 1);	//垂直方向
			}

			return true;
		}

		//Bitmapにカレンダーを描画する
		//引数	monthPart:	今月を位置0としたNヵ月前後の相対値(…,-2,-1,0,1,2,…)。
		//		calendarRect:	描画の起点座標を受け取り、描画に使った幅・高さを返す。
		private bool DrawOneMonth(Bitmap distBmp, int monthPart, ref Rectangle calendarRect)
		{
			DayAttribute[] dayAttrs = GenerateDayAttributes(monthPart);
			Size dayCellSize = GetDayCellSize(dayAttrs);
			calendarRect.Width = (dayCellSize.Width + settingData.GapDayHolizon) * WeekLength - settingData.GapDayHolizon;

			Graphics g = Graphics.FromImage(distBmp);
			SolidBrush brushShadow = new SolidBrush(settingData.ColorShadow);
			bool isOK = true;
			int posY = calendarRect.Y;
			try
			{
				//年／月部分を描く
				posY = DrawYearMonthBlock(posY, calendarRect, g, brushShadow);

				//曜日部分を描く
				posY = DrawWeekBlock(posY, calendarRect, dayCellSize, g, brushShadow);

				//日にち部分を描く
				posY = DrawDayBlock(posY, calendarRect, dayCellSize, dayAttrs, g, brushShadow);
			}
			catch
			{
				isOK = false;
			}
			finally
			{
				g?.Dispose();
				brushShadow?.Dispose();
			}

			calendarRect.Height = posY - calendarRect.Y;
			return isOK;
		}

		//1カ月分の属性付き日にち配列を取得する
		//引数：	今月を起点0としたNヵ月前後の相対値(…,-2,-1,0,1,2,…)
		//戻り値：	[0]を日曜として、一日（ついたち）の曜日の要素からDayAttributeオブジェクトを格納した配列
		private DayAttribute[] GenerateDayAttributes(int monthPart)
		{
			DateTime dtToday = DateTime.Today;
			DateTime dtAdjMonth = dtToday.AddMonths(monthPart);
			DayAttribute.Year = dtAdjMonth.Year;
			DayAttribute.Month = dtAdjMonth.Month;

			int lastDay = DateTime.DaysInMonth(dtAdjMonth.Year, dtAdjMonth.Month);  //その月の日数
			DateTime firstDay = new DateTime(dtAdjMonth.Year, dtAdjMonth.Month, 1);
			int firstDayWeek = (int)firstDay.DayOfWeek; //0(日),1(月),2(火),…,6(土)

			//曜日の色のリスト
			Color[] weekColorList = Enumerable.Repeat(settingData.ColorWeekday, WeekLength).ToArray();
			weekColorList[WeekIndex.Sun] = settingData.ColorSunday;
			weekColorList[WeekIndex.Sat] = settingData.ColorSaturday;

			//配列の[0]を日曜とし、該当する曜日位置から格納する
			//・月曜始まりのカレンダーとしている場合は[1]から配列が始まると考える。
			//	従って月曜始まりのカレンダーで一日（ついたち）が日曜だった場合は[7]から格納開始することとなる。
			//・1ヵ月は最大6週間に渡る。それに上記ズレ（月曜始まりに起因するズレ）の分を1週間加えるので、配列は7週間分用意する。
			DayAttribute[] dayAttrs = new DayAttribute[WeekLength * 7];
			int startIndex = (firstDayWeek == WeekIndex.Sun) ? WeekIndex.Sun + WeekLength : firstDayWeek;
			Size proposedSize = new Size(int.MaxValue, int.MaxValue);
			for (int i = startIndex, d = 1; d <= lastDay; d++, i++)
			{
				//日にち、曜日の情報
				DayAttribute dayAttr = new DayAttribute();
				dayAttr.day = d;
				dayAttr.sDay = d.ToString();
				dayAttr.strSize = TextRenderer.MeasureText(dayAttr.sDay, settingData.FontDay,
					proposedSize, TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
				dayAttr.weekIndex = i % WeekLength;
				dayAttr.weekCount = (d - 1) / WeekLength + 1;   //「第n○曜日」のn

				//日にちの色
				dayAttr.color = weekColorList[dayAttr.weekIndex];

				//配列に格納
				dayAttrs[i] = dayAttr;
			}
			return dayAttrs;
		}

		//日にちのマス目のサイズを取得する
		//・2桁の数字が収まる長方形のサイズ（フォントの余白を含む）。
		private Size GetDayCellSize(DayAttribute[] dayAttrs)
		{
			Size cell = new Size(0, 0);
			if (settingData.DayCellWidth == 0 || settingData.DayCellHeight == 0)
			{
				foreach (DayAttribute dayAttr in dayAttrs)
				{
					if (dayAttr == null) { continue; }
					cell.Width = Math.Max(cell.Width, dayAttr.strSize.Width);
					cell.Height = Math.Max(cell.Height, dayAttr.strSize.Height);
				}
			}
			else
			{
				cell.Width = settingData.DayCellWidth;
				cell.Height = settingData.DayCellHeight;
			}

			return cell;
		}

		//カレンダーの年／月を描く
		//戻り値：	次の領域（曜日領域）を描く位置（Y座標）
		private int DrawYearMonthBlock(int posY, Rectangle calendarRect, Graphics g, SolidBrush brushShadow)
		{
			string sYearMonth = GetYearMonthTitle(settingData.YearMonthFormat, DayAttribute.Year, DayAttribute.Month);

			if (sYearMonth == null)
			{
				posY += settingData.GapYearMonthToWeek;
			}
			else
			{
				Size ymTitleSize = TextRenderer.MeasureText(sYearMonth, settingData.FontYearMonth);

				//位置決め
				int posX;
				switch (settingData.YearMonthAlign)
				{
				default:
				case EAlign.Left: posX = calendarRect.X; break;
				case EAlign.Right: posX = calendarRect.Right - ymTitleSize.Width; break;
				case EAlign.Center: posX = calendarRect.X + (calendarRect.Width - ymTitleSize.Width) / 2; break;
				}

				//描画
				DrawString(sYearMonth, settingData.FontYearMonth, settingData.ColorYearMonth, posX, posY, g, brushShadow);
				posY += ymTitleSize.Height + settingData.GapYearMonthToWeek;
			}

			return posY;
		}

		//カレンダーの曜日を描く
		//戻り値：	次の領域（日にち領域）を描く位置（Y座標）
		private int DrawWeekBlock(int posY, Rectangle calendarRect, Size dayCellSize, Graphics g, SolidBrush brushShadow)
		{
			string[] weekNames = WeekNameList[(int)settingData.WeekFormat];
			int weekStartIndex = (settingData.StartWeek == EStartWeek.Sunday) ? WeekIndex.Sun : WeekIndex.Mon;

			if (weekNames == null)
			{
				posY += settingData.GapWeekToDay;
			}
			else
			{
				int nextCellX = dayCellSize.Width + settingData.GapDayHolizon;
				int posX = calendarRect.X;
				for (int i = weekStartIndex; i < weekStartIndex + WeekLength; i++, posX += nextCellX)
				{
					//色を決める
					Color color = settingData.ColorWeekday;	//月～金曜
					if (i % WeekLength == WeekIndex.Sat) { color = settingData.ColorSaturday; } //土曜
					if (i % WeekLength == WeekIndex.Sun) { color = settingData.ColorSunday; }   //日曜

					//描画する
					int adjX = (dayCellSize.Width - TextRenderer.MeasureText(weekNames[i], settingData.FontWeek).Width) / 2;
					DrawString(weekNames[i], settingData.FontWeek, color, posX + adjX, posY, g, brushShadow);
				}
				posY += settingData.FontWeek.Height + settingData.GapWeekToDay;
			}

			return posY;
		}

		//カレンダーの日にちを描く
		//戻り値：	次の領域（があると仮定し、それ）を描く位置（Y座標）
		private int DrawDayBlock(int posY, Rectangle calendarRect, Size dayCellSize, DayAttribute[] dayAttrs, Graphics g, SolidBrush brushShadow)
		{
			int nextCellX = dayCellSize.Width + settingData.GapDayHolizon;
			int nextCellY = dayCellSize.Height + settingData.GapDayVertical;
			int weekStartIndex = (settingData.StartWeek == EStartWeek.Sunday) ? WeekIndex.Sun : WeekIndex.Mon;
			List<int> holidayList = Holiday.GetHolidays(DayAttribute.Year, DayAttribute.Month);

			int posX = calendarRect.X;
			for (int i = weekStartIndex; i < dayAttrs.Length; i++, posX += nextCellX)
			{
				DayAttribute dayAttr = dayAttrs[i];
				if (dayAttr == null) { continue; }

				//位置決め
				//・(posX,posY)は日にちのマス目の左上座標。
				if ((weekStartIndex < i) && (dayAttr.weekIndex == weekStartIndex))
				{
					//次の行の先頭位置へ移動
					posX = calendarRect.X;
					//posY += nextCellY;	//20171008 del
					if (dayAttr.day != 1) { posY += nextCellY; }   //20171008 add
				}

				//「今日」の背景色を塗る
				if ((settingData.EffectTodayBg != EEffectTodayBg.None) && IsToday(dayAttr))
				{
					DrawTodayBg(g, posX, posY, dayCellSize);
				}

				//文字色を決める
				//・↓else-ifではないことに注意。祝日を特別日に指定した場合に、特別日の色を反映させるため。
				Color color = dayAttr.color;	//通常日の色（平日、土曜、日曜）
				if (IsHoliday(dayAttr, holidayList)) { color = settingData.ColorHoliday; }  //祝日の色
				if (IsSpecialDay(dayAttr)) { color = settingData.ColorSpecialDay; } //特別日の色

				//日にちの数字を描画する
				//・マス目に対してセンタリングし、その状態に対してユーザー指定の調整値を加える。
				int strX = posX + (dayCellSize.Width - dayAttr.strSize.Width) / 2 + settingData.DayStrOffsetX;
				int strY = posY + (dayCellSize.Height - dayAttr.strSize.Height) / 2 + settingData.DayStrOffsetY;
				DrawString(dayAttr.sDay, settingData.FontDay, color, strX, strY, g, brushShadow);
			}
			posY += dayCellSize.Height;

			return posY;
		}

		//文字列を描画する
		private void DrawString(string str, Font font, Color color, int x, int y, Graphics g, SolidBrush brushShadow)
		{
			//影を付ける
			switch (settingData.EffectShadow)
			{
			case EEffectShadow.RightBottom:
				for (int sx = x, sy = y, w = 0; w < settingData.EffectShadowWidth; w++, sx++, sy++)
				{
					g.DrawString(str, font, brushShadow, sx + 1, sy + 0);
					g.DrawString(str, font, brushShadow, sx + 1, sy + 1);
					g.DrawString(str, font, brushShadow, sx + 0, sy + 1);
				}
				break;

			case EEffectShadow.Round:
				for (int dy = -settingData.EffectShadowWidth; dy <= settingData.EffectShadowWidth; dy++)
				{
					for (int dx = -settingData.EffectShadowWidth; dx <= settingData.EffectShadowWidth; dx++)
					{
						g.DrawString(str, font, brushShadow, x + dx, y + dy);
					}
				}
				break;

			default: break;
			}

			//文字列を描画する
			using (SolidBrush brush = new SolidBrush(color))
			{
				g.DrawString(str, font, brush, x, y);
			}
		}

		//「今日」の背景色を塗る
		private void DrawTodayBg(Graphics g, int x, int y, Size cellSize)
		{
			switch (settingData.EffectTodayBg)
			{
			case EEffectTodayBg.FillEllipse: FillEllipse(g, settingData.ColorTodayBg, x, y, cellSize); break;
			case EEffectTodayBg.DrawEllipse: DrawEllipse(g, settingData.ColorTodayBg, x, y, cellSize); break;
			case EEffectTodayBg.FillRectangle: FillRectangle(g, settingData.ColorTodayBg, x, y, cellSize); break;
			case EEffectTodayBg.DrawRectangle: DrawRectangle(g, settingData.ColorTodayBg, x, y, cellSize); break;
			case EEffectTodayBg.FillRoundRect: FillRoundRect(g, settingData.ColorTodayBg, x, y, cellSize); break;
			case EEffectTodayBg.DrawRoundRect: DrawRoundRect(g, settingData.ColorTodayBg, x, y, cellSize); break;
			default: break;
			}
		}

		#region	DrawTodayBg()から呼ばれる、背景効果の関数

		//塗りつぶした円を描画する
		private void FillEllipse(Graphics g, Color color, int cellX, int cellY, Size cellSize)
		{
			int dimeter = Math.Min(cellSize.Width, cellSize.Height);   //直径
			int x = cellX + (cellSize.Width - dimeter) / 2;
			int y = cellY;
			using (SolidBrush brush = new SolidBrush(color))
			{
				g.FillEllipse(brush, x, y, dimeter, dimeter);
			}
		}

		//円の枠線を描画する
		private void DrawEllipse(Graphics g, Color color, int cellX, int cellY, Size cellSize)
		{
			int dimeter = Math.Min(cellSize.Width, cellSize.Height) - settingData.EffectTodayBgWidth;	//直径（線の太さを考慮する）
			int x = cellX + (cellSize.Width - dimeter) / 2;
			int y = cellY + settingData.EffectTodayBgWidth / 2;	//線の太さの外周が表示位置に合うよう調整する
			using (Pen pen = new Pen(color, settingData.EffectTodayBgWidth))
			{
				g.DrawEllipse(pen, x, y, dimeter, dimeter);
			}
		}

		//塗りつぶした四角形を描画する
		private void FillRectangle(Graphics g, Color color, int cellX, int cellY, Size cellSize)
		{
			int x = cellX;
			int y = cellY;
			int w = cellSize.Width;
			int h = cellSize.Height;
			using (SolidBrush brush = new SolidBrush(color))
			{
				g.FillRectangle(brush, x, y, w, h);
			}
		}

		//四角形の枠線を描画する
		private void DrawRectangle(Graphics g, Color color, int cellX, int cellY, Size cellSize)
		{
			int x = cellX + settingData.EffectTodayBgWidth / 2;
			int y = cellY + settingData.EffectTodayBgWidth / 2;
			int w = cellSize.Width - settingData.EffectTodayBgWidth;
			int h = cellSize.Height - settingData.EffectTodayBgWidth;
			using (Pen pen = new Pen(color, settingData.EffectTodayBgWidth))
			{
				g.DrawRectangle(pen, x, y, w, h);
			}
		}

		//塗りつぶした角丸四角形を描画する
		private void FillRoundRect(Graphics g, Color color, int cellX, int cellY, Size cellSize)
		{
			int x = cellX;
			int y = cellY;
			int w = cellSize.Width;
			int h = cellSize.Height;
			using (SolidBrush brush = new SolidBrush(color))
			{
				//startAngleは3時の方向が角度0度。そこから時計回りにsweepAngle(度)。
				//円弧描画関数というものは精度が悪く、角度の範囲によらず点対称にならないので、微調整が必要。
				//・角度や円弧の外接四角形を微妙に大きくするなど。
				int radius = Math.Min(cellSize.Width, cellSize.Height) / 4;
				int dimeter = radius * 2;
				g.FillPie(brush, x, y, dimeter, dimeter, 0, 360);	//左上
				g.FillPie(brush, x + w - dimeter - 1, y, dimeter + 1, dimeter + 1, 0, 360);	//右上
				g.FillPie(brush, x + w - dimeter - 2, y + h - dimeter - 2, dimeter + 2, dimeter + 2, 0, 360);	//右下
				g.FillPie(brush, x, y + h - dimeter, dimeter, dimeter, 0, 360);	//左下

				g.FillRectangle(brush, x + radius, y, w - dimeter, h);
				g.FillRectangle(brush, x, y + radius, w, h - dimeter);
			}
		}

		//角丸四角形の枠線を描画する
		private void DrawRoundRect(Graphics g, Color color, int cellX, int cellY, Size cellSize)
		{
			int x = cellX + settingData.EffectTodayBgWidth / 2;
			int y = cellY + settingData.EffectTodayBgWidth / 2;
			int w = cellSize.Width - settingData.EffectTodayBgWidth;
			int h = cellSize.Height - settingData.EffectTodayBgWidth;
			using (Pen pen = new Pen(color, settingData.EffectTodayBgWidth))
			{
				//startAngleは3時の方向が角度0度。そこから時計回りにsweepAngle(度)。
				//円弧描画関数というものは精度が悪く、角度の範囲によらず点対称にならないので、微調整が必要。
				//・角度や円弧の外接四角形を微妙に大きくするなど。
				int radius = Math.Min(cellSize.Width, cellSize.Height) / 4;
				int dimeter = radius * 2;

				g.DrawArc(pen, x, y, dimeter, dimeter, 180 - 1, 92);	//左上
				g.DrawArc(pen, x + w - dimeter - 1, y, dimeter + 1, dimeter + 1, 270 - 1, 92);	//右上
				g.DrawArc(pen, x + w - dimeter - 2, y + h - dimeter - 2, dimeter + 2, dimeter + 2, 0 - 1, 92);	//右下
				g.DrawArc(pen, x, y + h - dimeter, dimeter, dimeter, 90 - 1, 92);	//左下

				g.DrawLine(pen, x + radius, y, x + w - radius + 1, y);	//上辺
				g.DrawLine(pen, x + radius, y + h, x + w - radius + 1, y + h);	//下辺
				g.DrawLine(pen, x, y + radius, x, y + h - radius + 1);	//左辺
				g.DrawLine(pen, x + w, y + radius, x + w, y + h - radius + 1);	//右辺
			}
		}

		#endregion

		//年月タイトル部分の文字列を取得する
		//・ユーザーフォーマットに年月を埋め込んだ文字列。
		public string GetYearMonthTitle(string fmt, int year, int month)
		{
			if (string.IsNullOrEmpty(fmt)) { return null; }
			DateTime dt = new DateTime(year, month, 1);
			fmt = fmt.Replace(@"\", @"\\").Replace(@"%", @"\%").Replace(@"'", @"\'").Replace("\"", "\\\"");	//エスケープ処理「\」「%」「'」「"」
			//fmt = fmt.Replace("jj", (dt.Year % 100 + 12).ToString());	//和暦=西暦2桁+12	※平成
			fmt = fmt.Replace("jj", (dt.Year - 2018).ToString());		//和暦=西暦-2018	※令和（西暦2019年が令和元年）
			fmt = fmt.Replace('m', 'M');
			return dt.ToString(fmt, DateTimeFormatInfo.InvariantInfo);
		}

		//その日が今日か
		private bool IsToday(DayAttribute dayAttr)
		{
			DateTime dtToday = DateTime.Today;
			return	(DayAttribute.Year == dtToday.Year) &&
					(DayAttribute.Month == dtToday.Month) &&
					(dayAttr.day == dtToday.Day);
		}

		//その日が祝日か
		private bool IsHoliday(DayAttribute dayAttr, List<int> holidayList)
		{
			return holidayList.Contains(dayAttr.day);
		}

		//その日がユーザー指定の特別日か
		private bool IsSpecialDay(DayAttribute dayAttr)
		{
			string[] WeekNameListJp = WeekNameList[1];
			return	settingMgr.IsSpecialDay(DayAttribute.Month, dayAttr.day) ||
					settingMgr.IsSpecialDay(DayAttribute.Month, dayAttr.weekCount, WeekNameListJp[dayAttr.weekIndex]);
		}
		
	}	//class
}	//namespace
