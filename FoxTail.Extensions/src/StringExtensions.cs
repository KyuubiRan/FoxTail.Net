using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace FoxTail.Extensions;

#if !FTE_STRING_DISABLED

public static class StringExtensions
{
    extension(string str)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] ToByteArray(Encoding? enc = null)
        {
            return (enc ?? Encoding.UTF8).GetBytes(str);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] ToByteArray(int index, int count, Encoding? enc = null)
        {
            return (enc ?? Encoding.UTF8).GetBytes(str, index, count);
        }
    }

    /// <summary>
    /// Rename to `IsEmptyOrNull` and `IsWhiteSpaceOrNull` avoid conflict `string.IsNullOrEmpty` and `string.IsNullOrWhiteSpace`
    /// </summary>
    /// <param name="value"></param>
    extension([NotNullWhen(false)] string? value)
    {
// Net 10 property extensions support        
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
        public bool IsEmptyOrNull => string.IsNullOrEmpty(value);

        public bool IsWhiteSpaceOrNull => string.IsNullOrWhiteSpace(value);

#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEmptyOrNull()
        {
            return string.IsNullOrEmpty(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsWhiteSpaceOrNull()
        {
            return string.IsNullOrWhiteSpace(value);
        }
#endif
    }

    /// <summary>
    /// Changed the name to `IfNullOrEmpty` and `IfNullOrWhiteSpace` here.
    /// </summary>
    /// <param name="value"></param>
    extension(string? value)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: NotNullIfNotNull(nameof(replaced))]
        public string? IfEmptyOrNull(string? replaced)
        {
            return string.IsNullOrEmpty(value) ? replaced : value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string? IfEmptyOrNull(Func<string?> replaced)
        {
            return string.IsNullOrEmpty(value) ? replaced() : value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: NotNullIfNotNull(nameof(replaced))]
        public string? IfWhiteSpaceOrNull(string? replaced)
        {
            return string.IsNullOrWhiteSpace(value) ? replaced : value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string? IfWhiteSpaceOrNull(Func<string?> replaced)
        {
            return string.IsNullOrWhiteSpace(value) ? replaced() : value;
        }
    }

    extension(byte[] bytes)
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ByteArrayToString(Encoding? enc = null)
        {
            return (enc ?? Encoding.UTF8).GetString(bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ByteArrayToString(int index, int count, Encoding? enc = null)
        {
            return (enc ?? Encoding.UTF8).GetString(bytes, index, count);
        }
    }

    /// <summary>
    /// Rename to `IsDigitChar` to avoid conflict with `char.IsDigit`
    /// </summary>
    /// <param name="c"></param>
    extension(char c)
    {
// Net 10 property extensions support        
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
        public bool IsDigitChar => char.IsDigit(c);

#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsDigitChar()
        {
            return char.IsDigit(c);
        }
#endif
    }


    /// <summary>
    /// Rename to `Fmt` to avoid conflict with `string.Format`
    /// </summary>
    /// <param name="format"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Fmt([StringSyntax("CompositeFormat")] this string format, params object?[] args)
    {
        return string.Format(format, args);
    }
}

#endif