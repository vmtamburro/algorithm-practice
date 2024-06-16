/*
    Given a directed graph, design an algorithm to find out whether there is a route between two nodes.
*/

using Example;

public class RouteBetweenNodes{
    public bool SearchBFS(Graph g, int start, int end){
        if(start == end) return true;

        var visited = new HashSet<int>();
        var queue = new Queue<int>();

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
}