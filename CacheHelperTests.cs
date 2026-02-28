using Xunit;

public class CacheHelperTests
{
    [Fact]
    public void Set_And_Get_ReturnsValue()
    {
        CacheHelper.Set("key1", "value1");
        Assert.Equal("value1", CacheHelper.Get<string>("key1"));
    }

    [Fact]
    public void Get_NonExistentKey_ReturnsDefault()
    {
        Assert.Null(CacheHelper.Get<string>("nonexistent"));
        Assert.Equal(0, CacheHelper.Get<int>("nonexistent"));
    }

    [Fact]
    public void Set_OverwritesExistingValue()
    {
        CacheHelper.Set("key2", "value1");
        CacheHelper.Set("key2", "value2");
        Assert.Equal("value2", CacheHelper.Get<string>("key2"));
    }

    [Fact]
    public void Remove_DeletesKey()
    {
        CacheHelper.Set("key3", "value3");
        CacheHelper.Remove("key3");
        Assert.Null(CacheHelper.Get<string>("key3"));
    }

    [Fact]
    public void Remove_NonExistentKey_DoesNotThrow()
    {
        CacheHelper.Remove("nonexistent");
    }

    [Fact]
    public void Set_And_Get_WithDifferentTypes()
    {
        CacheHelper.Set("int", 42);
        CacheHelper.Set("bool", true);
        Assert.Equal(42, CacheHelper.Get<int>("int"));
        Assert.True(CacheHelper.Get<bool>("bool"));
    }
}
