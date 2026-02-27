using System;

public static class StringHelper
{
    public static string Reverse(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        char[] chars = input.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    public static bool IsPalindrome(string input)
    {
        if (string.IsNullOrEmpty(input)) return true;
        return input.Equals(Reverse(input), StringComparison.OrdinalIgnoreCase);
    }
}
