using System;
using System.Collections.Generic;

public static class Pipeline
{
    public static Pipeline<T> AddStep<T>(Func<T, T> step)
    {
        return new Pipeline<T>().AddStep(step);
    }
}

public class Pipeline<T>
{
    private readonly List<Func<T, T>> _steps = new();

    public Pipeline<T> AddStep(Func<T, T> step)
    {
        if (step == null) throw new ArgumentNullException(nameof(step));
        _steps.Add(step);
        return this;
    }

    public T Execute(T input)
    {
        var result = input;
        foreach (var step in _steps)
        {
            result = step(result);
        }
        return result;
    }
}
