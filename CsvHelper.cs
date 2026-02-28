using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class CsvHelper
{
    public static List<Dictionary<string, string>> Parse(string csv)
    {
        if (string.IsNullOrEmpty(csv)) return new List<Dictionary<string, string>>();
        
        var lines = csv.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        if (lines.Length == 0) return new List<Dictionary<string, string>>();
        
        var headers = lines[0].Split(',').Select(h => h.Trim()).ToArray();
        var result = new List<Dictionary<string, string>>();
        
        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',').Select(v => v.Trim()).ToArray();
            var row = new Dictionary<string, string>();
            for (int j = 0; j < headers.Length && j < values.Length; j++)
            {
                row[headers[j]] = values[j];
            }
            result.Add(row);
        }
        
        return result;
    }

    public static string Generate(List<Dictionary<string, string>> data)
    {
        if (data == null || data.Count == 0) return string.Empty;
        
        var headers = data[0].Keys.ToList();
        var sb = new StringBuilder();
        sb.AppendLine(string.Join(",", headers));
        
        foreach (var row in data)
        {
            var values = headers.Select(h => row.ContainsKey(h) ? row[h] : string.Empty);
            sb.AppendLine(string.Join(",", values));
        }
        
        return sb.ToString().TrimEnd('\r', '\n');
    }
}
