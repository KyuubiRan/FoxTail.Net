
#if !FTE_DATETIME_DISABLED
// ReSharper disable ConvertToExtensionBlock

using System;

namespace FoxTail.Extensions;

public static class DateTimeExtensions
{
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
    extension(DateTime dateTime)
    {
        public bool IsMonday => dateTime.DayOfWeek == DayOfWeek.Monday;
        public bool IsTuesday => dateTime.DayOfWeek == DayOfWeek.Tuesday;
        public bool IsWednesday => dateTime.DayOfWeek == DayOfWeek.Wednesday;
        public bool IsThursday => dateTime.DayOfWeek == DayOfWeek.Thursday;
        public bool IsFriday => dateTime.DayOfWeek == DayOfWeek.Friday;
        public bool IsSaturday => dateTime.DayOfWeek == DayOfWeek.Saturday;
        public bool IsSunday => dateTime.DayOfWeek == DayOfWeek.Sunday;
        public bool IsWeekend => dateTime.IsSaturday || dateTime.IsSunday;
        public bool IsWeekday => !dateTime.IsWeekend;
        public bool IsLeapYear => DateTime.IsLeapYear(dateTime.Year);
        public bool IsToday => dateTime.Date == DateTime.Today;
        public long UnixTimeSeconds => ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
        public long UnixTimeMilliseconds => ((DateTimeOffset)dateTime).ToUnixTimeMilliseconds();
    }
#else
    public static bool IsMonday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Monday;
    public static bool IsTuesday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Tuesday;
    public static bool IsWednesday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Wednesday;
    public static bool IsThursday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Thursday;
    public static bool IsFriday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Friday;
    public static bool IsSaturday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Saturday;
    public static bool IsSunday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Sunday;
    public static bool IsWeekend(this DateTime dateTime) => dateTime.IsSaturday() || dateTime.IsSunday();
    public static bool IsWeekday(this DateTime dateTime) => !dateTime.IsWeekend();
    public static bool IsLeapYear(this DateTime dateTime) => DateTime.IsLeapYear(dateTime.Year);
    public static bool IsToday(this DateTime dateTime) => dateTime.Date == DateTime.Today;
    public static long ToUnixTimeSeconds(this DateTime dateTime) => ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
    public static long ToUnixTimeMilliseconds(this DateTime dateTime) => ((DateTimeOffset)dateTime).ToUnixTimeMilliseconds();
#endif
}

#endif