using System;
using System.Globalization;
using NodaTime;
using NodaTime.Calendars;
using NodaTime.Extensions;

namespace LtuLunch.Server.services
{
    public class WeekService
    {
        public int GetCurrentWeek()
        {
            var now = SystemClock.Instance.InUtc();

            var today = now.GetCurrentDate();
            
            return WeekYearRules.FromCalendarWeekRule(CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                .GetWeekYear(today);
        }

        public int GetWeekByLocalDate(LocalDate localDate) =>
            WeekYearRules.FromCalendarWeekRule(CalendarWeekRule.FirstDay, DayOfWeek.Monday).GetWeekYear(localDate);
    }
}

