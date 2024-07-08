using System;
using System.Collections.Generic;

public class Graph
{
    private int V;  // Number of vertices
    private List<(int, int)>[] adjacencyList;  // Adjacency list representation of the graph

    public Graph(int vertices)
    {
        V = vertices;
        adjacencyList = new List<(int, int)>[V];
        for (int i = 0; i < V; i++)
        {
            adjacencyList[i] = new List<(int, int)>();
        }
    }

    // Function to add an edge to the graph
    public void AddEdge(int src, int dest, int weight)
    {
        adjacencyList[src].Add((dest, weight));
        adjacencyList[dest].Add((src, weight)); // Assuming undirected graph
    }

    // Function to find MST using Prim's algorithm
    public List<(int, int, int)> PrimMST()
    {
        List<(int, int, int)> mst = new List<(int, int, int)>(); // list to store MST edges
        
        bool[] visited = new bool[V]; // bool array to track visited vertices
        int[] parent = new int[V];  // Array to store parent of each vertex in MST
        int[] key = new int[V];     // Array to store the minimum weight edge connecting vertex i to MST

        for (int i = 0; i < V; i++)
        {
            key[i] = int.MaxValue;  // Initialize all keys to infinity
        }

        // Priority queue (min-heap) to store vertices and their key values
        PriorityQueue<(int, int)> minHeap = new PriorityQueue<(int, int)>((x, y) => x.Item2.CompareTo(y.Item2));
        
        // Start with vertex 0
        key[0] = 0;
        minHeap.Enqueue((0, 0), 0);  // (vertex, key)

        while (minHeap.Count > 0)
        {
            var (u, _) = minHeap.Dequeue();

            if (visited[u])
                continue;

            visited[u] = true; // mark u as visited

            foreach (var (v, weight) in adjacencyList[u]) // iterate over neighbors of u
            {
                if (!visited[v] && weight < key[v]) // checks that the neighbor is not visited and the weight is less than the current key
                {
                    // v can potentially be a smaller weight edge than previously known
                    parent[v] = u;
                    key[v] = weight;
                    minHeap.Enqueue((v, weight), weight);
                }
            }
        }

        // Construct MST edges list
        for (int i = 1; i < V; i++)
        {
            mst.Add((parent[i], i, key[i]));
        }

        return mst;
    }

   
}

// Simple priority queue implementation using a sorted list
public class PriorityQueue<T>
{
    private SortedList<int, Queue<T>> _sortedList = new SortedList<int, Queue<T>>();
    private Comparison<T> Comparison;

    public int Count { get; private set; }

    public PriorityQueue(Comparison<T> comparison)
    {
        Comparison = comparison;
    }

    public void Enqueue(T item, int priority)
    {
        if (!_sortedList.ContainsKey(priority))
        {
            _sortedList[priority] = new Queue<T>();
        }
        _sortedList[priority].Enqueue(item);
        Count++;
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Priority queue is empty.");
        }

        var first = _sortedList.First();
        var item = first.Value.Dequeue();
        if (first.Value.Count == 0)
        {
            _sortedList.RemoveAt(0);
        }
        Count--;
        return item;
    }
}
