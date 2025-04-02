using System.Collections;
using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

#if !FTE_COLLECTION_DISABLED

public static class CollectionExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEmpty(this ICollection collection) => collection.Count == 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNotEmpty(this ICollection collection) => collection.Count != 0;

    public static void Collect<TElement>(this IEnumerable<TElement> source)
    {
        using var enumerator = source.GetEnumerator();
        while (enumerator.MoveNext())
        {
            _ = enumerator.Current;
        }
    }

    public static void ForEach<TElement>(this IEnumerable<TElement> source, Action<TElement> action)
    {
        foreach (var item in source)
        {
            action(item);
        }
    }

    public static IEnumerable<TElement> OnEach<TElement>(this IEnumerable<TElement> source, Action<TElement> action)
    {
        return source.Select((x, i) =>
        {
            action(x);
            return x;
        });
    }

    public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> source,
                                             Action<TKey, TValue> action)
    {
        foreach (var item in source)
        {
            action(item.Key, item.Value);
        }
    }

    public static IEnumerable<KeyValuePair<TKey, TValue>> OnEach<TKey, TValue>(this IDictionary<TKey, TValue> source,
                                                                               Action<TKey, TValue> action)
    {
        return source.Select(x =>
        {
            action(x.Key, x.Value);
            return x;
        });
    }

    public static void ForEach<TElement>(this IEnumerable<TElement> source, Action<TElement, int> action)
    {
        var i = -1;
        foreach (var item in source)
        {
            checked
            {
                ++i;
            }

            action(item, i);
        }
    }

    public static IEnumerable<TElement> OnEach<TElement>(this IEnumerable<TElement> source,
                                                         Action<TElement, int> action)
    {
        return source.Select((x, i) =>
        {
            action(x, i);
            return x;
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string JoinToString<T>(this IEnumerable<T> source, string separator) =>
        string.Join(separator, source);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string JoinToString<T>(this IEnumerable<T> source, char separator) => string.Join(separator, source);
}

#endif