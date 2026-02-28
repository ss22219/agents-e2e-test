using System;
using System.Threading;
using System.Threading.Tasks;

public static class SemaphoreHelper
{
    private static SemaphoreSlim _semaphore;

    public static void Initialize(int initialCount = 1, int maxCount = 1)
    {
        _semaphore = new SemaphoreSlim(initialCount, maxCount);
    }

    public static async Task WaitAsync()
    {
        if (_semaphore == null)
            throw new InvalidOperationException("SemaphoreHelper must be initialized first");
        await _semaphore.WaitAsync();
    }

    public static void Release()
    {
        if (_semaphore == null)
            throw new InvalidOperationException("SemaphoreHelper must be initialized first");
        _semaphore.Release();
    }

    public static void Reset()
    {
        _semaphore?.Dispose();
        _semaphore = null;
    }
}
