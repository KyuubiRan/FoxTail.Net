#if !FTE_STRING_DISABLED
// ReSharper disable ConvertToExtensionBlock

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FoxTail.Extensions;

/// <summary>
/// Notice: Since version >= 0.2.0: IsNullOrEmpty and IsNullOrWhiteSpace are renamed to IsEmptyOrNull and IsWhiteSpaceOrNull to avoid conflict std lib methods.
/// </summary>
public static class StringExtensions
{
    public static byte[] ToByteArray(this string str, Encoding? enc = null) => (enc ?? Encoding.UTF8).GetBytes(str);
    public static byte[] ToByteArray(this string str, int index, int count, Encoding? enc = null) => (enc ?? Encoding.UTF8).GetBytes(str, index, count);

#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
    extension([NotNullWhen(false)] string? value)
    {
        public bool IsEmptyOrNull => string.IsNullOrEmpty(value);
        public bool IsWhiteSpaceOrNull => string.IsNullOrWhiteSpace(value);
    }
#else
    public static bool IsEmptyOrNull([NotNullWhen(false)] this string? value) => string.IsNullOrEmpty(value);
    public static bool IsWhiteSpaceOrNull([NotNullWhen(false)] this string? value) => string.IsNullOrWhiteSpace(value);
#endif

    [return: NotNullIfNotNull(nameof(replaced))]
    public static string? IfEmptyOrNull(this string? value, string? replaced) => string.IsNullOrEmpty(value) ? replaced : value;

    public static string? IfEmptyOrNull(this string? value, Func<string?> replaced) => string.IsNullOrEmpty(value) ? replaced() : value;

    [return: NotNullIfNotNull(nameof(replaced))]
    public static string? IfWhiteSpaceOrNull(this string? value, string? replaced) => string.IsNullOrWhiteSpace(value) ? replaced : value;

    public static string? IfWhiteSpaceOrNull(this string? value, Func<string?> replaced) => string.IsNullOrWhiteSpace(value) ? replaced() : value;

    public static string ByteArrayToString(this byte[] bytes, Encoding? enc = null) => (enc ?? Encoding.UTF8).GetString(bytes);

    public static string ByteArrayToString(this byte[] bytes, int index, int count, Encoding? enc = null) =>
        (enc ?? Encoding.UTF8).GetString(bytes, index, count);

    /// <summary>
    /// Rename to `IsDigitChar` to avoid conflict with `char.IsDigit`
    /// </summary>
    /// <param name="c"></param>

// Net 10 property extensions support        
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
    extension(char c)
    {
        public bool IsDigitChar => char.IsDigit(c);
    }
#else
    public static bool IsDigitChar(this char c) => char.IsDigit(c);
#endif

    /// <summary>
    /// Rename to `Fmt` to avoid conflict with `string.Format`
    /// </summary>
    /// <param name="format"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string Fmt([StringSyntax("CompositeFormat")] this string format, params object?[] args)
    {
        return string.Format(format, args);
    }
}

#endif