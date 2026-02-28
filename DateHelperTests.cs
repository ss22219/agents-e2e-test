using System;
using Xunit;

public class DateHelperTests
{
    [Fact]
    public void IsWeekend_WithSaturday_ReturnsTrue()
    {
        var saturday = new DateTime(2024, 3, 2); // Saturday
        Assert.True(DateHelper.IsWeekend(saturday));
    }

    [Fact]
    public void IsWeekend_WithSunday_ReturnsTrue()
    {
        var sunday = new DateTime(2024, 3, 3); // Sunday
        Assert.True(DateHelper.IsWeekend(sunday));
    }

    [Fact]
    public void IsWeekend_WithWeekday_ReturnsFalse()
    {
        var monday = new DateTime(2024, 3, 4); // Monday
        Assert.False(DateHelper.IsWeekend(monday));
    }

    [Fact]
    public void DaysUntil_SameDates_ReturnsZero()
    {
        var date = new DateTime(2024, 3, 1);
        Assert.Equal(0, DateHelper.DaysUntil(date, date));
    }

    [Fact]
    public void DaysUntil_ForwardDates_ReturnsPositiveDays()
    {
        var from = new DateTime(2024, 3, 1);
        var to = new DateTime(2024, 3, 5);
        Assert.Equal(4, DateHelper.DaysUntil(from, to));
    }

    [Fact]
    public void DaysUntil_BackwardDates_ReturnsAbsoluteDays()
    {
        var from = new DateTime(2024, 3, 5);
        var to = new DateTime(2024, 3, 1);
        Assert.Equal(4, DateHelper.DaysUntil(from, to));
    }
}
