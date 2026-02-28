using System;
using System.Diagnostics;
using System.Threading;
using Xunit;

public class DiagnosticHelperTests
{
    [Fact]
    public void StartStopwatch_ReturnsRunningStopwatch()
    {
        var sw = DiagnosticHelper.StartStopwatch();
        Assert.NotNull(sw);
        Assert.True(sw.IsRunning);
        sw.Stop();
    }

    [Fact]
    public void StartStopwatch_MeasuresElapsedTime()
    {
        var sw = DiagnosticHelper.StartStopwatch();
        Thread.Sleep(10);
        sw.Stop();
        Assert.True(sw.ElapsedMilliseconds >= 10);
    }

    [Fact]
    public void GetMemoryUsage_ReturnsPositiveValue()
    {
        var memory = DiagnosticHelper.GetMemoryUsage();
        Assert.True(memory > 0);
    }

    [Fact]
    public void GetMemoryUsage_ChangesWithAllocation()
    {
        var before = DiagnosticHelper.GetMemoryUsage();
        var data = new byte[1024 * 1024];
        var after = DiagnosticHelper.GetMemoryUsage();
        Assert.True(after >= before);
    }
}
