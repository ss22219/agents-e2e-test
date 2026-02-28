using System;
using Xunit;

public class UrlHelperTests
{
    [Fact]
    public void Encode_WithNormalString_ReturnsEncoded()
    {
        Assert.Equal("hello%20world", UrlHelper.Encode("hello world"));
    }

    [Fact]
    public void Encode_WithSpecialCharacters_ReturnsEncoded()
    {
        Assert.Equal("test%26value%3D123", UrlHelper.Encode("test&value=123"));
    }

    [Fact]
    public void Encode_WithEmptyString_ReturnsEmpty()
    {
        Assert.Equal("", UrlHelper.Encode(""));
    }

    [Fact]
    public void Encode_WithNull_ReturnsNull()
    {
        Assert.Null(UrlHelper.Encode(null));
    }

    [Fact]
    public void Decode_WithEncodedString_ReturnsDecoded()
    {
        Assert.Equal("hello world", UrlHelper.Decode("hello%20world"));
    }

    [Fact]
    public void Decode_WithSpecialCharacters_ReturnsDecoded()
    {
        Assert.Equal("test&value=123", UrlHelper.Decode("test%26value%3D123"));
    }

    [Fact]
    public void Decode_WithEmptyString_ReturnsEmpty()
    {
        Assert.Equal("", UrlHelper.Decode(""));
    }

    [Fact]
    public void Decode_WithNull_ReturnsNull()
    {
        Assert.Null(UrlHelper.Decode(null));
    }

    [Fact]
    public void ParseQuery_WithSimpleQuery_ReturnsDictionary()
    {
        var result = UrlHelper.ParseQuery("key1=value1&key2=value2");
        Assert.Equal(2, result.Count);
        Assert.Equal("value1", result["key1"]);
        Assert.Equal("value2", result["key2"]);
    }

    [Fact]
    public void ParseQuery_WithQuestionMark_ReturnsDictionary()
    {
        var result = UrlHelper.ParseQuery("?key1=value1&key2=value2");
        Assert.Equal(2, result.Count);
        Assert.Equal("value1", result["key1"]);
        Assert.Equal("value2", result["key2"]);
    }

    [Fact]
    public void ParseQuery_WithEncodedValues_ReturnsDecodedDictionary()
    {
        var result = UrlHelper.ParseQuery("name=John%20Doe&city=New%20York");
        Assert.Equal("John Doe", result["name"]);
        Assert.Equal("New York", result["city"]);
    }

    [Fact]
    public void ParseQuery_WithEmptyValue_ReturnsEmptyString()
    {
        var result = UrlHelper.ParseQuery("key1=&key2=value2");
        Assert.Equal("", result["key1"]);
        Assert.Equal("value2", result["key2"]);
    }

    [Fact]
    public void ParseQuery_WithNoValue_ReturnsEmptyString()
    {
        var result = UrlHelper.ParseQuery("key1&key2=value2");
        Assert.Equal("", result["key1"]);
        Assert.Equal("value2", result["key2"]);
    }

    [Fact]
    public void ParseQuery_WithEmptyString_ReturnsEmptyDictionary()
    {
        var result = UrlHelper.ParseQuery("");
        Assert.Empty(result);
    }

    [Fact]
    public void ParseQuery_WithNull_ReturnsEmptyDictionary()
    {
        var result = UrlHelper.ParseQuery(null);
        Assert.Empty(result);
    }
}
