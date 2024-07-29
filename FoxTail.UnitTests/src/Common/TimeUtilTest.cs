using FoxTail.Common.Misc;

namespace FoxTail.UnitTests.Common;

public class TimeUtilTest
{
    [Test]
    public void CurrentTimeMillisTest()
    {
        Console.WriteLine($"CurrentTimeMillisUtc: {TimeUtil.CurrentTimeMillisUtc}");
        Console.WriteLine($"CurrentTimeMillis: {TimeUtil.CurrentTimeMillis}");
        Console.WriteLine($"CurrentTimeSecondsUtc: {TimeUtil.CurrentTimeSecondsUtc}");
        Console.WriteLine($"CurrentTimeSeconds: {TimeUtil.CurrentTimeSeconds}");
    }

    [Test]
    public void DateTimeTest()
    {
        Console.WriteLine($"DateTimeFromMillisUtc: {TimeUtil.DateTimeFromMillisUtc(TimeUtil.CurrentTimeMillisUtc)}");
        Console.WriteLine($"DateTimeFromMillis: {TimeUtil.DateTimeFromMillis(TimeUtil.CurrentTimeMillis)}");
        Console.WriteLine($"DateTimeFromSecondsUtc: {TimeUtil.DateTimeFromSecondsUtc(TimeUtil.CurrentTimeSecondsUtc)}");
        Console.WriteLine($"DateTimeFromSeconds: {TimeUtil.DateTimeFromSeconds(TimeUtil.CurrentTimeSeconds)}");
    }
}