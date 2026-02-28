using System;
using System.Collections.Generic;

public static class EventBus
{
    private static readonly Dictionary<Type, List<Delegate>> _handlers = new();

    public static void Subscribe<T>(Action<T> handler)
    {
        var type = typeof(T);
        if (!_handlers.ContainsKey(type))
            _handlers[type] = new List<Delegate>();
        _handlers[type].Add(handler);
    }

    public static void Publish<T>(T eventData)
    {
        var type = typeof(T);
        if (_handlers.TryGetValue(type, out var handlers))
        {
            foreach (var handler in handlers)
                ((Action<T>)handler)(eventData);
        }
    }
}
