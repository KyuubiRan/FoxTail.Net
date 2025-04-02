using System.Runtime.CompilerServices;
using System.Text;

namespace FoxTail.Extensions;

#if !FTE_STRING_DISABLED

public static class StringExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] ToByteArray(this string str, Encoding? enc = null)
    {
        return (enc ?? Encoding.UTF8).GetBytes(str);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] ToByteArray(this string str, int index, int count, Encoding? enc = null)
    {
        return (enc ?? Encoding.UTF8).GetBytes(str, index, count);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ByteArrayToString(this byte[] bytes, Encoding? enc = null)
    {
        return (enc ?? Encoding.UTF8).GetString(bytes);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ByteArrayToString(this byte[] bytes, int index, int count, Encoding? enc = null)
    {
        return (enc ?? Encoding.UTF8).GetString(bytes, index, count);
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

#endif
