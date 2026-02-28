using System;
using System.Text.RegularExpressions;

public static class MarkdownHelper
{
    public static string ToHtml(string markdown)
    {
        if (string.IsNullOrEmpty(markdown)) return markdown;
        
        var html = markdown;
        
        // Bold: **text** -> <strong>text</strong>
        html = Regex.Replace(html, @"\*\*(.*?)\*\*", "<strong>$1</strong>");
        
        // Italic: *text* -> <em>text</em>
        html = Regex.Replace(html, @"\*(.*?)\*", "<em>$1</em>");
        
        // Headers: # text -> <h1>text</h1>, ## text -> <h2>text</h2>, etc.
        html = Regex.Replace(html, @"^### (.*?)$", "<h3>$1</h3>", RegexOptions.Multiline);
        html = Regex.Replace(html, @"^## (.*?)$", "<h2>$1</h2>", RegexOptions.Multiline);
        html = Regex.Replace(html, @"^# (.*?)$", "<h1>$1</h1>", RegexOptions.Multiline);
        
        // Line breaks: \n -> <br>
        html = html.Replace("\n", "<br>");
        
        return html;
    }

    public static string StripTags(string html)
    {
        if (string.IsNullOrEmpty(html)) return html;
        
        return Regex.Replace(html, @"<[^>]+>", "");
    }
}
