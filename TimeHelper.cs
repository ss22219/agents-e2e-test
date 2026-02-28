using System;

public static class TimeHelper
{
    private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public static long ToUnixTimestamp(DateTime dateTime)
    {
        if (dateTime.Kind != DateTimeKind.Utc)
        {
            dateTime = dateTime.ToUniversalTime();
        }
        return (long)(dateTime - UnixEpoch).TotalSeconds;
    }

    public static DateTime FromUnixTimestamp(long timestamp)
    {
        return UnixEpoch.AddSeconds(timestamp);
    }
}
