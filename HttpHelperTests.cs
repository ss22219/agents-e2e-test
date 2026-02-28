using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class HttpHelperTests
{
    [Fact]
    public async Task GetAsync_WithValidUrl_ReturnsContent()
    {
        var content = await HttpHelper.GetAsync("https://httpbin.org/get");
        Assert.NotNull(content);
        Assert.NotEmpty(content);
    }

    [Fact]
    public async Task GetAsync_WithInvalidUrl_ThrowsException()
    {
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await HttpHelper.GetAsync("https://httpbin.org/status/404");
        });
    }

    [Fact]
    public async Task PostAsync_WithValidUrl_ReturnsContent()
    {
        var postContent = new StringContent("{\"test\":\"data\"}");
        var response = await HttpHelper.PostAsync("https://httpbin.org/post", postContent);
        Assert.NotNull(response);
        Assert.NotEmpty(response);
    }

    [Fact]
    public async Task PostAsync_WithInvalidUrl_ThrowsException()
    {
        var postContent = new StringContent("test");
        await Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await HttpHelper.PostAsync("https://httpbin.org/status/500", postContent);
        });
    }
}
