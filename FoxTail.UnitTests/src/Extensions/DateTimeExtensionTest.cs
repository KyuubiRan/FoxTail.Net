using FoxTail.Extensions;

namespace FoxTail.UnitTests.Extensions;

public class DateTimeExtensionTest
{
    [Test]
    public void ToUnixTimeSecondsTest()
    {
        var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Console.WriteLine("DateTime: " + dateTime);
        var unixTimeSeconds = dateTime.UnixTimeSeconds;
        Console.WriteLine("Unix Time Seconds: " + unixTimeSeconds);
        Assert.Multiple(() =>
        {
            Assert.That(unixTimeSeconds, Is.EqualTo(0));
            Assert.That(dateTime.IsThursday, Is.True);
        });

        var datetime2 = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Console.WriteLine("DateTime: " + datetime2);
        var unixTimeMilliseconds = datetime2.UnixTimeMilliseconds;
        Console.WriteLine("Unix Time Milliseconds: " + unixTimeMilliseconds);
        Assert.Multiple(() =>
        {
            Assert.That(unixTimeMilliseconds, Is.EqualTo(1704067200000));
            Assert.That(datetime2.IsMonday, Is.True);
        });
    }
}