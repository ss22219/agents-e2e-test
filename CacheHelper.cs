using System.Collections.Generic;

public static class CacheHelper
{
    private static readonly Dictionary<string, object> _cache = new Dictionary<string, object>();

    public static void Set(string key, object value)
    {
        _cache[key] = value;
    }

    public static T Get<T>(string key)
    {
        return _cache.TryGetValue(key, out var value) ? (T)value : default;
    }

    public static void Remove(string key)
    {
        _cache.Remove(key);
    }
}
