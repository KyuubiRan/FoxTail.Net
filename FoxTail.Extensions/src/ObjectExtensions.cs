using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

#if !FTE_OBJECT_DISABLED

public static class ObjectExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNull(this object? obj) => obj == null;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNotNull(this object? obj) => obj != null;

    /// <summary>
    /// Let the object transform to the another object.
    /// </summary>
    /// <param name="it">This object</param>
    /// <param name="func">Transform</param>
    /// <returns>Transformed object</returns>
    // ReSharper disable once InconsistentNaming
    public static R Let<T, R>(this T it, Func<T, R> func)
    {
        return func(it);
    }

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
    /// <param name="obj">This object</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? CastOrNull<T>(this object obj) where T : class
    {
        return obj as T;
    }

    /// <summary>
    /// Take the object if the predicate is true, otherwise return null.
    /// </summary>
    /// <param name="obj">This object</param>
    /// <param name="predicate">Predicate</param>
    /// <typeparam name="T">Type</typeparam>
    /// <returns></returns>
    public static T? TakeIf<T>(this T obj, Func<T, bool> predicate) where T : class
    {
        return predicate(obj) ? obj : null;
    }
}

#endif