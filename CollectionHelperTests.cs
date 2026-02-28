using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class CollectionHelperTests
{
    [Fact]
    public void Shuffle_WithList_ChangesOrder()
    {
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var original = new List<int>(list);
        CollectionHelper.Shuffle(list);
        Assert.NotEqual(original, list);
        Assert.Equal(original.OrderBy(x => x), list.OrderBy(x => x));
    }

    [Fact]
    public void Shuffle_WithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => CollectionHelper.Shuffle<int>(null));
    }

    [Fact]
    public void Shuffle_WithEmptyList_DoesNotThrow()
    {
        var list = new List<int>();
        CollectionHelper.Shuffle(list);
        Assert.Empty(list);
    }

    [Fact]
    public void Shuffle_WithSingleElement_RemainsUnchanged()
    {
        var list = new List<int> { 1 };
        CollectionHelper.Shuffle(list);
        Assert.Single(list);
        Assert.Equal(1, list[0]);
    }

    [Fact]
    public void Distinct_WithDuplicates_ReturnsUniqueElements()
    {
        var source = new List<int> { 1, 2, 2, 3, 3, 3, 4 };
        var result = CollectionHelper.Distinct(source);
        Assert.Equal(new[] { 1, 2, 3, 4 }, result);
    }

    [Fact]
    public void Distinct_WithNoDuplicates_ReturnsSameElements()
    {
        var source = new List<int> { 1, 2, 3, 4 };
        var result = CollectionHelper.Distinct(source);
        Assert.Equal(new[] { 1, 2, 3, 4 }, result);
    }

    [Fact]
    public void Distinct_WithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => CollectionHelper.Distinct<int>(null));
    }

    [Fact]
    public void Distinct_WithEmptyCollection_ReturnsEmpty()
    {
        var source = new List<int>();
        var result = CollectionHelper.Distinct(source);
        Assert.Empty(result);
    }
}
