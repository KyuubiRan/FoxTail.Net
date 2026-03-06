#if !FTE_OBJECT_DISABLED
// ReSharper disable ConvertToExtensionBlock

using System;

namespace FoxTail.Extensions;

public static class ObjectExtensions
{
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
    extension(object? obj)
    {
        public bool IsNull => obj == null;
        public bool IsNotNull => obj != null;
    }
#else
    public static bool IsNull(this object? obj) => obj == null;
    public static bool IsNotNull(this object? obj) => obj != null;
#endif

    /// <summary>
    /// Let the object transform to the another object.
    /// </summary>
    /// <param name="it">this object</param>
    /// <param name="func">Transform</param>
    /// <returns>Transformed object</returns>
    // ReSharper disable once InconsistentNaming
    public static R Let<T, R>(this T it, Func<T, R> func) => func(it);

    /// <summary>
    /// Let object do something.
    /// </summary>
    /// <param name="it">this object</param>
    /// <param name="action"></param>
    public static void Let<T>(this T it, Action<T> action) => action(it);

    /// <summary>
    /// Let object do something, then return the itself.
    /// </summary>
    /// <param name="it">this object</param>
    /// <param name="action">Action</param>
    /// <returns>Itself</returns>
    public static T Also<T>(this T it, Action<T> action)
    {
        action(it);
        return it;
    }

    /// <summary>
    /// Take the object if the predicate is true, otherwise return null.
    /// </summary>
    /// <param name="it">this object</param>
    /// <param name="predicate">Predicate</param>
    /// <typeparam name="T">Type</typeparam>
    /// <returns></returns>
    public static T? TakeIf<T>(this T it, Func<T, bool> predicate) where T : class => predicate(it) ? it : null;

    /// <summary>
    /// Take the value object if the predicate is true, otherwise return null.
    /// </summary>
    /// <param name="it">this object</param>
    /// <param name="predicate">Predicate</param>
    /// <typeparam name="T">Type</typeparam>
    /// <returns></returns>
    public static T? TakeIfOrNull<T>(this T it, Func<T, bool> predicate) where T : struct => predicate(it) ? it : null;

    /// <summary>
    /// Cast object to the target type.
    /// </summary>
    /// <returns></returns>
    public static T Cast<T>(this object obj) => (T)obj;

    /// <summary>
    /// Try cast object(class) to the target type, if failed, return null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? CastOrNull<T>(this object obj) where T : class => obj as T;
}

#endif