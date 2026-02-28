using System;
using Xunit;

public class GeoHelperTests
{
    [Fact]
    public void Distance_BetweenSamePoint_ReturnsZero()
    {
        double distance = GeoHelper.Distance(0, 0, 0, 0);
        Assert.Equal(0, distance, 5);
    }

    [Fact]
    public void Distance_BetweenKnownPoints_ReturnsCorrectDistance()
    {
        double distance = GeoHelper.Distance(52.5200, 13.4050, 48.8566, 2.3522);
        Assert.Equal(877.46, distance, 1);
    }

    [Fact]
    public void Distance_BetweenEquatorPoints_ReturnsCorrectDistance()
    {
        double distance = GeoHelper.Distance(0, 0, 0, 1);
        Assert.Equal(111.19, distance, 1);
    }

    [Fact]
    public void MidPoint_BetweenSamePoint_ReturnsSamePoint()
    {
        var (lat, lon) = GeoHelper.MidPoint(10, 20, 10, 20);
        Assert.Equal(10, lat, 5);
        Assert.Equal(20, lon, 5);
    }

    [Fact]
    public void MidPoint_BetweenKnownPoints_ReturnsCorrectMidPoint()
    {
        var (lat, lon) = GeoHelper.MidPoint(52.5200, 13.4050, 48.8566, 2.3522);
        Assert.Equal(50.82, lat, 1);
        Assert.Equal(7.66, lon, 1);
    }

    [Fact]
    public void MidPoint_BetweenEquatorPoints_ReturnsCorrectMidPoint()
    {
        var (lat, lon) = GeoHelper.MidPoint(0, 0, 0, 10);
        Assert.Equal(0, lat, 5);
        Assert.Equal(5, lon, 5);
    }
}
