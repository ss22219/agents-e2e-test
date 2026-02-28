using System;
using System.IO;
using System.Linq;
using Xunit;

public class FileHelperTests
{
    [Fact]
    public void ReadLines_WithValidFile_ReturnsLines()
    {
        var tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, "line1\nline2\nline3");
        
        var lines = FileHelper.ReadLines(tempFile).ToList();
        
        Assert.Equal(3, lines.Count);
        Assert.Equal("line1", lines[0]);
        Assert.Equal("line2", lines[1]);
        Assert.Equal("line3", lines[2]);
        
        File.Delete(tempFile);
    }

    [Fact]
    public void ReadLines_WithEmptyFile_ReturnsEmpty()
    {
        var tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, "");
        
        var lines = FileHelper.ReadLines(tempFile).ToList();
        
        Assert.Empty(lines);
        
        File.Delete(tempFile);
    }

    [Fact]
    public void CountWords_WithValidFile_ReturnsWordCount()
    {
        var tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, "hello world\nfoo bar");
        
        var count = FileHelper.CountWords(tempFile);
        
        Assert.Equal(4, count);
        
        File.Delete(tempFile);
    }

    [Fact]
    public void CountWords_WithEmptyFile_ReturnsZero()
    {
        var tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, "");
        
        var count = FileHelper.CountWords(tempFile);
        
        Assert.Equal(0, count);
        
        File.Delete(tempFile);
    }

    [Fact]
    public void CountWords_WithMultipleSpaces_CountsCorrectly()
    {
        var tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, "hello  world   test");
        
        var count = FileHelper.CountWords(tempFile);
        
        Assert.Equal(3, count);
        
        File.Delete(tempFile);
    }
}
