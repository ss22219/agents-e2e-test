using System;
using Xunit;

public class GuardHelperTests
{
    [Fact]
    public void NotNull_WithNonNullValue_DoesNotThrow()
    {
        var obj = new object();
        GuardHelper.NotNull(obj, nameof(obj));
    }

    [Fact]
    public void NotNull_WithNullValue_ThrowsArgumentNullException()
    {
        object obj = null;
        Assert.Throws<ArgumentNullException>(() => GuardHelper.NotNull(obj, nameof(obj)));
    }

    [Fact]
    public void InRange_WithValueInRange_DoesNotThrow()
    {
        GuardHelper.InRange(5, 0, 10, "value");
    }

    [Fact]
    public void InRange_WithValueAtMin_DoesNotThrow()
    {
        GuardHelper.InRange(0, 0, 10, "value");
    }

    [Fact]
    public void InRange_WithValueAtMax_DoesNotThrow()
    {
        GuardHelper.InRange(10, 0, 10, "value");
    }

    [Fact]
    public void InRange_WithValueBelowMin_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => GuardHelper.InRange(-1, 0, 10, "value"));
    }

    [Fact]
    public void InRange_WithValueAboveMax_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => GuardHelper.InRange(11, 0, 10, "value"));
    }
}
