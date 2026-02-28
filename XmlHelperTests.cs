using System;
using Xunit;

public class XmlHelperTests
{
    public class TestPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [Fact]
    public void Serialize_WithValidObject_ReturnsXml()
    {
        var person = new TestPerson { Name = "John", Age = 30 };
        var xml = XmlHelper.Serialize(person);
        Assert.NotNull(xml);
        Assert.Contains("<Name>John</Name>", xml);
        Assert.Contains("<Age>30</Age>", xml);
    }

    [Fact]
    public void Serialize_WithNull_ReturnsNull()
    {
        Assert.Null(XmlHelper.Serialize<TestPerson>(null));
    }

    [Fact]
    public void Deserialize_WithValidXml_ReturnsObject()
    {
        var xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><TestPerson><Name>Jane</Name><Age>25</Age></TestPerson>";
        var person = XmlHelper.Deserialize<TestPerson>(xml);
        Assert.NotNull(person);
        Assert.Equal("Jane", person.Name);
        Assert.Equal(25, person.Age);
    }

    [Fact]
    public void Deserialize_WithEmptyString_ReturnsDefault()
    {
        Assert.Null(XmlHelper.Deserialize<TestPerson>(""));
    }

    [Fact]
    public void Deserialize_WithNull_ReturnsDefault()
    {
        Assert.Null(XmlHelper.Deserialize<TestPerson>(null));
    }

    [Fact]
    public void SerializeDeserialize_RoundTrip_PreservesData()
    {
        var original = new TestPerson { Name = "Bob", Age = 40 };
        var xml = XmlHelper.Serialize(original);
        var deserialized = XmlHelper.Deserialize<TestPerson>(xml);
        Assert.Equal(original.Name, deserialized.Name);
        Assert.Equal(original.Age, deserialized.Age);
    }
}
