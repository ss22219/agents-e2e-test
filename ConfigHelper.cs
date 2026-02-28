using Microsoft.Extensions.Configuration;

public static class ConfigHelper
{
    public static string GetValue(IConfiguration configuration, string key)
    {
        return configuration[key];
    }

    public static IConfigurationSection GetSection(IConfiguration configuration, string sectionName)
    {
        return configuration.GetSection(sectionName);
    }
}
