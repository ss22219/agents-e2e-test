using System.Threading.Tasks;
using Xunit;

public class ProcessHelperTests
{
    [Fact]
    public void Run_WithEchoCommand_ReturnsOutput()
    {
        string result = ProcessHelper.Run("cmd", "/c echo test");
        Assert.Contains("test", result);
    }

    [Fact]
    public void Run_WithEmptyArguments_ExecutesCommand()
    {
        string result = ProcessHelper.Run("cmd", "/c echo hello");
        Assert.Contains("hello", result);
    }

    [Fact]
    public async Task RunAsync_WithEchoCommand_ReturnsOutput()
    {
        string result = await ProcessHelper.RunAsync("cmd", "/c echo test");
        Assert.Contains("test", result);
    }

    [Fact]
    public async Task RunAsync_WithEmptyArguments_ExecutesCommand()
    {
        string result = await ProcessHelper.RunAsync("cmd", "/c echo hello");
        Assert.Contains("hello", result);
    }
}
