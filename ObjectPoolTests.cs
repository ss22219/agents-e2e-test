using System;
using Xunit;

public class ObjectPoolTests
{
    private class TestObject
    {
        public int Value { get; set; }
    }

    private class AnotherTestObject
    {
        public string Name { get; set; }
    }

    [Fact]
    public void Rent_CreatesNewObject_WhenPoolIsEmpty()
    {
        var obj = ObjectPool.Rent<TestObject>();
        Assert.NotNull(obj);
    }

    [Fact]
    public void Return_StoresObjectInPool()
    {
        var obj = new TestObject { Value = 42 };
        ObjectPool.Return(obj);
        Assert.NotNull(obj);
    }

    [Fact]
    public void Rent_ReturnsPooledObject_AfterReturn()
    {
        var obj = new TestObject { Value = 99 };
        ObjectPool.Return(obj);
        var rentedObj = ObjectPool.Rent<TestObject>();
        Assert.Equal(99, rentedObj.Value);
    }

    [Fact]
    public void Return_ThrowsArgumentNullException_WhenItemIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => ObjectPool.Return<TestObject>(null));
    }

    [Fact]
    public void Rent_WorksWithMultipleTypes()
    {
        var obj1 = ObjectPool.Rent<TestObject>();
        var obj2 = ObjectPool.Rent<AnotherTestObject>();
        Assert.NotNull(obj1);
        Assert.NotNull(obj2);
    }
}
