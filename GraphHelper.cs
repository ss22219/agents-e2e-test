using System;
using System.Collections.Generic;
using System.Linq;

public static class GraphHelper
{
    public static int[] Dijkstra(int[,] graph, int source)
    {
        int n = graph.GetLength(0);
        int[] dist = new int[n];
        bool[] visited = new bool[n];
        
        for (int i = 0; i < n; i++)
            dist[i] = int.MaxValue;
        dist[source] = 0;
        
        for (int count = 0; count < n - 1; count++)
        {
            int u = -1;
            for (int i = 0; i < n; i++)
                if (!visited[i] && (u == -1 || dist[i] < dist[u]))
                    u = i;
            
            visited[u] = true;
            
            for (int v = 0; v < n; v++)
                if (!visited[v] && graph[u, v] > 0 && dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }
        
        return dist;
    }
}
