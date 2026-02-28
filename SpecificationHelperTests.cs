using System;
using Xunit;

public class SpecificationHelperTests
{
    [Fact]
    public void And_BothTrue_ReturnsTrue()
    {
        Func<int, bool> isPositive = x => x > 0;
        Func<int, bool> isEven = x => x % 2 == 0;
        var spec = SpecificationHelper.And(isPositive, isEven);
        
        Assert.True(spec(4));
    }

    [Fact]
    public void And_OneFalse_ReturnsFalse()
    {
        Func<int, bool> isPositive = x => x > 0;
        Func<int, bool> isEven = x => x % 2 == 0;
        var spec = SpecificationHelper.And(isPositive, isEven);
        
        Assert.False(spec(3));
    }

    [Fact]
    public void And_BothFalse_ReturnsFalse()
    {
        Func<int, bool> isPositive = x => x > 0;
        Func<int, bool> isEven = x => x % 2 == 0;
        var spec = SpecificationHelper.And(isPositive, isEven);
        
        Assert.False(spec(-3));
    }

    [Fact]
    public void Or_BothTrue_ReturnsTrue()
    {
        Func<int, bool> isPositive = x => x > 0;
        Func<int, bool> isEven = x => x % 2 == 0;
        var spec = SpecificationHelper.Or(isPositive, isEven);
        
        Assert.True(spec(4));
    }

    [Fact]
    public void Or_OneTrue_ReturnsTrue()
    {
        Func<int, bool> isPositive = x => x > 0;
        Func<int, bool> isEven = x => x % 2 == 0;
        var spec = SpecificationHelper.Or(isPositive, isEven);
        
        Assert.True(spec(3));
    }

    [Fact]
    public void Or_BothFalse_ReturnsFalse()
    {
        Func<int, bool> isPositive = x => x > 0;
        Func<int, bool> isEven = x => x % 2 == 0;
        var spec = SpecificationHelper.Or(isPositive, isEven);
        
        Assert.False(spec(-3));
    }

    [Fact]
    public void Not_True_ReturnsFalse()
    {
        Func<int, bool> isPositive = x => x > 0;
        var spec = SpecificationHelper.Not(isPositive);
        
        Assert.False(spec(5));
    }

    [Fact]
    public void Not_False_ReturnsTrue()
    {
        Func<int, bool> isPositive = x => x > 0;
        var spec = SpecificationHelper.Not(isPositive);
        
        Assert.True(spec(-5));
    }

    [Fact]
    public void CombinedSpecifications_ComplexLogic_Works()
    {
        Func<int, bool> isPositive = x => x > 0;
        Func<int, bool> isEven = x => x % 2 == 0;
        Func<int, bool> lessThan10 = x => x < 10;
        
        var spec = SpecificationHelper.And(
            SpecificationHelper.Or(isPositive, isEven),
            lessThan10
        );
        
        Assert.True(spec(4));
        Assert.True(spec(3));
        Assert.False(spec(15));
    }

    [Fact]
    public void CombinedSpecifications_WithNot_Works()
    {
        Func<int, bool> isEven = x => x % 2 == 0;
        var isOdd = SpecificationHelper.Not(isEven);
        
        Assert.True(isOdd(3));
        Assert.False(isOdd(4));
    }
}
