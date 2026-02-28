using System;

public static class DateHelper
{
    public static bool IsWeekend(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
    }

    public static int DaysUntil(DateTime from, DateTime to)
    {
        return Math.Abs((to - from).Days);
    }
}
