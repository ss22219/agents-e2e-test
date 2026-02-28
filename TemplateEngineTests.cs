using System.Collections.Generic;
using Xunit;

public class TemplateEngineTests
{
    [Fact]
    public void Render_WithSingleVariable_ReplacesVariable()
    {
        var template = "Hello {{name}}!";
        var variables = new Dictionary<string, string> { { "name", "World" } };
        Assert.Equal("Hello World!", TemplateEngine.Render(template, variables));
    }

    [Fact]
    public void Render_WithMultipleVariables_ReplacesAllVariables()
    {
        var template = "{{greeting}} {{name}}, you are {{age}} years old.";
        var variables = new Dictionary<string, string>
        {
            { "greeting", "Hello" },
            { "name", "Alice" },
            { "age", "30" }
        };
        Assert.Equal("Hello Alice, you are 30 years old.", TemplateEngine.Render(template, variables));
    }

    [Fact]
    public void Render_WithNoVariables_ReturnsOriginalTemplate()
    {
        var template = "Hello World!";
        var variables = new Dictionary<string, string>();
        Assert.Equal("Hello World!", TemplateEngine.Render(template, variables));
    }

    [Fact]
    public void Render_WithNullVariables_ReturnsOriginalTemplate()
    {
        var template = "Hello {{name}}!";
        Assert.Equal("Hello {{name}}!", TemplateEngine.Render(template, null));
    }

    [Fact]
    public void Render_WithEmptyTemplate_ReturnsEmpty()
    {
        var variables = new Dictionary<string, string> { { "name", "World" } };
        Assert.Equal("", TemplateEngine.Render("", variables));
    }

    [Fact]
    public void Render_WithNullTemplate_ReturnsNull()
    {
        var variables = new Dictionary<string, string> { { "name", "World" } };
        Assert.Null(TemplateEngine.Render(null, variables));
    }

    [Fact]
    public void Render_WithRepeatedVariable_ReplacesAllOccurrences()
    {
        var template = "{{name}} loves {{name}}!";
        var variables = new Dictionary<string, string> { { "name", "Bob" } };
        Assert.Equal("Bob loves Bob!", TemplateEngine.Render(template, variables));
    }
}
