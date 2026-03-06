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
}

#endif