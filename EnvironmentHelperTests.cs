using System;
using Xunit;

public class EnvironmentHelperTests
{
    [Fact]
    public void GetVar_WithExistingVariable_ReturnsValue()
    {
        Environment.SetEnvironmentVariable("TEST_VAR", "test_value");
        Assert.Equal("test_value", EnvironmentHelper.GetVar("TEST_VAR"));
        Environment.SetEnvironmentVariable("TEST_VAR", null);
    }

    [Fact]
    public void GetVar_WithNonExistentVariable_ReturnsNull()
    {
        Assert.Null(EnvironmentHelper.GetVar("NONEXISTENT_VAR_12345"));
    }

    [Fact]
    public void IsProduction_WithProductionEnvironment_ReturnsTrue()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
        Assert.True(EnvironmentHelper.IsProduction());
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", null);
    }

    [Fact]
    public void IsProduction_WithDevelopmentEnvironment_ReturnsFalse()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", null);
        Assert.False(EnvironmentHelper.IsProduction());
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", null);
    }

    [Fact]
    public void IsProduction_WithNoEnvironmentVariables_ReturnsTrue()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", null);
        Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", null);
        Assert.True(EnvironmentHelper.IsProduction());
    }

    [Fact]
    public void IsProduction_WithDotnetEnvironmentVariable_ReturnsTrue()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", null);
        Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", "Production");
        Assert.True(EnvironmentHelper.IsProduction());
        Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", null);
    }

    [Fact]
    public void IsProduction_WithCaseInsensitiveProduction_ReturnsTrue()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "PRODUCTION");
        Assert.True(EnvironmentHelper.IsProduction());
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", null);
    }
}
