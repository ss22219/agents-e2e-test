using System;
using System.Collections.Generic;

public static class HealthCheck
{
    private static readonly Dictionary<string, Func<bool>> _checks = new Dictionary<string, Func<bool>>();

    public static void AddCheck(string name, Func<bool> check)
    {
        _checks[name] = check;
    }

    public static Dictionary<string, bool> RunAll()
    {
        var results = new Dictionary<string, bool>();
        foreach (var check in _checks)
        {
            results[check.Key] = check.Value();
        }
        return results;
    }

    public static void Clear()
    {
        _checks.Clear();
    }
}
