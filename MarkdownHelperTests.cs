using Xunit;

public class MarkdownHelperTests
{
    [Fact]
    public void ToHtml_WithBold_ReturnsBoldHtml()
    {
        var result = MarkdownHelper.ToHtml("**bold**");
        Assert.Equal("<strong>bold</strong>", result);
    }

    [Fact]
    public void ToHtml_WithItalic_ReturnsItalicHtml()
    {
        var result = MarkdownHelper.ToHtml("*italic*");
        Assert.Equal("<em>italic</em>", result);
    }

    [Fact]
    public void ToHtml_WithH1_ReturnsH1Html()
    {
        var result = MarkdownHelper.ToHtml("# Heading");
        Assert.Equal("<h1>Heading</h1>", result);
    }

    [Fact]
    public void ToHtml_WithH2_ReturnsH2Html()
    {
        var result = MarkdownHelper.ToHtml("## Heading");
        Assert.Equal("<h2>Heading</h2>", result);
    }

    [Fact]
    public void ToHtml_WithH3_ReturnsH3Html()
    {
        var result = MarkdownHelper.ToHtml("### Heading");
        Assert.Equal("<h3>Heading</h3>", result);
    }

    [Fact]
    public void ToHtml_WithLineBreak_ReturnsBreakTag()
    {
        var result = MarkdownHelper.ToHtml("line1\nline2");
        Assert.Equal("line1<br>line2", result);
    }

    [Fact]
    public void ToHtml_WithNull_ReturnsNull()
    {
        var result = MarkdownHelper.ToHtml(null);
        Assert.Null(result);
    }

    [Fact]
    public void ToHtml_WithEmpty_ReturnsEmpty()
    {
        var result = MarkdownHelper.ToHtml("");
        Assert.Equal("", result);
    }

    [Fact]
    public void ToHtml_WithMultipleFormats_ReturnsAllConverted()
    {
        var result = MarkdownHelper.ToHtml("# Title\n**bold** and *italic*");
        Assert.Equal("<h1>Title</h1><br><strong>bold</strong> and <em>italic</em>", result);
    }

    [Fact]
    public void StripTags_WithHtmlTags_RemovesTags()
    {
        var result = MarkdownHelper.StripTags("<p>Hello</p>");
        Assert.Equal("Hello", result);
    }

    [Fact]
    public void StripTags_WithMultipleTags_RemovesAllTags()
    {
        var result = MarkdownHelper.StripTags("<h1>Title</h1><p>Content</p>");
        Assert.Equal("TitleContent", result);
    }

    [Fact]
    public void StripTags_WithNestedTags_RemovesAllTags()
    {
        var result = MarkdownHelper.StripTags("<div><strong>bold</strong></div>");
        Assert.Equal("bold", result);
    }

    [Fact]
    public void StripTags_WithNull_ReturnsNull()
    {
        var result = MarkdownHelper.StripTags(null);
        Assert.Null(result);
    }

    [Fact]
    public void StripTags_WithEmpty_ReturnsEmpty()
    {
        var result = MarkdownHelper.StripTags("");
        Assert.Equal("", result);
    }

    [Fact]
    public void StripTags_WithNoTags_ReturnsOriginal()
    {
        var result = MarkdownHelper.StripTags("plain text");
        Assert.Equal("plain text", result);
    }
}
