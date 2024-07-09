namespace FoxTail.Extensions;

public static class RandomExtensions
{
    /// <summary>Returns a non-negative random single single-precision floating-point number that is less than the specified maximum.</summary>
    /// <param name="random">The random instance.</param>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0.</param>
    /// <returns>
    /// A single-precision floating-point number that is greater than or equal to 0, and less than <paramref name="max"/>; that is, the range of return values ordinarily
    /// includes 0 but not <paramref name="max"/>. However, if <paramref name="max"/> equals 0, will return 0.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="max"/> is less than 0.</exception>
    public static float NextSingle(this Random random, float max)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(max, nameof(max));
        return random.NextSingle() * max;
    }

    /// <summary>
    /// Returns a random single-precision floating-point number that is within a specified range.
    /// </summary>
    /// <param name="random">The random instance.</param>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned.</param>
    /// <returns>A single-precision floating point number that is greater than or equal to <paramref name="min"/>, and less than <paramref name="max"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="max"/> is less than <paramref name="min"/></exception>
    public static float NextSingle(this Random random, float min, float max)
    {
        if (min > max) throw new ArgumentException("Min value must be less than max value.");
        return random.NextSingle() * (max - min) + min;
    }

    /// <summary>Returns a non-negative random single double-precision floating-point number that is less than the specified maximum.</summary>
    /// <param name="random">The random instance.</param>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0.</param>
    /// <returns>
    /// A double-precision floating-point number that is greater than or equal to 0, and less than <paramref name="max"/>; that is, the range of return values ordinarily
    /// includes 0 but not <paramref name="max"/>. However, if <paramref name="max"/> equals 0, will return 0.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="max"/> is less than 0.</exception>
    public static double NextDouble(this Random random, double max)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(max, nameof(max));
        return random.NextDouble() * max;
    }

    /// <summary>
    /// Returns a random double-precision floating-point number that is within a specified range.
    /// </summary>
    /// <param name="random">The random instance.</param>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned.</param>
    /// <returns>A double-precision floating point number that is greater than or equal to <paramref name="min"/>, and less than <paramref name="max"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="max"/> is less than <paramref name="min"/></exception>
    public static double NextDouble(this Random random, double min, double max)
    {
        if (min > max) throw new ArgumentException("Min value must be less than max value.");
        return random.NextDouble() * (max - min) + min;
    }

    /// <summary>Returns a random integer that is within a specified range.</summary>
    /// <param name="random">The random instance.</param>
    /// <param name="range">The range of the random number returned.</param>
     /// <returns>
    /// A 32-bit signed integer in the <paramref name="range"/>;
    /// </returns>
    public static int Next(this Random random, Range range)
    {
        return random.Next(range.Start.Value, range.End.Value);
    }
}