/*
    Given a directed graph, design an algorithm to find out whether there is a route between two nodes.

    Time complexity O(V + E)
    
*/

using Example;

public class RouteBetweenNodes{

        
    public class Graph
    {

        /* 
            Prim's Algorithm
            - Prim's algorithm is a greedy algorithm that finds a minimum spanning tree for a weighted undirected graph.
            - Time Complexity O(V^2) using adjacency matrix, O(E log V) using adjacency list and priority queue
            - Space Complexity O(V + E) for the adjacency list and priority queue
        */
        private int V;  // Number of vertices
        public List<int>[] adjacencyList;  // Adjacency list representation of the graph

        public Graph(int vertices)
        {
            V = vertices;
            adjacencyList = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }
    }
    public bool SearchBFS(Graph g, int start, int end){
        if(start == end) return true;

        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(start);
        visited.Add(start);

        while(queue.Count > 0){
            var vertex = queue.Dequeue();
            if(vertex == end) return true;

            foreach(var neighbor in g.adjacencyList[vertex]){
                if(!visited.Contains(neighbor)){
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;
    }

    public bool SearchDFS(Graph g, int start, int end){
            var visited = new HashSet<int>();
            return DFSUtil(g, start, end, visited);
    }

    public bool DFSUtil(Graph g, int start, int end, HashSet<int> visited){
        if(start == end) return true;

        visited.Add(start);

        foreach(var neighbor in g.adjacencyList[start]){
            if(!visited.Contains(neighbor)){
                if(DFSUtil(g, neighbor, end, visited)){
                    return true;
                }
            }
        }

        return false;
    }

}