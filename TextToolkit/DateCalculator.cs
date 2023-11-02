using System;

namespace TextToolkit
{
    public class DateCalculator
    {
        public int CalculateDaysBetweenDates(DateTime startDate, DateTime endDate)
        {
            return (int)(endDate - startDate).TotalDays;
        }

        public DateTime AddDaysToDate(DateTime date, int numberOfDays)
        {
            return date.AddDays(numberOfDays);
        }

        public DateTime AddBusinessDays(DateTime date, int numberOfDays)
        {
            var result = date;
            for (int i = 0; i < numberOfDays; i++)
            {
                result = result.AddDays(1);
                if (result.DayOfWeek == DayOfWeek.Saturday)
                {
                    result = result.AddDays(2);
                }
                else if (result.DayOfWeek == DayOfWeek.Sunday)
                {
                    result = result.AddDays(1);
                }
            }
            return result;
        }

        public bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        public DayOfWeek GetDayOfWeek(DateTime date)
        {
            return date.DayOfWeek;
        }

        public int GetWeekNumberOfYear(DateTime date)
        {
            return new System.Globalization.GregorianCalendar().GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }

        public bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public int GetMonthsDifference(DateTime startDate, DateTime endDate)
        {
            return (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;
        }

        public long ToUnixTime(DateTime date)
        {
            return ((DateTimeOffset)date).ToUnixTimeSeconds();
        }

        public DateTime FromUnixTime(long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;
        }

        public (DateTime startOfWeek, DateTime endOfWeek) GetStartAndEndOfWeek(DateTime date)
        {
            var startOfWeek = date.AddDays(-(int)date.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(6);
            return (startOfWeek, endOfWeek);
        }
    }
}