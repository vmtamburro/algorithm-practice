using System;
using System.Collections.Generic;

public class GraphAdjacencyList
{
    private Dictionary<int, List<int>> _adjacencyList;

    public GraphAdjacencyList()
    {
        _adjacencyList = new Dictionary<int, List<int>>();
    }

    public void AddVertex(int vertex)
    {
        if (!_adjacencyList.ContainsKey(vertex))
        {
            _adjacencyList[vertex] = new List<int>();
        }
    }

    public void AddEdge(int vertex1, int vertex2, bool isDirected = false)
    {
        if (!_adjacencyList.ContainsKey(vertex1))
        {
            AddVertex(vertex1);
        }
        if (!_adjacencyList.ContainsKey(vertex2))
        {
            AddVertex(vertex2);
        }

        _adjacencyList[vertex1].Add(vertex2);

        if (!isDirected)
        {
            _adjacencyList[vertex2].Add(vertex1);
        }
    }

    public void PrintGraph()
    {
        foreach (var vertex in _adjacencyList)
        {
            Console.Write(vertex.Key + ": ");
            foreach (var edge in vertex.Value)
            {
                Console.Write(edge + " ");
            }
            Console.WriteLine();
        }
    }
}