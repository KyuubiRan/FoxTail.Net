using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace FoxTail.Common.Exceptions;

public static class ArgumentExceptionUtils
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIf([DoesNotReturnIf(true)] bool val, string? message = null)
    {
        if (val) throw new ArgumentException(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIf(Func<bool> func, string? message = null)
    {
        if (func()) throw new ArgumentException(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNot([DoesNotReturnIf(false)] bool val, string? message = null)
    {
        if (!val) throw new ArgumentException(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNot(Func<bool> func, string? message = null)
    {
        if (!func()) throw new ArgumentException(message);
    }
}