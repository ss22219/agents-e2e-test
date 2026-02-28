using System.Net.Http;
using System.Threading.Tasks;

public static class HttpHelper
{
    private static readonly HttpClient _client = new HttpClient();

    public static async Task<string> GetAsync(string url)
    {
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public static async Task<string> PostAsync(string url, HttpContent content)
    {
        var response = await _client.PostAsync(url, content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}
