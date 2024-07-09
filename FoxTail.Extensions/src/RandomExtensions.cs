namespace FoxTail.Extensions;

public static class RandomExtensions
{
    public static float NextSingle(this Random random, float max)
    {
        return random.NextSingle() * max;
    }

    public static float NextSingle(this Random random, float min, float max)
    {
        if (min > max) throw new ArgumentException("Min value must be less than max value.");
        return random.NextSingle() * (max - min) + min;
    }

    public static double NextDouble(this Random random, double max)
    {
        return random.NextDouble() * max;
    }

    public static double NextDouble(this Random random, double min, double max)
    {
        if (min > max) throw new ArgumentException("Min value must be less than max value.");
        return random.NextDouble() * (max - min) + min;
    }

    public static int Next(this Random random, Range range)
    {
        return random.Next(range.Start.Value, range.End.Value);
    }
}