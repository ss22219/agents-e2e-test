using System;
using Xunit;

public class BitHelperTests
{
    [Fact]
    public void SetBit_SetsCorrectBit()
    {
        Assert.Equal(1, BitHelper.SetBit(0, 0));
        Assert.Equal(2, BitHelper.SetBit(0, 1));
        Assert.Equal(4, BitHelper.SetBit(0, 2));
        Assert.Equal(5, BitHelper.SetBit(1, 2));
    }

    [Fact]
    public void GetBit_ReturnsCorrectValue()
    {
        Assert.True(BitHelper.GetBit(1, 0));
        Assert.False(BitHelper.GetBit(1, 1));
        Assert.True(BitHelper.GetBit(5, 0));
        Assert.False(BitHelper.GetBit(5, 1));
        Assert.True(BitHelper.GetBit(5, 2));
    }

    [Fact]
    public void CountBits_ReturnsCorrectCount()
    {
        Assert.Equal(0, BitHelper.CountBits(0));
        Assert.Equal(1, BitHelper.CountBits(1));
        Assert.Equal(2, BitHelper.CountBits(3));
        Assert.Equal(3, BitHelper.CountBits(7));
        Assert.Equal(2, BitHelper.CountBits(5));
    }
}
