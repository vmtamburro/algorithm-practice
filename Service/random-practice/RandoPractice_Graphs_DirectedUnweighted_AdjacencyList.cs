public class RandoPractice_Graphs_DirectedUnweighted_AdjacencyList
{

    public class Graph
    {
        private Dictionary<int, List<int>> adjList;

        public Graph()
        {
            adjList = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int u, int v)
        {
            if (!adjList.ContainsKey(u))
                adjList[u] = new List<int>();

            adjList[u].Add(v);
        }

        public void PrintGraph()
        {
            foreach (var vertex in adjList)
            {
                Console.Write(vertex.Key + ": ");
                foreach (var neighbor in vertex.Value)
                {
                    Console.Write(neighbor + " ");
                }
                Console.WriteLine();
            }
        }

        public void DFS(int start)
        {
            HashSet<int> visited = new HashSet<int>();
            DFSUtil(start, visited);
        }

        private void DFSUtil(int v, HashSet<int> visited)
        {
            visited.Add(v);
            Console.Write(v + " ");

            if (adjList.ContainsKey(v))
            {
                foreach (var neighbor in adjList[v])
                {
                    if (!visited.Contains(neighbor))
                    {
                        DFSUtil(neighbor, visited);
                    }
                }
            }
        }

        public void BFS(int start)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();

            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int v = queue.Dequeue();
                Console.Write(v + " ");

                if (adjList.ContainsKey(v))
                {
                    foreach (var neighbor in adjList[v])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
        }
    }

}