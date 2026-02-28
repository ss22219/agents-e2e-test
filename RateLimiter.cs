using System;

public static class RateLimiter
{
    private static double _tokens;
    private static double _capacity;
    private static double _refillRate;
    private static DateTime _lastRefill;
    private static readonly object _lock = new object();

    public static void Configure(double capacity, double refillRate)
    {
        lock (_lock)
        {
            _capacity = capacity;
            _refillRate = refillRate;
            _tokens = capacity;
            _lastRefill = DateTime.UtcNow;
        }
    }

    public static bool TryConsume(double tokens = 1)
    {
        lock (_lock)
        {
            Refill();
            if (_tokens >= tokens)
            {
                _tokens -= tokens;
                return true;
            }
            return false;
        }
    }

    public static double AvailableTokens()
    {
        lock (_lock)
        {
            Refill();
            return _tokens;
        }
    }

    public static void Reset()
    {
        lock (_lock)
        {
            _tokens = _capacity;
            _lastRefill = DateTime.UtcNow;
        }
    }

    private static void Refill()
    {
        var now = DateTime.UtcNow;
        var elapsed = (now - _lastRefill).TotalSeconds;
        _tokens = Math.Min(_capacity, _tokens + elapsed * _refillRate);
        _lastRefill = now;
    }
}
