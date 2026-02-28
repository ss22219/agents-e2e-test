using System;
using System.Collections.Concurrent;

public static class ObjectPool
{
    private static readonly ConcurrentDictionary<Type, object> _pools = new();

    public static T Rent<T>() where T : class, new()
    {
        var pool = (ConcurrentBag<T>)_pools.GetOrAdd(typeof(T), _ => new ConcurrentBag<T>());
        return pool.TryTake(out var item) ? item : new T();
    }

    public static void Return<T>(T item) where T : class
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        var pool = (ConcurrentBag<T>)_pools.GetOrAdd(typeof(T), _ => new ConcurrentBag<T>());
        pool.Add(item);
    }
}
