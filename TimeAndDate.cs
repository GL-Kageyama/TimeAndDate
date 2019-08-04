using System;
using System.Globalization;

// This Code is need a mono.

namespace TimeAndDate
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var TimeDateObj = new TimeDateClass();

			TimeDateObj.CreateDateTime();

			TimeDateObj.DateTimeProperty();

			TimeDateObj.GetDayOfWeek();

			TimeDateObj.LeapYear();

			TimeDateObj.StringToDateTime();

			TimeDateObj.japaneseCalender();

			TimeDateObj.AddTimeSpan();

			TimeDateObj.GetYourAge();
		} 
	}

	class TimeDateClass
	{
		public void CreateDateTime()
		{
			// 年月日を指定
			var dt1 = new DateTime(2018, 6, 5);
			// 年月日＆時刻を指定
			var dt2 = new DateTime(2018, 6, 5, 7, 49, 40);

			Console.WriteLine(dt1);
			Console.WriteLine(dt2);

			// 現在の日付
			var today = DateTime.Today;
			// 現在の日付＆時刻
			var now = DateTime.Now;

			Console.WriteLine("Today : {0}", today);
			Console.WriteLine("Now   : {0}", now);
			Console.WriteLine();
		}

		public void DateTimeProperty()
		{
			var now         = DateTime.Now;    //現在の日時時刻を取得
			int year        = now.Year;        // 年
			int month       = now.Month;       // 月 
			int day         = now.Day;         // 日
			int hour        = now.Hour;        // 時
			int minute      = now.Minute;      // 分
			int second      = now.Second;      // 秒
			int millisecond = now.Millisecond; // 1/1000秒
			Console.WriteLine("{0}年 {1}月 {2}日", year, month, day);
			Console.WriteLine("{0}時 {1}分 {2}秒 {3}ミリ秒", hour, minute, second, millisecond);
			Console.WriteLine();
		}

		// 曜日を取得
		public void GetDayOfWeek()
		{
			var today = DateTime.Today;
			DayOfWeek dayOfWeek = today.DayOfWeek;
			Console.WriteLine("Today is {0}",dayOfWeek);
			Console.WriteLine();
		}

		// 閏年の判定
		public void LeapYear()
		{
			var now = DateTime.Now;
			int year = now.Year;
			var isLeapYear = DateTime.IsLeapYear(year);
			if (isLeapYear)
				Console.WriteLine("{0}年は閏年です", year);
			else
				Console.WriteLine("{0}年は閏年ではありません", year);
			Console.WriteLine();
		}

		// 和暦を変換
		public void StringToDateTime()
		{
			DateTime dt1;
			if (DateTime.TryParse("明治26年3月2日", out dt1))
				Console.WriteLine(dt1);

			DateTime dt2;
			if (DateTime.TryParse("大正2年5月1日", out dt2))
				Console.WriteLine(dt2);

			DateTime dt3;
			if (DateTime.TryParse("昭和40年10月5日", out dt3))
				Console.WriteLine(dt3);

			DateTime dt4;
			if (DateTime.TryParse("平成2年12月20日", out dt4))
				Console.WriteLine(dt4);

			// 令和は変換できない（Versionに依存する）
			DateTime dt5;
			if (DateTime.TryParse("令和2年8月9日", out dt5))
				Console.WriteLine(dt5);

			Console.WriteLine();
		}

		// 和暦に変換
		public void japaneseCalender()
		{
			// 平成の期間
			var date1 = new DateTime(2001, 6, 4);
			var culture = new CultureInfo("ja-JP");
			culture.DateTimeFormat.Calendar = new JapaneseCalendar();
			var str1 = date1.ToString("ggyy年M月d日", culture);
			Console.WriteLine(str1);

			// 令和の期間　しかし平成のまま
			var date2 = new DateTime(2020, 12, 30);
			culture.DateTimeFormat.Calendar = new JapaneseCalendar();
			var str2 = date2.ToString("ggyy年M月d日", culture);
			Console.WriteLine(str2);
			Console.WriteLine();
		}

		// 2時間8分20秒後を求める
		public void AddTimeSpan()
		{
			var now = DateTime.Now;
			var future = now + new TimeSpan(2, 8, 20);
			Console.WriteLine(future);
			Console.WriteLine();
		}

		// 年齢を求める
		public void GetYourAge()
		{
			// 誕生日を入力
			var birthday = new DateTime(1985, 6, 1);
			var today = DateTime.Today;
			int age = GetAge(birthday, today);
			Console.WriteLine("年齢は{0}歳です", age);
			Console.WriteLine();
		}

		public static int GetAge(DateTime birthday, DateTime targetDay)
		{
			var age = targetDay.Year - birthday.Year;
			if (targetDay < birthday.AddYears(age))
			{
				age--;
			}
			return age;
		}
	}
}

