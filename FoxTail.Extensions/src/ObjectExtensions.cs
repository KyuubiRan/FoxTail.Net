using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

public static class ObjectExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNull(this object? obj)
    {
        return obj == null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once InconsistentNaming
    public static R Let<T, R>(this T it, Func<T, R> func)
    {
        return func(it);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Also<T>(this T it, Action<T> action)
    {
        action(it);
        return it;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Cast<T>(this object obj)
    {
        return (T) obj;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? CastOrDefault<T>(this object obj)
    {
        return obj is T t ? t : default;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? CastOrNull<T>(this object obj) where T : class
    {
        return obj as T;
    }
}