using System;
using System.Threading;
using Xunit;

public class RateLimiterTests
{
    [Fact]
    public void TryConsume_WithAvailableTokens_ReturnsTrue()
    {
        RateLimiter.Configure(10, 1);
        Assert.True(RateLimiter.TryConsume(5));
    }

    [Fact]
    public void TryConsume_WithInsufficientTokens_ReturnsFalse()
    {
        RateLimiter.Configure(5, 1);
        RateLimiter.TryConsume(5);
        Assert.False(RateLimiter.TryConsume(1));
    }

    [Fact]
    public void TryConsume_DefaultOneToken_ConsumesOne()
    {
        RateLimiter.Configure(10, 1);
        Assert.True(RateLimiter.TryConsume());
        Assert.Equal(9, RateLimiter.AvailableTokens(), 1);
    }

    [Fact]
    public void AvailableTokens_AfterConsumption_ReturnsCorrectCount()
    {
        RateLimiter.Configure(10, 1);
        RateLimiter.TryConsume(3);
        Assert.Equal(7, RateLimiter.AvailableTokens(), 1);
    }

    [Fact]
    public void Refill_AfterTime_AddsTokens()
    {
        RateLimiter.Configure(10, 2);
        RateLimiter.TryConsume(10);
        Thread.Sleep(1000);
        Assert.True(RateLimiter.AvailableTokens() >= 1.5);
    }

    [Fact]
    public void Refill_DoesNotExceedCapacity()
    {
        RateLimiter.Configure(10, 5);
        Thread.Sleep(3000);
        Assert.True(RateLimiter.AvailableTokens() <= 10);
    }

    [Fact]
    public void Reset_RestoresFullCapacity()
    {
        RateLimiter.Configure(10, 1);
        RateLimiter.TryConsume(8);
        RateLimiter.Reset();
        Assert.Equal(10, RateLimiter.AvailableTokens(), 1);
    }
}
