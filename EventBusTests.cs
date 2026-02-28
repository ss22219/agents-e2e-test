using System;
using Xunit;

public class EventBusTests
{
    [Fact]
    public void Publish_WithSubscriber_InvokesHandler()
    {
        int result = 0;
        EventBus.Subscribe<int>(x => result = x);
        EventBus.Publish(42);
        Assert.Equal(42, result);
    }

    [Fact]
    public void Publish_WithMultipleSubscribers_InvokesAllHandlers()
    {
        int sum = 0;
        EventBus.Subscribe<int>(x => sum += x);
        EventBus.Subscribe<int>(x => sum += x * 2);
        EventBus.Publish(5);
        Assert.Equal(15, sum);
    }

    [Fact]
    public void Publish_WithNoSubscribers_DoesNotThrow()
    {
        EventBus.Publish("test");
    }

    [Fact]
    public void Subscribe_WithDifferentTypes_HandlesCorrectly()
    {
        string stringResult = null;
        int intResult = 0;
        EventBus.Subscribe<string>(x => stringResult = x);
        EventBus.Subscribe<int>(x => intResult = x);
        EventBus.Publish("hello");
        EventBus.Publish(100);
        Assert.Equal("hello", stringResult);
        Assert.Equal(100, intResult);
    }
}
