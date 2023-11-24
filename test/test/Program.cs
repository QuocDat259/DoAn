using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main()
    {
        // Lấy ngày hiện tại
        int nam = 2024;
        DateTime start = Convert.ToDateTime("01/01/" + nam.ToString());

        // Lấy calendar hiện tại (GregorianCalendar)
        GregorianCalendar calendar = new GregorianCalendar();

        // Tạo mảng chứa các tuần
        DateTime[] weeks = GetWeeksInYear(start.Year, calendar);

        // In thông tin về từng tuần
        for (int i = 0; i < weeks.Length; i++)
        {
            Console.WriteLine($"Tuần {i + 1}: {weeks[i].ToString("MM/dd/yyyy")} - {weeks[i].AddDays(6).ToString("MM/dd/yyyy")}");
        }
    }

    static DateTime[] GetWeeksInYear(int year, GregorianCalendar calendar)
    {
        DateTime[] weeks = new DateTime[calendar.GetWeekOfYear(new DateTime(year, 12, 31), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)];

        // Ngày đầu tiên của năm
        DateTime startDate = new DateTime(year, 1, 1);

        // Đếm số ngày đã được thêm vào mảng
        int daysAdded = 0;

        // Duyệt qua từng ngày trong năm
        for (int i = 0; i < 365; i++)
        {
            DateTime currentDate = startDate.AddDays(i);

            // Nếu là ngày đầu tiên của một tuần, thêm vào mảng
            if (currentDate.DayOfWeek == DayOfWeek.Monday)
            {
                weeks[calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) - 1] = currentDate;
                daysAdded++;
            }
        }

        return weeks;
    }
}
