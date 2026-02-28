using System;
using System.Collections.Generic;
using Xunit;

public class QueueHelperTests
{
    [Fact]
    public void CreatePriorityQueue_ReturnsNewQueue()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        Assert.NotNull(queue);
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Enqueue_AddsElementToQueue()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        QueueHelper.Enqueue(queue, "test", 1);
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Enqueue_WithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => QueueHelper.Enqueue<string, int>(null, "test", 1));
    }

    [Fact]
    public void Dequeue_ReturnsElementWithHighestPriority()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        QueueHelper.Enqueue(queue, "low", 3);
        QueueHelper.Enqueue(queue, "high", 1);
        QueueHelper.Enqueue(queue, "medium", 2);
        Assert.Equal("high", QueueHelper.Dequeue(queue));
        Assert.Equal("medium", QueueHelper.Dequeue(queue));
        Assert.Equal("low", QueueHelper.Dequeue(queue));
    }

    [Fact]
    public void Dequeue_WithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => QueueHelper.Dequeue<string, int>(null));
    }

    [Fact]
    public void Dequeue_OnEmptyQueue_ThrowsInvalidOperationException()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        Assert.Throws<InvalidOperationException>(() => QueueHelper.Dequeue(queue));
    }
}
