using System.Runtime.CompilerServices;

namespace FoxTail.Common.Exceptions;

public static class ArgumentExceptionUtils
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIf(bool val, string? message = null)
    {
        if (val) throw new ArgumentException(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIf(Func<bool> func, string? message = null)
    {
        if (func()) throw new ArgumentException(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNot(bool val, string? message = null)
    {
        if (!val) throw new ArgumentException(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNot(Func<bool> func, string? message = null)
    {
        if (!func()) throw new ArgumentException(message);
    }
}