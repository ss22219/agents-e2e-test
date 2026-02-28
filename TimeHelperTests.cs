using System;
using Xunit;

public class TimeHelperTests
{
    [Fact]
    public void ToUnixTimestamp_WithUnixEpoch_ReturnsZero()
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.Equal(0L, TimeHelper.ToUnixTimestamp(epoch));
    }

    [Fact]
    public void ToUnixTimestamp_WithKnownDate_ReturnsCorrectTimestamp()
    {
        var date = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        Assert.Equal(946684800L, TimeHelper.ToUnixTimestamp(date));
    }

    [Fact]
    public void ToUnixTimestamp_WithLocalTime_ConvertsToUtc()
    {
        var localDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);
        var timestamp = TimeHelper.ToUnixTimestamp(localDate);
        Assert.True(timestamp <= 0);
    }

    [Fact]
    public void ToUnixTimestamp_WithUnspecifiedKind_TreatsAsLocal()
    {
        var unspecified = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
        var timestamp = TimeHelper.ToUnixTimestamp(unspecified);
        Assert.True(timestamp <= 0);
    }

    [Fact]
    public void FromUnixTimestamp_WithZero_ReturnsEpoch()
    {
        var result = TimeHelper.FromUnixTimestamp(0);
        Assert.Equal(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), result);
    }

    [Fact]
    public void FromUnixTimestamp_WithKnownTimestamp_ReturnsCorrectDate()
    {
        var result = TimeHelper.FromUnixTimestamp(946684800L);
        Assert.Equal(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc), result);
    }

    [Fact]
    public void FromUnixTimestamp_WithNegativeTimestamp_ReturnsBeforeEpoch()
    {
        var result = TimeHelper.FromUnixTimestamp(-86400);
        Assert.Equal(new DateTime(1969, 12, 31, 0, 0, 0, DateTimeKind.Utc), result);
    }

    [Fact]
    public void ToUnixTimestamp_AndFromUnixTimestamp_RoundTrip()
    {
        var original = new DateTime(2024, 3, 15, 12, 30, 45, DateTimeKind.Utc);
        var timestamp = TimeHelper.ToUnixTimestamp(original);
        var restored = TimeHelper.FromUnixTimestamp(timestamp);
        Assert.Equal(original, restored);
    }
}
