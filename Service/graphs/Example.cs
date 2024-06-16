using System;
using System.Collections.Generic;

namespace Example{
    public class Graph{
        // Dictionary to store adjacency list
        public Dictionary<int, List<int>> adjacencyList;

        //Constructor
        public Graph(){
            adjacencyList = new Dictionary<int, List<int>>();
        }

        // Add a vertex to the graph
        public void AddVertex(int vertex){
            if(!adjacencyList.ContainsKey(vertex)){
                adjacencyList[vertex] = new List<int>();
            }
        }

        // Add an edge to the graph
        public void AddEdge(int source, int destination){
            if(!adjacencyList.ContainsKey(source)){
                AddVertex(source);
            }

            if(!adjacencyList.ContainsKey(destination))
            {
                AddVertex(destination);
            }
            adjacencyList[source].Add(destination);
        }

        // Breadth-First Search (BFS)
        public void BFS(int startVertex){
            var visited = new HashSet<int>();
            var queue = new Queue<int>();

            visited.Add(startVertex);
            queue.Enqueue(startVertex);

            while (queue.Count > 0){
                var vertex = queue.Dequeue();
                Console.WriteLine(vertex + " ");

                foreach(var neighbor in adjacencyList[vertex]){
                    if(!visited.Contains(neighbor)){
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }

        // Depth-First Search (DFS)
        public void DFS(int startVertex){
            var visited = new HashSet<int>();
            DFSUtil(startVertex, visited);
        }

        public void DFSUtil(int vertex, HashSet<int> visited){
            visited.Add(vertex);
            Console.WriteLine(vertex + " ");

            foreach(var neighbor in adjacencyList[vertex]){
                if(!visited.Contains(neighbor)){
                    DFSUtil(neighbor, visited);
                }
            }
        }
    }
}