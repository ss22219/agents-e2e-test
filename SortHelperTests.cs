using System;
using Xunit;

public class SortHelperTests
{
    [Fact]
    public void QuickSort_WithUnsortedArray_SortsCorrectly()
    {
        int[] arr = { 5, 2, 8, 1, 9 };
        SortHelper.QuickSort(arr);
        Assert.Equal(new[] { 1, 2, 5, 8, 9 }, arr);
    }

    [Fact]
    public void QuickSort_WithSortedArray_RemainsSorted()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        SortHelper.QuickSort(arr);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, arr);
    }

    [Fact]
    public void QuickSort_WithEmptyArray_DoesNothing()
    {
        int[] arr = { };
        SortHelper.QuickSort(arr);
        Assert.Empty(arr);
    }

    [Fact]
    public void QuickSort_WithNull_DoesNothing()
    {
        int[] arr = null;
        SortHelper.QuickSort(arr);
        Assert.Null(arr);
    }

    [Fact]
    public void QuickSort_WithSingleElement_DoesNothing()
    {
        int[] arr = { 42 };
        SortHelper.QuickSort(arr);
        Assert.Equal(new[] { 42 }, arr);
    }

    [Fact]
    public void MergeSort_WithUnsortedArray_SortsCorrectly()
    {
        int[] arr = { 5, 2, 8, 1, 9 };
        SortHelper.MergeSort(arr);
        Assert.Equal(new[] { 1, 2, 5, 8, 9 }, arr);
    }

    [Fact]
    public void MergeSort_WithSortedArray_RemainsSorted()
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        SortHelper.MergeSort(arr);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, arr);
    }

    [Fact]
    public void MergeSort_WithEmptyArray_DoesNothing()
    {
        int[] arr = { };
        SortHelper.MergeSort(arr);
        Assert.Empty(arr);
    }

    [Fact]
    public void MergeSort_WithNull_DoesNothing()
    {
        int[] arr = null;
        SortHelper.MergeSort(arr);
        Assert.Null(arr);
    }

    [Fact]
    public void MergeSort_WithSingleElement_DoesNothing()
    {
        int[] arr = { 42 };
        SortHelper.MergeSort(arr);
        Assert.Equal(new[] { 42 }, arr);
    }
}
