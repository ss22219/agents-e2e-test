using System;
using System.Threading.Tasks;
using Xunit;

public class SemaphoreHelperTests
{
    [Fact]
    public async Task WaitAsync_WithInitializedSemaphore_Succeeds()
    {
        SemaphoreHelper.Initialize(1, 1);
        await SemaphoreHelper.WaitAsync();
        SemaphoreHelper.Release();
        SemaphoreHelper.Reset();
    }

    [Fact]
    public async Task WaitAsync_WithoutInitialization_ThrowsException()
    {
        SemaphoreHelper.Reset();
        await Assert.ThrowsAsync<InvalidOperationException>(() => SemaphoreHelper.WaitAsync());
    }

    [Fact]
    public void Release_WithoutInitialization_ThrowsException()
    {
        SemaphoreHelper.Reset();
        Assert.Throws<InvalidOperationException>(() => SemaphoreHelper.Release());
    }

    [Fact]
    public async Task WaitAsync_AndRelease_AllowsMultipleAcquisitions()
    {
        SemaphoreHelper.Initialize(1, 1);
        await SemaphoreHelper.WaitAsync();
        SemaphoreHelper.Release();
        await SemaphoreHelper.WaitAsync();
        SemaphoreHelper.Release();
        SemaphoreHelper.Reset();
    }

    [Fact]
    public async Task WaitAsync_WithMultipleCount_AllowsConcurrentAccess()
    {
        SemaphoreHelper.Initialize(2, 2);
        await SemaphoreHelper.WaitAsync();
        await SemaphoreHelper.WaitAsync();
        SemaphoreHelper.Release();
        SemaphoreHelper.Release();
        SemaphoreHelper.Reset();
    }

    [Fact]
    public async Task WaitAsync_BlocksWhenExhausted()
    {
        SemaphoreHelper.Initialize(1, 1);
        await SemaphoreHelper.WaitAsync();
        
        var task = Task.Run(async () =>
        {
            await SemaphoreHelper.WaitAsync();
            SemaphoreHelper.Release();
        });

        await Task.Delay(100);
        Assert.False(task.IsCompleted);
        
        SemaphoreHelper.Release();
        await task;
        SemaphoreHelper.Reset();
    }
}
