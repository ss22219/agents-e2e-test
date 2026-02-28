using System;
using System.Collections.Generic;

public static class QueueHelper
{
    public static PriorityQueue<TElement, TPriority> CreatePriorityQueue<TElement, TPriority>()
    {
        return new PriorityQueue<TElement, TPriority>();
    }

    public static void Enqueue<TElement, TPriority>(PriorityQueue<TElement, TPriority> queue, TElement element, TPriority priority)
    {
        if (queue == null) throw new ArgumentNullException(nameof(queue));
        queue.Enqueue(element, priority);
    }

    public static TElement Dequeue<TElement, TPriority>(PriorityQueue<TElement, TPriority> queue)
    {
        if (queue == null) throw new ArgumentNullException(nameof(queue));
        return queue.Dequeue();
    }
}
