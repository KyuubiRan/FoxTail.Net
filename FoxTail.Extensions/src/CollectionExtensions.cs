using System.Collections;
using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

public static class CollectionExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEmpty<T>(this ICollection<T> collection) => collection.Count == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNotEmpty<T>(this ICollection<T> collection) => collection.Count != 0;

    public static void ForEach<TElement>(this ICollection<TElement> source, Action<TElement> action)
    {
        foreach (var item in source)
        {
            action(item);
        }
    }

    public static void ForEach<TElement>(this IList<TElement> source, Action<TElement> action)
    {
        foreach (var item in source)
        {
            action(item);
        }
    }

    public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> source,
        Action<TKey, TValue> action)
    {
        foreach (var item in source)
        {
            action(item.Key, item.Value);
        }
    }

    public static IList<TElement> ForEachIndexed<TElement>(this IList<TElement> source, Action<int, TElement> action)
    {
        for (var i = 0; i < source.Count; i++)
        {
            action(i, source[i]);
        }

        return source;
    }

    public static ICollection<TElement> OnEach<TElement>(this ICollection<TElement> source, Action<TElement> action)
    {
        foreach (var item in source)
        {
            action(item);
        }

        return source;
    }

    public static IList<TElement> OnEach<TElement>(this IList<TElement> source, Action<TElement> action)
    {
        foreach (var item in source)
        {
            action(item);
        }

        return source;
    }

    public static IDictionary<TKey, TValue> OnEach<TKey, TValue>(this IDictionary<TKey, TValue> source,
        Action<TKey, TValue> action)
    {
        foreach (var item in source)
        {
            action(item.Key, item.Value);
        }

        return source;
    }

    public static IList<TElement> OnEachIndexed<TElement>(this IList<TElement> source, Action<int, TElement> action)
    {
        for (var i = 0; i < source.Count; i++)
        {
            action(i, source[i]);
        }

        return source;
    }
}