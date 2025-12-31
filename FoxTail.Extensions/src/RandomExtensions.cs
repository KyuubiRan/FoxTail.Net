using System.Runtime.InteropServices;

namespace FoxTail.Extensions;

#if !FTE_RANDOM_DISABLED

public static class RandomExtensions
{
    /// <param name="random">The random instance.</param>
    extension(Random random)
    {
        /// <summary>Returns a non-negative random single single-precision floating-point number that is less than the specified maximum.</summary>
        /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0.</param>
        /// <returns>
        /// A single-precision floating-point number that is greater than or equal to 0, and less than <paramref name="max"/>; that is, the range of return values ordinarily
        /// includes 0 but not <paramref name="max"/>. However, if <paramref name="max"/> equals 0, will return 0.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="max"/> is less than 0.</exception>
        public float NextSingle(float max)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(max, nameof(max));
            return random.NextSingle() * max;
        }

        /// <summary>
        /// Returns a random single-precision floating-point number that is within a specified range.
        /// </summary>
        /// <param name="min">The inclusive lower bound of the random number returned.</param>
        /// <param name="max">The exclusive upper bound of the random number returned.</param>
        /// <returns>A single-precision floating point number that is greater than or equal to <paramref name="min"/>, and less than <paramref name="max"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="max"/> is less than <paramref name="min"/></exception>
        public float NextSingle(float min, float max)
        {
            if (min > max) throw new ArgumentException("Min value must be less than max value.");
            return random.NextSingle() * (max - min) + min;
        }

        /// <summary>Returns a non-negative random single double-precision floating-point number that is less than the specified maximum.</summary>
        /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0.</param>
        /// <returns>
        /// A double-precision floating-point number that is greater than or equal to 0, and less than <paramref name="max"/>; that is, the range of return values ordinarily
        /// includes 0 but not <paramref name="max"/>. However, if <paramref name="max"/> equals 0, will return 0.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="max"/> is less than 0.</exception>
        public double NextDouble(double max)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(max, nameof(max));
            return random.NextDouble() * max;
        }

        /// <summary>
        /// Returns a random double-precision floating-point number that is within a specified range.
        /// </summary>
        /// <param name="min">The inclusive lower bound of the random number returned.</param>
        /// <param name="max">The exclusive upper bound of the random number returned.</param>
        /// <returns>A double-precision floating point number that is greater than or equal to <paramref name="min"/>, and less than <paramref name="max"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="max"/> is less than <paramref name="min"/></exception>
        public double NextDouble(double min, double max)
        {
            if (min > max) throw new ArgumentException("Min value must be less than max value.");
            return random.NextDouble() * (max - min) + min;
        }

        /// <summary>Returns a random integer that is within a specified range.</summary>
        /// <param name="range">The range of the random number returned.</param>
        /// <returns>
        /// A 32-bit signed integer in the <paramref name="range"/>;
        /// </returns>
        public int Next(Range range)
        {
            return random.Next(range.Start.Value, range.End.Value);
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// See also <see cref="Random.Shuffle{T}(System.Span{T})"/>.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <typeparam name="T">Element type.</typeparam>
        /// <returns>Shuffled list.</returns>
        public List<T> Shuffle<T>(List<T>? list)
        {
            if (list == null)
                return [];
            if (list.Count == 0)
                return list;

            var span = CollectionsMarshal.AsSpan(list);
            random.Shuffle(span);
            return list;
        }
    }
}

#endif