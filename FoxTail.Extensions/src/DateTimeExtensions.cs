using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

public static class DateTimeExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsMonday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Monday;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsTuesday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Tuesday;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWednesday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Wednesday;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsThursday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Thursday;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsFriday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Friday;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSaturday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Saturday;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSunday(this DateTime dateTime) => dateTime.DayOfWeek == DayOfWeek.Sunday;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWeekend(this DateTime dateTime) => dateTime.IsSaturday() || dateTime.IsSunday();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsWeekday(this DateTime dateTime) => !dateTime.IsWeekend();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsLeapYear(this DateTime dateTime) => DateTime.IsLeapYear(dateTime.Year);
}