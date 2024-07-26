public class RandoPractice_Graphs_Dijkstras
{

    public class Graph
    {
        private int V; // Number of vertices
        private List<Tuple<int, int>>[] adjList; // Adjacency list

        public Graph(int v)
        {
            V = v;
            adjList = new List<Tuple<int, int>>[V];
            for (int i = 0; i < V; i++)
                adjList[i] = new List<Tuple<int, int>>();
        }

        public void AddEdge(int u, int v, int weight)
        {
            adjList[u].Add(new Tuple<int, int>(v, weight));
            adjList[v].Add(new Tuple<int, int>(u, weight)); // For undirected graph
        }

        public void Dijkstra(int src)
        {
            int[] dist = new int[V];
            for (int i = 0; i < V; i++)
                dist[i] = int.MaxValue;
            dist[src] = 0;

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
            pq.Enqueue(src, 0);

            while (pq.Count > 0)
            {
                int u = pq.Dequeue();

                foreach (var edge in adjList[u])
                {
                    int v = edge.Item1;
                    int weight = edge.Item2;

                    if (dist[u] + weight < dist[v])
                    {
                        dist[v] = dist[u] + weight;
                        pq.Enqueue(v, dist[v]);
                    }
                }
            }

            for (int i = 0; i < V; i++)
            {
                Console.WriteLine($"Distance from {src} to {i} is {dist[i]}");
            }
        }
    }

    // PriorityQueue implementation for .NET 6 or later
    public class PriorityQueue<TKey, TValue> where TValue : IComparable
    {
        private SortedDictionary<TValue, Queue<TKey>> _dict = new SortedDictionary<TValue, Queue<TKey>>();

        public int Count { get; private set; }

        public void Enqueue(TKey key, TValue value)
        {
            if (!_dict.ContainsKey(value))
                _dict[value] = new Queue<TKey>();

            _dict[value].Enqueue(key);
            Count++;
        }

        public TKey Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            var firstPair = _dict.First();
            var key = firstPair.Value.Dequeue();

            if (firstPair.Value.Count == 0)
                _dict.Remove(firstPair.Key);

            Count--;
            return key;
        }
    }

}