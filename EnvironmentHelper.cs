using System;

public static class EnvironmentHelper
{
    public static string GetVar(string name)
    {
        return Environment.GetEnvironmentVariable(name);
    }

    public static bool IsProduction()
    {
        var env = GetVar("ASPNETCORE_ENVIRONMENT") ?? GetVar("DOTNET_ENVIRONMENT") ?? "Production";
        return env.Equals("Production", StringComparison.OrdinalIgnoreCase);
    }
}
