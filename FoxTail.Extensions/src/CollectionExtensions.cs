#if !FTE_COLLECTION_DISABLED
// ReSharper disable ConvertToExtensionBlock

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FoxTail.Extensions;

public static class CollectionExtensions
{
#if NET10_0_OR_GREATER && !FTE_DISABLE_PROPERTY_EXTENSIONS
    extension(ICollection collection)
    {
        public bool IsEmpty => collection.Count == 0;
        public bool IsNotEmpty => collection.Count != 0;
    }
#else
    public static bool IsEmpty(this ICollection collection) => collection.Count == 0;
    public static bool IsNotEmpty(this ICollection collection) => collection.Count != 0;
#endif

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
        return source.Select(x =>
        {
            action(x);
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

    public static IEnumerable<TElement> OnEach<TElement>(this IEnumerable<TElement> source, Action<TElement, int> action)
    {
        return source.Select((x, i) =>
        {
            action(x, i);
            return x;
        });
    }

    public static IEnumerable<(TElement, int)> Indexed<TElement>(this IEnumerable<TElement> source) => source.Select((x, i) => (x, i));

    public static string JoinToString<TElement>(this IEnumerable<TElement> source, string separator) =>
        string.Join(separator, source);

    public static string JoinToString<TElement>(this IEnumerable<TElement> source, char separator) => string.Join(separator, source);

    public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> source, Action<TKey, TValue> action)
    {
        foreach (var item in source)
        {
            action(item.Key, item.Value);
        }
    }

    public static IEnumerable<KeyValuePair<TKey, TValue>> OnEach<TKey, TValue>(this IDictionary<TKey, TValue> source, Action<TKey, TValue> action)
    {
        return source.Select(x =>
        {
            action(x.Key, x.Value);
            return x;
        });
    }
}

#endif