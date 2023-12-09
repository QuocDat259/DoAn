using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.Write("Nhập năm: ");
        int selectedYear;
        while (!int.TryParse(Console.ReadLine(), out selectedYear))
        {
            Console.Write("Nhập lại năm là một số nguyên: ");
        }

        Console.Write("Nhập tuần: ");
        int selectedWeek;
        while (!int.TryParse(Console.ReadLine(), out selectedWeek))
        {
            Console.Write("Nhập lại tuần là một số nguyên: ");
        }

        DateTime startOfWeek = GetStartOfWeek(selectedYear, selectedWeek);

        Console.WriteLine($"Ngày bắt đầu của tuần {selectedWeek} trong năm {selectedYear} là: {startOfWeek:yyyy-MM-dd}");
    }

    private static DateTime GetStartOfWeek(int year, int week)
    {
        GregorianCalendar calendar = new GregorianCalendar();
        DateTime jan1 = new DateTime(year, 1, 1);
        DateTime startOfWeek = calendar.ToDateTime(year, 1, 1, 0, 0, 0, 0).AddDays((week - 1) * 7 - (int)calendar.GetDayOfWeek(jan1) + (int)DayOfWeek.Monday);
        return startOfWeek;
    }
}
