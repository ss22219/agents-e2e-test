using System;

public static class EnumHelper
{
    public static T Parse<T>(string value) where T : struct, Enum
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException(nameof(value));
        
        if (Enum.TryParse<T>(value, ignoreCase: true, out var result))
            return result;
        
        throw new ArgumentException($"Value '{value}' is not valid for enum type {typeof(T).Name}");
    }

    public static T[] GetValues<T>() where T : struct, Enum
    {
        return (T[])Enum.GetValues(typeof(T));
    }
}
