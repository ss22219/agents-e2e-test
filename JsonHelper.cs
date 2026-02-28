using System.Text.Json;

public static class JsonHelper
{
    public static string Serialize<T>(T obj)
    {
        if (obj == null) return null;
        return JsonSerializer.Serialize(obj);
    }

    public static T Deserialize<T>(string json)
    {
        if (string.IsNullOrEmpty(json)) return default(T);
        return JsonSerializer.Deserialize<T>(json);
    }
}
