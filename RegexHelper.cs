using System.Text.RegularExpressions;

public static class RegexHelper
{
    public static bool IsMatch(string input, string pattern)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern)) return false;
        return Regex.IsMatch(input, pattern);
    }

    public static string[] Extract(string input, string pattern)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern)) return new string[0];
        var matches = Regex.Matches(input, pattern);
        var results = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            results[i] = matches[i].Value;
        }
        return results;
    }
}
