using System;

#if !FTE_ARRAY_DISABLED
// ReSharper disable ConvertToExtensionBlock

namespace FoxTail.Extensions;

public static class ArrayExtensions
{
    /// <summary>
    /// Returns an empty array if the array is null.
    /// </summary>
    /// <returns></returns>
    public static T[] OrEmpty<T>(this T[]? array) => array ?? [];

    /// <summary>
    /// Returns a random element from the array.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="rng">The random instance, or if null use <see cref="Random.Shared"/></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Random<T>(this T[] array, Random? rng = null) => array[(rng ?? System.Random.Shared).Next(0, array.Length)];
}

#endif