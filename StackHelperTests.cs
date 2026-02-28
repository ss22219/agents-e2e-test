using System;
using Xunit;

public class StackHelperTests
{
    [Fact]
    public void MinStack_Push_AddsElement()
    {
        var stack = new StackHelper.MinStack();
        stack.Push(5);
        Assert.Equal(5, stack.Top());
    }

    [Fact]
    public void MinStack_Pop_RemovesElement()
    {
        var stack = new StackHelper.MinStack();
        stack.Push(5);
        stack.Push(3);
        stack.Pop();
        Assert.Equal(5, stack.Top());
    }

    [Fact]
    public void MinStack_GetMin_ReturnsMinimum()
    {
        var stack = new StackHelper.MinStack();
        stack.Push(5);
        stack.Push(3);
        stack.Push(7);
        Assert.Equal(3, stack.GetMin());
    }

    [Fact]
    public void MinStack_GetMin_AfterPop_ReturnsCorrectMinimum()
    {
        var stack = new StackHelper.MinStack();
        stack.Push(5);
        stack.Push(3);
        stack.Push(7);
        stack.Pop();
        stack.Pop();
        Assert.Equal(5, stack.GetMin());
    }

    [Fact]
    public void MinStack_Pop_OnEmpty_ThrowsInvalidOperationException()
    {
        var stack = new StackHelper.MinStack();
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }

    [Fact]
    public void MinStack_Top_OnEmpty_ThrowsInvalidOperationException()
    {
        var stack = new StackHelper.MinStack();
        Assert.Throws<InvalidOperationException>(() => stack.Top());
    }

    [Fact]
    public void MinStack_GetMin_OnEmpty_ThrowsInvalidOperationException()
    {
        var stack = new StackHelper.MinStack();
        Assert.Throws<InvalidOperationException>(() => stack.GetMin());
    }
}
