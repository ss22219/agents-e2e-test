using System;

public static class GuardHelper
{
    public static void NotNull<T>(T value, string paramName) where T : class
    {
        if (value == null)
            throw new ArgumentNullException(paramName);
    }

    public static void InRange(int value, int min, int max, string paramName)
    {
        if (value < min || value > max)
            throw new ArgumentOutOfRangeException(paramName, $"Value must be between {min} and {max}.");
    }
}
