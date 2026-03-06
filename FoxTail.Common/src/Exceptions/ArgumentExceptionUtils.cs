using System.Diagnostics.CodeAnalysis;

namespace FoxTail.Common.Exceptions;

public static class ArgumentExceptionUtils
{
    public static void ThrowIf([DoesNotReturnIf(true)] bool val, string? message = null)
    {
        if (val) throw new ArgumentException(message);
    }

    public static void ThrowIf(Func<bool> func, string? message = null)
    {
        if (func()) throw new ArgumentException(message);
    }

    public static void ThrowIfNot([DoesNotReturnIf(false)] bool val, string? message = null)
    {
        if (!val) throw new ArgumentException(message);
    }

    public static void ThrowIfNot(Func<bool> func, string? message = null)
    {
        if (!func()) throw new ArgumentException(message);
    }
}