using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FoxTail.Extensions;

#if !FTE_LIST_DISABLED

public static class ListExtensions
{
    /// <param name="list">The list</param>
    /// <typeparam name="T">Element type</typeparam>
    extension<T>(List<T> list)
    {
        /// <summary>
        /// Marshal a List to a Span without copying the data.
        /// See also <see cref="CollectionsMarshal.AsSpan{T}"/>.
        /// </summary>
        /// <returns>Span of the list</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan() => CollectionsMarshal.AsSpan(list);

        /// <summary>
        /// Shuffle this list without copying the data.
        /// </summary>
        /// <param name="rng">The random instance, or if null use <see cref="Random.Shared"/></param>
        /// <returns>Shuffled list</returns>
        public List<T> Shuffle(Random? rng = null)
        {
            if (list.Count == 0)
                return list;

            rng ??= Random.Shared;
            var span = CollectionsMarshal.AsSpan(list);
            rng.Shuffle(span);
            return list;
        }
    }
}

#endif