using Xunit;

public class RegexHelperTests
{
    [Fact]
    public void IsMatch_WithMatchingPattern_ReturnsTrue()
    {
        Assert.True(RegexHelper.IsMatch("hello123", @"\d+"));
    }

    [Fact]
    public void IsMatch_WithNonMatchingPattern_ReturnsFalse()
    {
        Assert.False(RegexHelper.IsMatch("hello", @"\d+"));
    }

    [Fact]
    public void IsMatch_WithNullInput_ReturnsFalse()
    {
        Assert.False(RegexHelper.IsMatch(null, @"\d+"));
    }

    [Fact]
    public void IsMatch_WithEmptyInput_ReturnsFalse()
    {
        Assert.False(RegexHelper.IsMatch("", @"\d+"));
    }

    [Fact]
    public void IsMatch_WithNullPattern_ReturnsFalse()
    {
        Assert.False(RegexHelper.IsMatch("hello", null));
    }

    [Fact]
    public void Extract_WithMatches_ReturnsMatchedStrings()
    {
        var result = RegexHelper.Extract("hello123world456", @"\d+");
        Assert.Equal(2, result.Length);
        Assert.Equal("123", result[0]);
        Assert.Equal("456", result[1]);
    }

    [Fact]
    public void Extract_WithNoMatches_ReturnsEmptyArray()
    {
        var result = RegexHelper.Extract("hello", @"\d+");
        Assert.Empty(result);
    }

    [Fact]
    public void Extract_WithNullInput_ReturnsEmptyArray()
    {
        var result = RegexHelper.Extract(null, @"\d+");
        Assert.Empty(result);
    }

    [Fact]
    public void Extract_WithEmptyInput_ReturnsEmptyArray()
    {
        var result = RegexHelper.Extract("", @"\d+");
        Assert.Empty(result);
    }

    [Fact]
    public void Extract_WithNullPattern_ReturnsEmptyArray()
    {
        var result = RegexHelper.Extract("hello123", null);
        Assert.Empty(result);
    }
}
