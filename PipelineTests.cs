using System;
using Xunit;

public class PipelineTests
{
    [Fact]
    public void AddStep_WithSingleStep_ExecutesStep()
    {
        var pipeline = Pipeline.AddStep<int>(x => x * 2);
        Assert.Equal(10, pipeline.Execute(5));
    }

    [Fact]
    public void AddStep_WithMultipleSteps_ExecutesInOrder()
    {
        var pipeline = Pipeline.AddStep<int>(x => x * 2)
            .AddStep(x => x + 3)
            .AddStep(x => x * 10);
        Assert.Equal(130, pipeline.Execute(5));
    }

    [Fact]
    public void AddStep_WithStringSteps_ExecutesCorrectly()
    {
        var pipeline = Pipeline.AddStep<string>(s => s.ToUpper())
            .AddStep(s => s + "!");
        Assert.Equal("HELLO!", pipeline.Execute("hello"));
    }

    [Fact]
    public void AddStep_WithNullStep_ThrowsArgumentNullException()
    {
        var pipeline = new Pipeline<int>();
        Assert.Throws<ArgumentNullException>(() => pipeline.AddStep(null));
    }

    [Fact]
    public void Execute_WithNoSteps_ReturnsInput()
    {
        var pipeline = new Pipeline<int>();
        Assert.Equal(5, pipeline.Execute(5));
    }
}
