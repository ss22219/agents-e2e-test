using System;
using Xunit;

public class ValidationHelperTests
{
    [Fact]
    public void IsEmail_WithValidEmail_ReturnsTrue()
    {
        Assert.True(ValidationHelper.IsEmail("test@example.com"));
    }

    [Fact]
    public void IsEmail_WithInvalidEmail_ReturnsFalse()
    {
        Assert.False(ValidationHelper.IsEmail("invalid.email"));
    }

    [Fact]
    public void IsEmail_WithNull_ReturnsFalse()
    {
        Assert.False(ValidationHelper.IsEmail(null));
    }

    [Fact]
    public void IsEmail_WithEmptyString_ReturnsFalse()
    {
        Assert.False(ValidationHelper.IsEmail(""));
    }

    [Fact]
    public void IsEmail_WithWhitespace_ReturnsFalse()
    {
        Assert.False(ValidationHelper.IsEmail("   "));
    }

    [Fact]
    public void IsUrl_WithValidHttpUrl_ReturnsTrue()
    {
        Assert.True(ValidationHelper.IsUrl("http://example.com"));
    }

    [Fact]
    public void IsUrl_WithValidHttpsUrl_ReturnsTrue()
    {
        Assert.True(ValidationHelper.IsUrl("https://example.com"));
    }

    [Fact]
    public void IsUrl_WithInvalidUrl_ReturnsFalse()
    {
        Assert.False(ValidationHelper.IsUrl("not a url"));
    }

    [Fact]
    public void IsUrl_WithNull_ReturnsFalse()
    {
        Assert.False(ValidationHelper.IsUrl(null));
    }

    [Fact]
    public void IsUrl_WithEmptyString_ReturnsFalse()
    {
        Assert.False(ValidationHelper.IsUrl(""));
    }

    [Fact]
    public void IsUrl_WithFtpUrl_ReturnsFalse()
    {
        Assert.False(ValidationHelper.IsUrl("ftp://example.com"));
    }
}
