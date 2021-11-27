using System;
using System.Globalization;

namespace LtuLunch.Server.services
{
    public class WeekService
    {
        public int GetCurrentWeek() =>
            CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
    
        public int GetWeekByDateTime(DateTime dateTime) => 
            CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
    }
}

