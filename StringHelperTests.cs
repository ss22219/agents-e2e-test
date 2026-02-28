using System;
using Xunit;

public class StringHelperTests
{
    [Fact]
    public void Reverse_WithNormalString_ReturnsReversed()
    {
        Assert.Equal("olleh", StringHelper.Reverse("hello"));
    }

    [Fact]
    public void Reverse_WithEmptyString_ReturnsEmpty()
    {
        Assert.Equal("", StringHelper.Reverse(""));
    }

    [Fact]
    public void Reverse_WithNull_ReturnsNull()
    {
        Assert.Null(StringHelper.Reverse(null));
    }

    [Fact]
    public void Reverse_WithSingleCharacter_ReturnsSameCharacter()
    {
        Assert.Equal("a", StringHelper.Reverse("a"));
    }

    [Fact]
    public void IsPalindrome_WithPalindrome_ReturnsTrue()
    {
        Assert.True(StringHelper.IsPalindrome("racecar"));
    }

    [Fact]
    public void IsPalindrome_WithPalindromeUpperCase_ReturnsTrue()
    {
        Assert.True(StringHelper.IsPalindrome("RaceCar"));
    }

    [Fact]
    public void IsPalindrome_WithNonPalindrome_ReturnsFalse()
    {
        Assert.False(StringHelper.IsPalindrome("hello"));
    }

    [Fact]
    public void IsPalindrome_WithEmptyString_ReturnsTrue()
    {
        Assert.True(StringHelper.IsPalindrome(""));
    }

    [Fact]
    public void IsPalindrome_WithNull_ReturnsTrue()
    {
        Assert.True(StringHelper.IsPalindrome(null));
    }

    [Fact]
    public void IsPalindrome_WithSingleCharacter_ReturnsTrue()
    {
        Assert.True(StringHelper.IsPalindrome("a"));
    }
}
