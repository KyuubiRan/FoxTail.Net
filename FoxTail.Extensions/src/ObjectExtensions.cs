using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

#if !FTE_OBJECT_DISABLED

public static class ObjectExtensions
{
    extension(object? obj)
    {
// Net 10 property extensions support
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
        public bool IsNull => obj == null;
        public bool IsNotNull => obj != null;
#else
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsNull() => obj == null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsNotNull() => obj != null;
#endif
    }

    /// <param name="it">This object</param>
    extension<T>(T it)
    {
        /// <summary>
        /// Let the object transform to the another object.
        /// </summary>
        /// <param name="func">Transform</param>
        /// <returns>Transformed object</returns>
        // ReSharper disable once InconsistentNaming
        public R Let<R>(Func<T, R> func)
        {
            return func(it);
        }

        /// <summary>
        /// Let object do something.
        /// </summary>
        /// <param name="action"></param>
        public void Let(Action<T> action)
        {
            action(it);
        }

        /// <summary>
        /// Let object do something, then return the itself.
        /// </summary>
        /// <param name="action">Action</param>
        /// <returns>Itself</returns>
        public T Also(Action<T> action)
        {
            action(it);
            return it;
        }

        /// <summary>
        /// Take the object if the predicate is true, otherwise return null or default.
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <typeparam name="T">Type</typeparam>
        /// <returns></returns>
        public T? TakeIf(Func<T, bool> predicate)
        {
            return predicate(it) ? it : default;
        }
    }

    /// <param name="obj">This object</param>
    extension(object obj)
    {
        /// <summary>
        /// Cast object to the target type.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Cast<T>()
        {
            return (T)obj;
        }

        /// <summary>
        /// Try cast object(class/struct) to the target type, if failed, return default(class is null) value.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T? CastOrDefault<T>()
        {
            return obj is T t ? t : default;
        }

        /// <summary>
        /// Try cast object(class) to the target type, if failed, return null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T? CastOrNull<T>() where T : class
        {
            return obj as T;
        }
    }
}

#endif