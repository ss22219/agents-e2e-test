using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

public class ConfigHelperTests
{
    [Fact]
    public void GetValue_WithExistingKey_ReturnsValue()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string> { { "key1", "value1" } })
            .Build();

        Assert.Equal("value1", ConfigHelper.GetValue(config, "key1"));
    }

    [Fact]
    public void GetValue_WithNonExistingKey_ReturnsNull()
    {
        var config = new ConfigurationBuilder().Build();

        Assert.Null(ConfigHelper.GetValue(config, "nonexistent"));
    }

    [Fact]
    public void GetSection_WithExistingSection_ReturnsSection()
    {
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string> { { "Section:Key", "value" } })
            .Build();

        var section = ConfigHelper.GetSection(config, "Section");

        Assert.NotNull(section);
        Assert.Equal("value", section["Key"]);
    }

    [Fact]
    public void GetSection_WithNonExistingSection_ReturnsEmptySection()
    {
        var config = new ConfigurationBuilder().Build();

        var section = ConfigHelper.GetSection(config, "NonExistent");

        Assert.NotNull(section);
        Assert.False(section.Exists());
    }
}
