using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class FileHelper
{
    public static IEnumerable<string> ReadLines(string filePath)
    {
        return File.ReadLines(filePath);
    }

    public static int CountWords(string filePath)
    {
        return File.ReadLines(filePath)
            .SelectMany(line => line.Split(new[] { ' ', '\t', '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries))
            .Count();
    }
}
