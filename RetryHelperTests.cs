using System;
using System.Threading.Tasks;
using Xunit;

public class RetryHelperTests
{
    [Fact]
    public async Task ExecuteWithRetry_SucceedsOnFirstAttempt_ReturnsResult()
    {
        var result = await RetryHelper.ExecuteWithRetry(async () =>
        {
            await Task.CompletedTask;
            return 42;
        });
        Assert.Equal(42, result);
    }

    [Fact]
    public async Task ExecuteWithRetry_FailsOnceThenSucceeds_ReturnsResult()
    {
        int attempts = 0;
        var result = await RetryHelper.ExecuteWithRetry(async () =>
        {
            await Task.CompletedTask;
            attempts++;
            if (attempts == 1) throw new Exception("First attempt fails");
            return 100;
        });
        Assert.Equal(100, result);
        Assert.Equal(2, attempts);
    }

    [Fact]
    public async Task ExecuteWithRetry_FailsAllAttempts_ThrowsException()
    {
        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await RetryHelper.ExecuteWithRetry<int>(async () =>
            {
                await Task.CompletedTask;
                throw new Exception("Always fails");
            }, maxRetries: 2);
        });
    }

    [Fact]
    public async Task ExecuteWithRetry_WithCustomRetries_RespectsMaxRetries()
    {
        int attempts = 0;
        await Assert.ThrowsAsync<Exception>(async () =>
        {
            await RetryHelper.ExecuteWithRetry<int>(async () =>
            {
                await Task.CompletedTask;
                attempts++;
                throw new Exception("Fail");
            }, maxRetries: 5);
        });
        Assert.Equal(6, attempts);
    }

    [Fact]
    public async Task ExecuteWithRetry_WithCustomDelay_WaitsBeforeRetry()
    {
        int attempts = 0;
        var startTime = DateTime.UtcNow;
        var result = await RetryHelper.ExecuteWithRetry(async () =>
        {
            await Task.CompletedTask;
            attempts++;
            if (attempts < 3) throw new Exception("Fail");
            return "success";
        }, maxRetries: 3, delayMs: 50);
        
        var elapsed = (DateTime.UtcNow - startTime).TotalMilliseconds;
        Assert.Equal("success", result);
        Assert.True(elapsed >= 100);
    }
}
