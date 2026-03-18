#if !FTE_LIST_DISABLED
// ReSharper disable ConvertToExtensionBlock

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FoxTail.Extensions;

public static class ListExtensions
{
    /// <summary>
    /// Marshal a List to a Span without copying the data.
    /// See also <see cref="CollectionsMarshal.AsSpan{T}"/>.
    /// </summary>
    /// <returns>Span of the list</returns>
    public static Span<T> AsSpan<T>(this List<T> list) => CollectionsMarshal.AsSpan(list);

    /// <summary>
    /// Shuffle this list without copying the data.
    /// </summary>
    /// <param name="list"></param>
    /// <param name="rng">The random instance, or if null use <see cref="Random.Shared"/></param>
    /// <returns>Shuffled list</returns>
    public static List<T> Shuffle<T>(this List<T> list, Random? rng = null)
    {
        if (list.Count == 0)
            return list;

        var span = CollectionsMarshal.AsSpan(list);
        (rng ?? System.Random.Shared).Shuffle(span);
        return list;
    }

    public static List<T> OrEmpty<T>(this List<T>? list) => list ?? [];

    /// <summary>
    /// Returns a random element from the list.
    /// </summary>
    /// <param name="list"></param>
    /// <param name="rng">The random instance, or if null use <see cref="Random.Shared"/></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Random<T>(this List<T> list, Random? rng = null) => list[(rng ?? System.Random.Shared).Next(0, list.Count)];
}

#endif