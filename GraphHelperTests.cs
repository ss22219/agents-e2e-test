using System;
using Xunit;

public class GraphHelperTests
{
    [Fact]
    public void Dijkstra_WithSimpleGraph_ReturnsShortestPaths()
    {
        int[,] graph = {
            { 0, 4, 0, 0, 0 },
            { 4, 0, 8, 0, 0 },
            { 0, 8, 0, 7, 9 },
            { 0, 0, 7, 0, 10 },
            { 0, 0, 9, 10, 0 }
        };
        
        int[] result = GraphHelper.Dijkstra(graph, 0);
        
        Assert.Equal(0, result[0]);
        Assert.Equal(4, result[1]);
        Assert.Equal(12, result[2]);
        Assert.Equal(19, result[3]);
        Assert.Equal(21, result[4]);
    }

    [Fact]
    public void Dijkstra_WithDisconnectedNode_ReturnsMaxValue()
    {
        int[,] graph = {
            { 0, 1, 0 },
            { 1, 0, 0 },
            { 0, 0, 0 }
        };
        
        int[] result = GraphHelper.Dijkstra(graph, 0);
        
        Assert.Equal(0, result[0]);
        Assert.Equal(1, result[1]);
        Assert.Equal(int.MaxValue, result[2]);
    }

    [Fact]
    public void Dijkstra_WithSingleNode_ReturnsZero()
    {
        int[,] graph = { { 0 } };
        
        int[] result = GraphHelper.Dijkstra(graph, 0);
        
        Assert.Equal(0, result[0]);
    }

    [Fact]
    public void Dijkstra_WithDirectPath_ReturnsDirectDistance()
    {
        int[,] graph = {
            { 0, 5, 0 },
            { 5, 0, 3 },
            { 0, 3, 0 }
        };
        
        int[] result = GraphHelper.Dijkstra(graph, 0);
        
        Assert.Equal(0, result[0]);
        Assert.Equal(5, result[1]);
        Assert.Equal(8, result[2]);
    }
}
