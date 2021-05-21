using System;
using System.Globalization;

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
            // Specify the year, month, and date
            var dt1 = new DateTime(2018, 6, 5);
            // Specify year, month, date & time
            var dt2 = new DateTime(2018, 6, 5, 7, 49, 40);

            Console.WriteLine(dt1);
            Console.WriteLine(dt2);

            // Current date
            var today = DateTime.Today;
            // Current date & time
            var now = DateTime.Now;

            Console.WriteLine("Today : {0}", today);
            Console.WriteLine("Now   : {0}", now);
            Console.WriteLine();
        }

        public void DateTimeProperty()
        {
            var now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;
            int hour = now.Hour;
            int minute = now.Minute;
            int second = now.Second;
            int millisecond = now.Millisecond;

            Console.WriteLine("Year:{0}, Month:{1}, Day:{2}", year, month, day);
            Console.WriteLine("Hour:{0}, Minute:{1}, Second:{2}, Millisecond:{3}", hour, minute, second, millisecond);
            Console.WriteLine();
        }

        // Get the day of the week
        public void GetDayOfWeek()
        {
            var today = DateTime.Today;
            DayOfWeek dayOfWeek = today.DayOfWeek;
            Console.WriteLine("Today is {0}",dayOfWeek);
            Console.WriteLine();
        }

        // Determination of leap year
        public void LeapYear()
        {
            var now = DateTime.Now;
            int year = now.Year;
            var isLeapYear = DateTime.IsLeapYear(year);
            if (isLeapYear)
                Console.WriteLine("The year {0} is a leap year.", year);
            else
                Console.WriteLine("The year {0} is not a leap year.", year);
            Console.WriteLine();
        }

        // Convert Japanese calendar
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

            DateTime dt5;
            if (DateTime.TryParse("令和2年8月9日", out dt5))
                Console.WriteLine(dt5);

            Console.WriteLine();
        }

        // Convert to Japanese calendar
        public void japaneseCalender()
        {
            // Heisei period
            var date1 = new DateTime(2001, 6, 4);
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str1 = date1.ToString("ggyy年M月d日", culture);
            Console.WriteLine(str1);

            // Reiwa period
            var date2 = new DateTime(2020, 12, 30);
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str2 = date2.ToString("ggyy年M月d日", culture);
            Console.WriteLine(str2);
            Console.WriteLine();
        }

        // Find 2 hours, 8 minutes, 20 seconds later
        public void AddTimeSpan()
        {
            var now = DateTime.Now;
            var future = now + new TimeSpan(2, 8, 20);
            Console.WriteLine(future);
            Console.WriteLine();
        }

        // Asking for age
        public void GetYourAge()
        {
            // Enter your birthday (Sample Value)
            var birthday = new DateTime(1970, 1, 1);
            var today = DateTime.Today;
            int age = GetAge(birthday, today);
            Console.WriteLine("Your age is {0}.", age);
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