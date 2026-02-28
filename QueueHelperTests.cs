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

    [Fact]
    public void TryDequeue_OnNonEmptyQueue_ReturnsTrue()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        QueueHelper.Enqueue(queue, "test", 1);
        Assert.True(QueueHelper.TryDequeue(queue, out var element, out var priority));
        Assert.Equal("test", element);
        Assert.Equal(1, priority);
    }

    [Fact]
    public void TryDequeue_OnEmptyQueue_ReturnsFalse()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        Assert.False(QueueHelper.TryDequeue(queue, out var element, out var priority));
    }

    [Fact]
    public void TryDequeue_WithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => QueueHelper.TryDequeue<string, int>(null, out _, out _));
    }

    [Fact]
    public void Peek_ReturnsElementWithoutRemoving()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        QueueHelper.Enqueue(queue, "test", 1);
        Assert.Equal("test", QueueHelper.Peek(queue));
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Peek_WithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => QueueHelper.Peek<string, int>(null));
    }

    [Fact]
    public void Peek_OnEmptyQueue_ThrowsInvalidOperationException()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        Assert.Throws<InvalidOperationException>(() => QueueHelper.Peek(queue));
    }

    [Fact]
    public void TryPeek_OnNonEmptyQueue_ReturnsTrue()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        QueueHelper.Enqueue(queue, "test", 1);
        Assert.True(QueueHelper.TryPeek(queue, out var element, out var priority));
        Assert.Equal("test", element);
        Assert.Equal(1, priority);
        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void TryPeek_OnEmptyQueue_ReturnsFalse()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        Assert.False(QueueHelper.TryPeek(queue, out var element, out var priority));
    }

    [Fact]
    public void TryPeek_WithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => QueueHelper.TryPeek<string, int>(null, out _, out _));
    }

    [Fact]
    public void Clear_RemovesAllElements()
    {
        var queue = QueueHelper.CreatePriorityQueue<string, int>();
        QueueHelper.Enqueue(queue, "test1", 1);
        QueueHelper.Enqueue(queue, "test2", 2);
        QueueHelper.Clear(queue);
        Assert.Equal(0, queue.Count);
    }

    [Fact]
    public void Clear_WithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => QueueHelper.Clear<string, int>(null));
    }
}
