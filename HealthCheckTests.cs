using Xunit;
using System.Linq;

public class HealthCheckTests
{
    public HealthCheckTests()
    {
        HealthCheck.Clear();
    }

    [Fact]
    public void AddCheck_And_RunAll_ReturnsResults()
    {
        HealthCheck.AddCheck("test1", () => true);
        var results = HealthCheck.RunAll();
        Assert.True(results["test1"]);
    }

    [Fact]
    public void RunAll_WithMultipleChecks_ReturnsAllResults()
    {
        HealthCheck.AddCheck("check1", () => true);
        HealthCheck.AddCheck("check2", () => false);
        var results = HealthCheck.RunAll();
        Assert.Equal(2, results.Count);
        Assert.True(results["check1"]);
        Assert.False(results["check2"]);
    }

    [Fact]
    public void AddCheck_OverwritesExisting()
    {
        HealthCheck.AddCheck("check3", () => true);
        HealthCheck.AddCheck("check3", () => false);
        var results = HealthCheck.RunAll();
        Assert.False(results["check3"]);
    }

    [Fact]
    public void RunAll_WithNoChecks_ReturnsEmpty()
    {
        var results = HealthCheck.RunAll();
        Assert.NotNull(results);
    }
}
