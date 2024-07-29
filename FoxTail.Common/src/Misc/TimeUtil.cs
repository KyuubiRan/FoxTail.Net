namespace FoxTail.Common.Misc;

public static class TimeUtil
{
    public static ulong CurrentTimeMillisUtc => (ulong)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalMilliseconds;
    public static ulong CurrentTimeMillis => (ulong)DateTime.Now.Subtract(DateTime.UnixEpoch).TotalMilliseconds;
}