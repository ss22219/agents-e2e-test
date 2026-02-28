using System.Collections.Generic;
using Xunit;

public class CsvHelperTests
{
    [Fact]
    public void Parse_WithValidCsv_ReturnsData()
    {
        var csv = "Name,Age\nJohn,30\nJane,25";
        var result = CsvHelper.Parse(csv);
        
        Assert.Equal(2, result.Count);
        Assert.Equal("John", result[0]["Name"]);
        Assert.Equal("30", result[0]["Age"]);
        Assert.Equal("Jane", result[1]["Name"]);
        Assert.Equal("25", result[1]["Age"]);
    }

    [Fact]
    public void Parse_WithEmptyString_ReturnsEmptyList()
    {
        var result = CsvHelper.Parse("");
        Assert.Empty(result);
    }

    [Fact]
    public void Parse_WithNull_ReturnsEmptyList()
    {
        var result = CsvHelper.Parse(null);
        Assert.Empty(result);
    }

    [Fact]
    public void Parse_WithHeaderOnly_ReturnsEmptyList()
    {
        var csv = "Name,Age";
        var result = CsvHelper.Parse(csv);
        Assert.Empty(result);
    }

    [Fact]
    public void Generate_WithValidData_ReturnsCsv()
    {
        var data = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "Name", "John" }, { "Age", "30" } },
            new Dictionary<string, string> { { "Name", "Jane" }, { "Age", "25" } }
        };
        
        var result = CsvHelper.Generate(data);
        Assert.Contains("Name,Age", result);
        Assert.Contains("John,30", result);
        Assert.Contains("Jane,25", result);
    }

    [Fact]
    public void Generate_WithEmptyList_ReturnsEmpty()
    {
        var result = CsvHelper.Generate(new List<Dictionary<string, string>>());
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void Generate_WithNull_ReturnsEmpty()
    {
        var result = CsvHelper.Generate(null);
        Assert.Equal(string.Empty, result);
    }
}
