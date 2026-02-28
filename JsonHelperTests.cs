using System;
using Xunit;

public class JsonHelperTests
{
    public class TestPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [Fact]
    public void Serialize_WithValidObject_ReturnsJson()
    {
        var person = new TestPerson { Name = "John", Age = 30 };
        var json = JsonHelper.Serialize(person);
        Assert.NotNull(json);
        Assert.Contains("John", json);
        Assert.Contains("30", json);
    }

    [Fact]
    public void Serialize_WithNull_ReturnsNull()
    {
        Assert.Null(JsonHelper.Serialize<TestPerson>(null));
    }

    [Fact]
    public void Deserialize_WithValidJson_ReturnsObject()
    {
        var json = "{\"Name\":\"Jane\",\"Age\":25}";
        var person = JsonHelper.Deserialize<TestPerson>(json);
        Assert.NotNull(person);
        Assert.Equal("Jane", person.Name);
        Assert.Equal(25, person.Age);
    }

    [Fact]
    public void Deserialize_WithEmptyString_ReturnsDefault()
    {
        Assert.Null(JsonHelper.Deserialize<TestPerson>(""));
    }

    [Fact]
    public void Deserialize_WithNull_ReturnsDefault()
    {
        Assert.Null(JsonHelper.Deserialize<TestPerson>(null));
    }

    [Fact]
    public void SerializeDeserialize_RoundTrip_PreservesData()
    {
        var original = new TestPerson { Name = "Bob", Age = 40 };
        var json = JsonHelper.Serialize(original);
        var deserialized = JsonHelper.Deserialize<TestPerson>(json);
        Assert.Equal(original.Name, deserialized.Name);
        Assert.Equal(original.Age, deserialized.Age);
    }
}
