using System.Runtime.CompilerServices;
using System.Text;

namespace FoxTail.Extensions;

public static class StringExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] ToByteArray(this string str, Encoding? enc = null)
    {
        return (enc ?? Encoding.UTF8).GetBytes(str);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDigit(this char c)
    {
        return char.IsDigit(c);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Format(this string value, params object[] args)
    {
        return string.Format(value, args);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrEmpty(this string? value)
    {
        return string.IsNullOrEmpty(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullOrWhiteSpace(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string IfNullOrEmpty(this string? value, string replaced)
    {
        return string.IsNullOrEmpty(value) ? replaced : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string IfNullOrEmpty(this string? value, Func<string> replaced)
    {
        return string.IsNullOrEmpty(value) ? replaced() : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string IfNullOrWhiteSpace(this string? value, string replaced)
    {
        return string.IsNullOrWhiteSpace(value) ? replaced : value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string IfNullOrWhiteSpace(this string? value, Func<string> replaced)
    {
        return string.IsNullOrWhiteSpace(value) ? replaced() : value;
    }
}