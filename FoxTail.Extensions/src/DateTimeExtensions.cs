using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

#if !FTE_DATETIME_DISABLED

public static class DateTimeExtensions
{
    extension(DateTime dateTime)
    {
// Net 10 property extensions support
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
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
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsMonday() => dateTime.DayOfWeek == DayOfWeek.Monday;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsTuesday() => dateTime.DayOfWeek == DayOfWeek.Tuesday;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsWednesday() => dateTime.DayOfWeek == DayOfWeek.Wednesday;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsThursday() => dateTime.DayOfWeek == DayOfWeek.Thursday;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsFriday() => dateTime.DayOfWeek == DayOfWeek.Friday;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSaturday() => dateTime.DayOfWeek == DayOfWeek.Saturday;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSunday() => dateTime.DayOfWeek == DayOfWeek.Sunday;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsWeekend() => dateTime.IsSaturday() || dateTime.IsSunday();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsWeekday() => !dateTime.IsWeekend();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsLeapYear() => DateTime.IsLeapYear(dateTime.Year);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsToday() => dateTime.Date == DateTime.Today;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long ToUnixTimeSeconds()
        {
            return ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long ToUnixTimeMilliseconds()
        {
            return ((DateTimeOffset)dateTime).ToUnixTimeMilliseconds();
        }
#endif
    }
}

#endif