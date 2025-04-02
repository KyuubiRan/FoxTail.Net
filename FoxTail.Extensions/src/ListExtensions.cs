using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FoxTail.Extensions;

#if !FTE_LIST_DISABLED

public static class ListExtensions
{
    /// <summary>
    /// Marshal a List to a Span without copying the data.
    /// See also <see cref="CollectionsMarshal.AsSpan{T}"/>.
    /// </summary>
    /// <param name="list">The list</param>
    /// <typeparam name="T">Element type</typeparam>
    /// <returns>Span of the list</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Span<T> AsSpan<T>(this List<T> list) => CollectionsMarshal.AsSpan(list);

    /// <summary>
    /// Shuffle this list without copying the data.
    /// </summary>
    /// <param name="list">The list</param>
    /// <param name="rng">The random instance, or if null use <see cref="Random.Shared"/></param>
    /// <typeparam name="T">Element Type</typeparam>
    /// <returns>Shuffled list</returns>
    public static List<T> Shuffle<T>(this List<T> list, Random? rng = null)
    {
        if (list.Count == 0)
            return list;

        rng ??= Random.Shared;
        var span = CollectionsMarshal.AsSpan(list);
        rng.Shuffle(span);
        return list;
    }
}

#endif