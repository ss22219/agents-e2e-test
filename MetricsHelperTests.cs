using System;
using Xunit;

public class MetricsHelperTests
{
    [Fact]
    public void Counter_Increment_IncreasesValue()
    {
        var counter = MetricsHelper.CreateCounter("test");
        counter.Increment();
        Assert.Equal(1, counter.Value);
    }

    [Fact]
    public void Counter_Add_IncreasesValueByAmount()
    {
        var counter = MetricsHelper.CreateCounter("test");
        counter.Add(5);
        Assert.Equal(5, counter.Value);
    }

    [Fact]
    public void Counter_MultipleOperations_AccumulatesCorrectly()
    {
        var counter = MetricsHelper.CreateCounter("test");
        counter.Increment();
        counter.Add(10);
        counter.Increment();
        Assert.Equal(12, counter.Value);
    }

    [Fact]
    public void Gauge_Set_UpdatesValue()
    {
        var gauge = MetricsHelper.CreateGauge("test");
        gauge.Set(42.5);
        Assert.Equal(42.5, gauge.Value);
    }

    [Fact]
    public void Gauge_Set_OverwritesPreviousValue()
    {
        var gauge = MetricsHelper.CreateGauge("test");
        gauge.Set(10.0);
        gauge.Set(20.0);
        Assert.Equal(20.0, gauge.Value);
    }

    [Fact]
    public void Histogram_Observe_IncreasesCount()
    {
        var histogram = MetricsHelper.CreateHistogram("test");
        histogram.Observe(1.0);
        histogram.Observe(2.0);
        Assert.Equal(2, histogram.Count);
    }

    [Fact]
    public void Histogram_Sum_CalculatesCorrectly()
    {
        var histogram = MetricsHelper.CreateHistogram("test");
        histogram.Observe(1.0);
        histogram.Observe(2.0);
        histogram.Observe(3.0);
        Assert.Equal(6.0, histogram.Sum);
    }

    [Fact]
    public void Histogram_Mean_CalculatesCorrectly()
    {
        var histogram = MetricsHelper.CreateHistogram("test");
        histogram.Observe(2.0);
        histogram.Observe(4.0);
        histogram.Observe(6.0);
        Assert.Equal(4.0, histogram.Mean);
    }

    [Fact]
    public void Histogram_Mean_WithNoValues_ReturnsZero()
    {
        var histogram = MetricsHelper.CreateHistogram("test");
        Assert.Equal(0.0, histogram.Mean);
    }
}
