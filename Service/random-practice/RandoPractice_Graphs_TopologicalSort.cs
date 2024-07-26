public class RandoPractice_TopologicalSort
{
    public class GraphDAG
    {
        private int V;
        private List<int>[] adjList;

        public GraphDAG(int v)
        {
            V = v;
            adjList = new List<int>[V];
            for (int i = 0; i < V; i++)
                adjList[i] = new List<int>();
        }

        public void AddEdge(int u, int v)
        {
            adjList[u].Add(v);
        }

        public void TopologicalSort()
        {
            int[] inDegree = new int[V];
            foreach (var list in adjList)
            {
                foreach (var v in list)
                    inDegree[v]++;
            }

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < V; i++)
            {
                if (inDegree[i] == 0)
                    queue.Enqueue(i);
            }

            List<int> sortedOrder = new List<int>();
            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                sortedOrder.Add(u);

                foreach (var v in adjList[u])
                {
                    if (--inDegree[v] == 0)
                        queue.Enqueue(v);
                }
            }

            if (sortedOrder.Count != V)
            {
                Console.WriteLine("The graph has a cycle, so topological sort is not possible.");
                return;
            }

            Console.WriteLine("Topological Sort:");
            foreach (var vertex in sortedOrder)
            {
                Console.Write(vertex + " ");
            }
        }
    }

}