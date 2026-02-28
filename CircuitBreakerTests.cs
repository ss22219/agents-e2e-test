using System;
using System.Threading;
using Xunit;

public class CircuitBreakerTests
{
    public CircuitBreakerTests()
    {
        CircuitBreaker.Reset();
        CircuitBreaker.Configure(3, TimeSpan.FromMilliseconds(100));
    }

    [Fact]
    public void State_InitiallyIsClosed()
    {
        Assert.Equal(CircuitState.Closed, CircuitBreaker.State);
    }

    [Fact]
    public void Execute_SuccessfulAction_KeepsCircuitClosed()
    {
        CircuitBreaker.Execute(() => { });
        Assert.Equal(CircuitState.Closed, CircuitBreaker.State);
    }

    [Fact]
    public void Execute_FailuresReachThreshold_OpensCircuit()
    {
        for (int i = 0; i < 3; i++)
        {
            try { CircuitBreaker.Execute(() => throw new Exception()); }
            catch { }
        }
        Assert.Equal(CircuitState.Open, CircuitBreaker.State);
    }

    [Fact]
    public void Execute_CircuitOpen_ThrowsInvalidOperationException()
    {
        for (int i = 0; i < 3; i++)
        {
            try { CircuitBreaker.Execute(() => throw new Exception()); }
            catch { }
        }
        Assert.Throws<InvalidOperationException>(() => CircuitBreaker.Execute(() => { }));
    }

    [Fact]
    public void Execute_AfterTimeout_TransitionsToHalfOpen()
    {
        for (int i = 0; i < 3; i++)
        {
            try { CircuitBreaker.Execute(() => throw new Exception()); }
            catch { }
        }
        Thread.Sleep(150);
        try { CircuitBreaker.Execute(() => { }); }
        catch { }
        Assert.Equal(CircuitState.Closed, CircuitBreaker.State);
    }

    [Fact]
    public void Execute_HalfOpenSuccess_ClosesCircuit()
    {
        for (int i = 0; i < 3; i++)
        {
            try { CircuitBreaker.Execute(() => throw new Exception()); }
            catch { }
        }
        Thread.Sleep(150);
        CircuitBreaker.Execute(() => { });
        Assert.Equal(CircuitState.Closed, CircuitBreaker.State);
    }

    [Fact]
    public void Execute_HalfOpenFailure_ReopensCircuit()
    {
        for (int i = 0; i < 3; i++)
        {
            try { CircuitBreaker.Execute(() => throw new Exception()); }
            catch { }
        }
        Thread.Sleep(150);
        try { CircuitBreaker.Execute(() => throw new Exception()); }
        catch { }
        Assert.Equal(CircuitState.Open, CircuitBreaker.State);
    }

    [Fact]
    public void Reset_ResetsStateAndCounters()
    {
        for (int i = 0; i < 2; i++)
        {
            try { CircuitBreaker.Execute(() => throw new Exception()); }
            catch { }
        }
        CircuitBreaker.Reset();
        Assert.Equal(CircuitState.Closed, CircuitBreaker.State);
        CircuitBreaker.Execute(() => { });
    }
}
