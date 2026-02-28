using System;
using System.Text;
using Xunit;

public class CompressHelperTests
{
    [Fact]
    public void GzipCompress_WithValidData_ReturnsCompressedData()
    {
        var data = Encoding.UTF8.GetBytes("hello world");
        
        var compressed = CompressHelper.GzipCompress(data);
        
        Assert.NotNull(compressed);
        Assert.NotEmpty(compressed);
        Assert.True(compressed.Length < data.Length);
    }

    [Fact]
    public void GzipCompress_WithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => CompressHelper.GzipCompress(null));
    }

    [Fact]
    public void GzipCompress_WithEmptyData_ReturnsCompressedData()
    {
        var data = new byte[0];
        
        var compressed = CompressHelper.GzipCompress(data);
        
        Assert.NotNull(compressed);
    }

    [Fact]
    public void GzipDecompress_WithCompressedData_ReturnsOriginalData()
    {
        var original = Encoding.UTF8.GetBytes("hello world");
        var compressed = CompressHelper.GzipCompress(original);
        
        var decompressed = CompressHelper.GzipDecompress(compressed);
        
        Assert.Equal(original, decompressed);
    }

    [Fact]
    public void GzipDecompress_WithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => CompressHelper.GzipDecompress(null));
    }

    [Fact]
    public void GzipDecompress_WithEmptyData_ReturnsEmptyData()
    {
        var original = new byte[0];
        var compressed = CompressHelper.GzipCompress(original);
        
        var decompressed = CompressHelper.GzipDecompress(compressed);
        
        Assert.Equal(original, decompressed);
    }

    [Fact]
    public void GzipCompress_And_GzipDecompress_RoundTrip_WithLargeData()
    {
        var original = Encoding.UTF8.GetBytes(new string('a', 10000));
        
        var compressed = CompressHelper.GzipCompress(original);
        var decompressed = CompressHelper.GzipDecompress(compressed);
        
        Assert.Equal(original, decompressed);
    }
}
