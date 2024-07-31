namespace FoxTail.Common.Misc;

public static class TimeUtil
{
    public static long CurrentTimeMillisUtc => (long)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalMilliseconds;
    public static long CurrentTimeMillis => (long)DateTime.Now.Subtract(DateTime.UnixEpoch).TotalMilliseconds;   
    
    public static long CurrentTimeSecondsUtc => (long)DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds;
    public static long CurrentTimeSeconds => (long)DateTime.Now.Subtract(DateTime.UnixEpoch).TotalSeconds;
    
    public static long DateTimeToMillisUtc(DateTime time) => (long)time.ToUniversalTime().Subtract(DateTime.UnixEpoch).TotalMilliseconds;
    public static long DateTimeToMillis(DateTime time) => (long)time.Subtract(DateTime.UnixEpoch).TotalMilliseconds;
    public static long DateTimeToSecondsUtc(DateTime time) => (long)time.ToUniversalTime().Subtract(DateTime.UnixEpoch).TotalSeconds;
    public static long DateTimeToSeconds(DateTime time) => (long)time.Subtract(DateTime.UnixEpoch).TotalSeconds;
    
    
    public static DateTime DateTimeFromMillisUtc(long millis) => DateTime.UnixEpoch.AddMilliseconds(millis);
    public static DateTime DateTimeFromMillis(long millis) => DateTime.UnixEpoch.AddMilliseconds(millis).ToLocalTime();
    public static DateTime DateTimeFromSecondsUtc(long seconds) => DateTime.UnixEpoch.AddSeconds(seconds);
    public static DateTime DateTimeFromSeconds(long seconds) => DateTime.UnixEpoch.AddSeconds(seconds).ToLocalTime();
}