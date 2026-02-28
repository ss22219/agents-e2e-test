using System;
using System.Threading.Tasks;

public static class RetryHelper
{
    public static async Task<T> ExecuteWithRetry<T>(Func<Task<T>> action, int maxRetries = 3, int delayMs = 100)
    {
        for (int i = 0; i <= maxRetries; i++)
        {
            try
            {
                return await action();
            }
            catch when (i < maxRetries)
            {
                await Task.Delay(delayMs);
            }
        }
        throw new InvalidOperationException("Should not reach here");
    }
}
