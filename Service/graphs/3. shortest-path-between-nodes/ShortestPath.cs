public class ShortestPath{
    /*
        - create a graph class
        - create a method to find the shortest path
            - parameters will be a source and destination
            - use BFS to find the shortest path
                - create a queue to store the vertices
                - create a hash set to store nodes that are visited
                - add the start vertex to the queue and visited set
                - while the queue is not empty
                    - dequeue the vertex
                    - if the vertex is the destination, return the path
                    - iterate through the neighbors of the vertex
                        - if the neighbor is not visited
                            - add the neighbor to the queue and visited set
                            - add the neighbor to the path


        - Space Complexity: O(V + E)
           - V is the number of vertices to be processed
           - E is the number of edges to be processed
        - Space Complexity: O(V)
           - V is the number of vertices to be processed, the Queue can hold up to O(V), but can hold up to all the nodes, making it O(V^2)
    */

    public class Graph
    {
        // Dictionary to store adjacency list
        public Dictionary<int, List<int>> adjacencyList;

        //Constructor
        public Graph()
        {
            adjacencyList = new Dictionary<int, List<int>>();
        }

        // Add a vertex to the graph
        public void AddVertex(int vertex)
        {
            if (!adjacencyList.ContainsKey(vertex))
            {
                adjacencyList[vertex] = new List<int>();
            }
        }

        // Add an edge to the graph
        public void AddEdge(int source, int destination)
        {
            if (!adjacencyList.ContainsKey(source))
            {
                AddVertex(source);
            }

            if (!adjacencyList.ContainsKey(destination))
            {
                AddVertex(destination);
            }
            adjacencyList[source].Add(destination);
        }


        public List<int> ShortestPath(int startVertex, int endVertex)
        {
            var visited = new HashSet<int>();
            var queue = new Queue<List<int>>();
            List<int> path = new List<int>();
            path.Add(startVertex);
            queue.Enqueue(path);

            while (queue.Count > 0)
            {
                var currentPath = queue.Dequeue();
                var vertex = currentPath[currentPath.Count - 1];

                if (vertex == endVertex)
                {
                    return currentPath;
                }

                foreach (var neighbor in adjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        List<int> newPath = new List<int>(currentPath);
                        newPath.Add(neighbor);
                        queue.Enqueue(newPath);
                    }
                }
            }

            return new List<int>();
        }
    }
}