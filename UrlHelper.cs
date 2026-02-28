using System;
using System.Collections.Generic;

public static class UrlHelper
{
    public static string Encode(string value)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return Uri.EscapeDataString(value);
    }

    public static string Decode(string value)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return Uri.UnescapeDataString(value);
    }

    public static Dictionary<string, string> ParseQuery(string query)
    {
        var result = new Dictionary<string, string>();
        if (string.IsNullOrEmpty(query)) return result;
        
        query = query.TrimStart('?');
        var pairs = query.Split('&');
        
        foreach (var pair in pairs)
        {
            if (string.IsNullOrEmpty(pair)) continue;
            var parts = pair.Split('=', 2);
            var key = Decode(parts[0]);
            var value = parts.Length > 1 ? Decode(parts[1]) : "";
            result[key] = value;
        }
        
        return result;
    }
}
