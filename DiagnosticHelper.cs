using System;
using System.Diagnostics;

public static class DiagnosticHelper
{
    public static Stopwatch StartStopwatch()
    {
        var sw = new Stopwatch();
        sw.Start();
        return sw;
    }

    public static long GetMemoryUsage()
    {
        return GC.GetTotalMemory(false);
    }
}
