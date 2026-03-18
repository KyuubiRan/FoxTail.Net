using FoxTail.Common.Utils;

namespace FoxTail.UnitTests.Common;

public class TimeUtilsTest
{
    [Test]
    public void CurrentTimeMillisTest()
    {
        Console.WriteLine($"CurrentTimeMillisUtc: {TimeUtils.CurrentTimeMillisUtc}");
        Console.WriteLine($"CurrentTimeMillis: {TimeUtils.CurrentTimeMillis}");
        Console.WriteLine($"CurrentTimeSecondsUtc: {TimeUtils.CurrentTimeSecondsUtc}");
        Console.WriteLine($"CurrentTimeSeconds: {TimeUtils.CurrentTimeSeconds}");
    }

    [Test]
    public void DateTimeTest()
    {
        Console.WriteLine($"DateTimeFromMillisUtc: {TimeUtils.DateTimeFromMillisUtc(TimeUtils.CurrentTimeMillisUtc)}");
        Console.WriteLine($"DateTimeFromMillis: {TimeUtils.DateTimeFromMillis(TimeUtils.CurrentTimeMillis)}");
        Console.WriteLine($"DateTimeFromSecondsUtc: {TimeUtils.DateTimeFromSecondsUtc(TimeUtils.CurrentTimeSecondsUtc)}");
        Console.WriteLine($"DateTimeFromSeconds: {TimeUtils.DateTimeFromSeconds(TimeUtils.CurrentTimeSeconds)}");
    }
}