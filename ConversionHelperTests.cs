using System;
using Xunit;

public class ConversionHelperTests
{
    [Fact]
    public void ToCelsius_WithFreezingPoint_ReturnsZero()
    {
        Assert.Equal(0, ConversionHelper.ToCelsius(32), 2);
    }

    [Fact]
    public void ToCelsius_WithBoilingPoint_Returns100()
    {
        Assert.Equal(100, ConversionHelper.ToCelsius(212), 2);
    }

    [Fact]
    public void ToCelsius_WithNegativeValue_ReturnsNegativeCelsius()
    {
        Assert.Equal(-40, ConversionHelper.ToCelsius(-40), 2);
    }

    [Fact]
    public void ToFahrenheit_WithFreezingPoint_Returns32()
    {
        Assert.Equal(32, ConversionHelper.ToFahrenheit(0), 2);
    }

    [Fact]
    public void ToFahrenheit_WithBoilingPoint_Returns212()
    {
        Assert.Equal(212, ConversionHelper.ToFahrenheit(100), 2);
    }

    [Fact]
    public void ToFahrenheit_WithNegativeValue_ReturnsNegativeFahrenheit()
    {
        Assert.Equal(-40, ConversionHelper.ToFahrenheit(-40), 2);
    }
}
