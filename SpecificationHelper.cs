using System;

public static class SpecificationHelper
{
    public static Func<T, bool> And<T>(Func<T, bool> left, Func<T, bool> right)
    {
        return x => left(x) && right(x);
    }

    public static Func<T, bool> Or<T>(Func<T, bool> left, Func<T, bool> right)
    {
        return x => left(x) || right(x);
    }

    public static Func<T, bool> Not<T>(Func<T, bool> spec)
    {
        return x => !spec(x);
    }
}
