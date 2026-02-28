using System;
using System.Collections.Generic;
using System.Linq;

public static class CollectionHelper
{
    public static void Shuffle<T>(IList<T> list)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        var rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static IEnumerable<T> Distinct<T>(IEnumerable<T> source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        return source.Distinct();
    }
}
