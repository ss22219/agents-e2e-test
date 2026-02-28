using System.Collections.Generic;

public static class TemplateEngine
{
    public static string Render(string template, Dictionary<string, string> variables)
    {
        if (string.IsNullOrEmpty(template) || variables == null) return template;
        
        foreach (var kvp in variables)
        {
            template = template.Replace($"{{{{{kvp.Key}}}}}", kvp.Value);
        }
        
        return template;
    }
}
