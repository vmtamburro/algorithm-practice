
using System;
using System.Collections.Generic;

public class DijkstrasAlgo
{
    private Dictionary<int, List<(int destination, int weight)>> _adjacencyList;

    public DijkstrasAlgo()
    {
        _adjacencyList = new Dictionary<int, List<(int destination, int weight)>>();
    }

    public void AddVertex(int vertex)
    {
        if (!_adjacencyList.ContainsKey(vertex))
        {
            _adjacencyList[vertex] = new List<(int destination, int weight)>();
        }
    }

    public void AddEdge(int source, int destination, int weight)
    {
        if (!_adjacencyList.ContainsKey(source))
        {
            AddVertex(source);
        }
        if (!_adjacencyList.ContainsKey(destination))
        {
            AddVertex(destination);
        }
        _adjacencyList[source].Add((destination, weight));
    }

    public Dictionary<int, int> Dijkstra(int startVertex)
    {
        var distances = new Dictionary<int, int>();
        var priorityQueue = new SortedSet<(int distance, int vertex)>();
        var visited = new HashSet<int>();

        // Initialize distances and priority queue
        foreach (var vertex in _adjacencyList.Keys)
        {
            distances[vertex] = int.MaxValue;
        }
        distances[startVertex] = 0;
        priorityQueue.Add((0, startVertex));

        while (priorityQueue.Count > 0)
        {
            var (currentDistance, currentVertex) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);
            if (visited.Contains(currentVertex)) continue;
            visited.Add(currentVertex);

            foreach (var (neighbor, weight) in _adjacencyList[currentVertex])
            {
                if (visited.Contains(neighbor)) continue;
                var newDistance = currentDistance + weight;
                if (newDistance < distances[neighbor])
                {
                    distances[neighbor] = newDistance;
                    priorityQueue.Add((newDistance, neighbor));
                }
            }
        }

        return distances;
    }
}
