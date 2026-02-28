using System;

public enum CircuitState { Closed, Open, HalfOpen }

public static class CircuitBreaker
{
    private static CircuitState _state = CircuitState.Closed;
    private static int _failureCount = 0;
    private static DateTime _lastFailureTime = DateTime.MinValue;
    private static int _failureThreshold = 3;
    private static TimeSpan _timeout = TimeSpan.FromSeconds(30);

    public static CircuitState State => _state;

    public static void Configure(int failureThreshold, TimeSpan timeout)
    {
        _failureThreshold = failureThreshold;
        _timeout = timeout;
    }

    public static void Reset()
    {
        _state = CircuitState.Closed;
        _failureCount = 0;
        _lastFailureTime = DateTime.MinValue;
    }

    public static void Execute(Action action)
    {
        if (_state == CircuitState.Open)
        {
            if (DateTime.UtcNow - _lastFailureTime >= _timeout)
                _state = CircuitState.HalfOpen;
            else
                throw new InvalidOperationException("Circuit is open");
        }

        try
        {
            action();
            if (_state == CircuitState.HalfOpen)
                Reset();
            _failureCount = 0;
        }
        catch
        {
            _failureCount++;
            _lastFailureTime = DateTime.UtcNow;
            if (_failureCount >= _failureThreshold || _state == CircuitState.HalfOpen)
                _state = CircuitState.Open;
            throw;
        }
    }
}
