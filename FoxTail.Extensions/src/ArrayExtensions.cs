using System.Runtime.CompilerServices;

namespace FoxTail.Extensions;

public static class ArrayExtensions
{
    extension<T>(T[]? array)
    {
        /// <summary>
        /// Returns an empty array if the array is null.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T[] OrEmpty()
        {
            return array ?? [];
        }
    }
}