using System;
using System.Globalization;

namespace LtuLunch.Server.services
{
    public class WeekService
    {
        public int GetCurrentWeek() =>
            CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
    
        public int GetWeekByDateOnly(DateOnly dateOnly) => 
            CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateOnly.ToDateTime(new TimeOnly(0)), CalendarWeekRule.FirstDay, DayOfWeek.Monday);
    }
}

