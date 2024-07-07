using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

public static class ObjectExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNull(this object? obj)
    {
        return obj == null;
    }

    /// <summary>
    /// Let the object transform to the another object.
    /// </summary>
    /// <param name="it">This object</param>
    /// <param name="func">Transform</param>
    /// <returns>Transformed object</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    // ReSharper disable once InconsistentNaming
    public static R Let<T, R>(this T it, Func<T, R> func)
    {
        return func(it);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Let<T>(this T it, Action<T> action)
    {
        action(it);
    }

    /// <summary>
    /// Let object do something, then return the itself.
    /// </summary>
    /// <param name="it">This object</param>
    /// <param name="action">Action</param>
    /// <returns>Itself</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Also<T>(this T it, Action<T> action)
    {
        action(it);
        return it;
    }

    /// <summary>
    /// Cast object to the target type.
    /// </summary>
    /// <param name="obj">This object</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T Cast<T>(this object obj)
    {
        return (T)obj;
    }

    /// <summary>
    /// Try cast object(class/struct) to the target type, if failed, return default(class is null) value.
    /// </summary>
    /// <param name="obj">This object</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? CastOrDefault<T>(this object obj)
    {
        return obj is T t ? t : default;
    }

    /// <summary>
    /// Try cast object(class) to the target type, if failed, return null.
    /// </summary>
    /// <param name="obj"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? CastOrNull<T>(this object obj) where T : class
    {
        return obj as T;
    }
}