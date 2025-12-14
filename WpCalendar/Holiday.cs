//2013/04 作成

using System;
using System.Collections.Generic;
using System.Globalization;	//Calendar,CultureInfo

namespace JapaneseCalendar
{
	class Holiday
	{
		#region 固定の祝日のリスト
		private static readonly int[][] FixedHolidayList =
		{
			new int[] { },			//0月:ダミー
			new int[] { 1 },		//1月	元日,（成人の日）
			//new int[] { 11 },		//2月	建国記念の日	//20191214 del
			new int[] { 11, 23 },	//2月	建国記念の日, 天皇誕生（令和）	//20191214 add
			new int[] { },			//3月	（春分の日）
			new int[] { 29 },		//4月	昭和の日
			new int[] { 3, 4, 5 },	//5月	憲法記念日,みどりの日,こどもの日
			new int[] { },			//6月
			new int[] { },			//7月	（海の日）
			new int[] { 11 },		//8月    山の日
			new int[] { },			//9月	（敬老の日）,（秋分の日）
			new int[] { },			//10月	（体育の日）
			new int[] { 3, 23 },	//11月	文化の日,勤労感謝の日
			//new int[] { 23 }		//12月	天皇誕生日（平成）	//20191214 del
			new int[] { }			//12月	//20191214 add
		};
		#endregion

		///<summary>日付が固定の祝日か判定する</summary>
		public static bool IsFixedHoliday(int month, int day)
		{
			if (FixedHolidayList[month].Length == 0) return false;
			foreach (int holiday in FixedHolidayList[month])
				if (holiday == day) return true;
			return false;
		}

		///<summary>変動する祝日（ハッピーマンデー）か判定する</summary>
		public static bool IsVariableHoliday(int year, int month, int day)
		{
			DateTime dt = new DateTime(year, month, day);
			return IsVariableHoliday(month, day, dt.DayOfWeek);
		}
		//
		///<summary>変動する祝日（ハッピーマンデー）か判定する</summary>
		public static bool IsVariableHoliday(int month, int day, DayOfWeek week)
		{
			if (week != DayOfWeek.Monday) { return false; }
			
			int weekCount = (day - 1) / 7 + 1;  //その月の第何回目の曜日か
			if (month == 1 && weekCount == 2) { return true; }  //成人の日	1月の第2月曜日
			if (month == 7 && weekCount == 3) { return true; }  //海の日	7月の第3月曜日
			if (month == 9 && weekCount == 3) { return true; }  //敬老の日	9月の第3月曜日
			if (month == 10 && weekCount == 2) { return true; }	//体育の日	10月の第2月曜日
			return false;
		}

		///<summary>春分の日か判定する</summary>
		public static bool IsVernalEquinoxDay(int year, int month, int day)
		{
			return (month == 3 && GetVernalEquinoxDay(year) == day);
		}

		///<summary>1900年～2099年の 春分の日（3月）の日付を求める</summary>
		//http://ja.wikipedia.org/wiki/%E6%98%A5%E5%88%86%E3%81%AE%E6%97%A5
		public static int GetVernalEquinoxDay(int year)
		{
			if (year < 1900) { return 0; }

			int ymod = year % 4;
			if (ymod == 0)
			{
				if (year <= 1956) { return 21; }
				if (year <= 2088) {return 20; }
				if (year <= 2096) {return 19; }
			}
			if (ymod == 1)
			{
				if (year <= 1989) { return 21; }
				if (year <= 2097) { return 20; }
			}
			if (ymod == 2)
			{
				if (year <= 2022) { return 21; }
				if (year <= 2098) { return 20; }
			}
			if (ymod == 3)
			{
				if (year <= 1923) { return 22; }
				if (year <= 2055) { return 21; }
				if (year <= 2099) { return 20; }
			}

			return 0;
		}

		///<summary>秋分の日か判定する</summary>
		public static bool IsAutumnalEquinoxDay(int year, int month, int day)
		{
			return (month == 9 && GetAutumnalEquinoxDay(year) == day);
		}

		///<summary>1900年～2099年の 秋分の日（9月）の日付を求める</summary>
		//http://ja.wikipedia.org/wiki/%E7%A7%8B%E5%88%86%E3%81%AE%E6%97%A5
		public static int GetAutumnalEquinoxDay(int year)
		{
			if (year < 1900) return 0;

			int ymod = year % 4;
			if (ymod == 0)
			{
				if (year <= 2008) { return 23; }
				if (year <= 2096) { return 22; }
			}
			if (ymod == 1)
			{
				if (year <= 1917) { return 24; }
				if (year <= 2041) { return 23; }
				if (year <= 2097) { return 22; }
			}
			if (ymod == 2)
			{
				if (year <= 1946) { return 24; }
				if (year <= 2074) { return 23; }
				if (year <= 2098) { return 22; }
			}
			if (ymod == 3)
			{
				if (year <= 1979) { return 24; }
				if (year <= 2099) { return 23; }
			}

			return 0;
		}

		///<summary>指定した月の祝日／休日を取得する</summary>
		public static List<int> GetHolidays(int year, int month)
		{
			//固定の祝日
			List<int> holidayList = new List<int>();
			if (0 < FixedHolidayList[month].Length) { holidayList.AddRange(FixedHolidayList[month]); }

			//変動する祝日
			DateTime dt = new DateTime(year, month, 1);
			int firstDayWeek = (int)dt.DayOfWeek;
			Calendar ca = CultureInfo.CurrentCulture.Calendar;
			int lastDay = ca.GetDaysInMonth(year, month);
			for (int d = 1, w = firstDayWeek; d <= lastDay; d++, w = (w + 1) % 7)
			{
				if (IsVariableHoliday(month, d, (DayOfWeek)w) && !holidayList.Contains(d)) { holidayList.Add(d); }
			}

			//春分の日
			if (month == 3)
			{
				int day = GetVernalEquinoxDay(year);
				if (!holidayList.Contains(day)) { holidayList.Add(day); }
			}
			
			//秋分の日
			if (month == 9)
			{
				int day = GetAutumnalEquinoxDay(year);
				if (!holidayList.Contains(day)) { holidayList.Add(day); }
			}

			//日曜が祝日ならその後最初の平日は休日となる（振替休日）
			//・5月の3連続の祝日中に発生する可能性。
			//・現在の祝日法では、ここで求まる休日が翌月にまたぐことはない。当月内のみで判定してよい。
			for (int d = 1, w = firstDayWeek; d <= lastDay; d++, w = (w + 1) % 7)
			{
				if ((DayOfWeek)w != DayOfWeek.Sunday) { continue; }
				if (!holidayList.Contains(d)) { continue; }
				int holiday = d + 1;
				while (holidayList.Contains(holiday)) { holiday++; }
				holidayList.Add(holiday);
			}

			//祝日＋平日＋祝日だった場合、その平日は休日となる（国民の休日）
			//・敬老の日＋平日＋秋分の日 の可能性。
			//・現在の祝日法では、ここで求まる休日が翌月にまたぐことはない。当月内のみで判定してよい。
			for (int d = 1; d <= lastDay; d++)
			{
				if (holidayList.Contains(d) && !holidayList.Contains(d + 1) && holidayList.Contains(d + 2))
				{
					holidayList.Add(d + 1);
					d++;
				}
			}

			holidayList.Sort();
			return holidayList;
		}

	}	//class
}	//namespace
