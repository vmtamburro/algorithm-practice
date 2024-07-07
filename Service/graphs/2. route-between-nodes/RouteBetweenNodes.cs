/*
    Given a directed graph, design an algorithm to find out whether there is a route between two nodes.

    Time complexity O(V + E)
    
*/

using Example;

public class RouteBetweenNodes{
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
            return DFSUtil(g.adjacencyList, start, end, visited);
    }

    public bool DFSUtil(Dictionary<int, List<int>> adjacencyList, int start, int end, HashSet<int> visited){
        if(start == end) return true;

        visited.Add(start);

        foreach(var neighbor in adjacencyList[start]){
            if(!visited.Contains(neighbor)){
                if(DFSUtil(adjacencyList, neighbor, end, visited)){
                    return true;
                }
            }
        }

        return false;
    }
}