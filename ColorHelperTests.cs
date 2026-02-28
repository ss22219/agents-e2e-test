using System;
using Xunit;

public class ColorHelperTests
{
    [Fact]
    public void HexToRgb_WithValidHex_ReturnsCorrectRgb()
    {
        var (r, g, b) = ColorHelper.HexToRgb("#FF0000");
        Assert.Equal(255, r);
        Assert.Equal(0, g);
        Assert.Equal(0, b);
    }

    [Fact]
    public void HexToRgb_WithoutHashPrefix_ReturnsCorrectRgb()
    {
        var (r, g, b) = ColorHelper.HexToRgb("00FF00");
        Assert.Equal(0, r);
        Assert.Equal(255, g);
        Assert.Equal(0, b);
    }

    [Fact]
    public void HexToRgb_WithWhiteColor_ReturnsCorrectRgb()
    {
        var (r, g, b) = ColorHelper.HexToRgb("#FFFFFF");
        Assert.Equal(255, r);
        Assert.Equal(255, g);
        Assert.Equal(255, b);
    }

    [Fact]
    public void HexToRgb_WithBlackColor_ReturnsCorrectRgb()
    {
        var (r, g, b) = ColorHelper.HexToRgb("#000000");
        Assert.Equal(0, r);
        Assert.Equal(0, g);
        Assert.Equal(0, b);
    }

    [Fact]
    public void HexToRgb_WithNullString_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => ColorHelper.HexToRgb(null));
    }

    [Fact]
    public void HexToRgb_WithEmptyString_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => ColorHelper.HexToRgb(""));
    }

    [Fact]
    public void HexToRgb_WithInvalidLength_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => ColorHelper.HexToRgb("#FFF"));
    }

    [Fact]
    public void RgbToHex_WithValidRgb_ReturnsCorrectHex()
    {
        string hex = ColorHelper.RgbToHex(255, 0, 0);
        Assert.Equal("#FF0000", hex);
    }

    [Fact]
    public void RgbToHex_WithGreenColor_ReturnsCorrectHex()
    {
        string hex = ColorHelper.RgbToHex(0, 255, 0);
        Assert.Equal("#00FF00", hex);
    }

    [Fact]
    public void RgbToHex_WithBlueColor_ReturnsCorrectHex()
    {
        string hex = ColorHelper.RgbToHex(0, 0, 255);
        Assert.Equal("#0000FF", hex);
    }

    [Fact]
    public void RgbToHex_WithWhiteColor_ReturnsCorrectHex()
    {
        string hex = ColorHelper.RgbToHex(255, 255, 255);
        Assert.Equal("#FFFFFF", hex);
    }

    [Fact]
    public void RgbToHex_WithBlackColor_ReturnsCorrectHex()
    {
        string hex = ColorHelper.RgbToHex(0, 0, 0);
        Assert.Equal("#000000", hex);
    }

    [Fact]
    public void RgbToHex_WithInvalidRValue_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => ColorHelper.RgbToHex(256, 0, 0));
    }

    [Fact]
    public void RgbToHex_WithNegativeRValue_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => ColorHelper.RgbToHex(-1, 0, 0));
    }

    [Fact]
    public void RgbToHex_WithInvalidGValue_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => ColorHelper.RgbToHex(0, 256, 0));
    }

    [Fact]
    public void RgbToHex_WithInvalidBValue_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => ColorHelper.RgbToHex(0, 0, 256));
    }

    [Fact]
    public void HexToRgb_RoundTrip_WithValidHex_ReturnsOriginalHex()
    {
        var (r, g, b) = ColorHelper.HexToRgb("#A1B2C3");
        string hex = ColorHelper.RgbToHex(r, g, b);
        Assert.Equal("#A1B2C3", hex);
    }
}
