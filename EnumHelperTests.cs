using System;
using Xunit;

public class EnumHelperTests
{
    private enum Color { Red, Green, Blue }
    private enum Status { Active, Inactive, Pending }

    [Fact]
    public void Parse_WithValidValue_ReturnsEnumValue()
    {
        Assert.Equal(Color.Red, EnumHelper.Parse<Color>("Red"));
        Assert.Equal(Color.Green, EnumHelper.Parse<Color>("Green"));
        Assert.Equal(Color.Blue, EnumHelper.Parse<Color>("Blue"));
    }

    [Fact]
    public void Parse_WithLowerCaseValue_ReturnsEnumValue()
    {
        Assert.Equal(Color.Red, EnumHelper.Parse<Color>("red"));
        Assert.Equal(Color.Green, EnumHelper.Parse<Color>("green"));
    }

    [Fact]
    public void Parse_WithMixedCaseValue_ReturnsEnumValue()
    {
        Assert.Equal(Color.Red, EnumHelper.Parse<Color>("rEd"));
        Assert.Equal(Color.Green, EnumHelper.Parse<Color>("GrEeN"));
    }

    [Fact]
    public void Parse_WithInvalidValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => EnumHelper.Parse<Color>("Yellow"));
    }

    [Fact]
    public void Parse_WithNullValue_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => EnumHelper.Parse<Color>(null));
    }

    [Fact]
    public void Parse_WithEmptyValue_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => EnumHelper.Parse<Color>(""));
    }

    [Fact]
    public void GetValues_ReturnsAllEnumValues()
    {
        var values = EnumHelper.GetValues<Color>();
        Assert.Equal(3, values.Length);
        Assert.Contains(Color.Red, values);
        Assert.Contains(Color.Green, values);
        Assert.Contains(Color.Blue, values);
    }

    [Fact]
    public void GetValues_WithDifferentEnum_ReturnsCorrectValues()
    {
        var values = EnumHelper.GetValues<Status>();
        Assert.Equal(3, values.Length);
        Assert.Contains(Status.Active, values);
        Assert.Contains(Status.Inactive, values);
        Assert.Contains(Status.Pending, values);
    }

    [Fact]
    public void GetValues_ReturnsValuesInOrder()
    {
        var values = EnumHelper.GetValues<Color>();
        Assert.Equal(Color.Red, values[0]);
        Assert.Equal(Color.Green, values[1]);
        Assert.Equal(Color.Blue, values[2]);
    }
}
