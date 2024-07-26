public class RandoPractice_Graphs_DirectedUnweighted_Matrix
{
    public class GraphMatrix
    {
        private int[,] adjMatrix;
        private int size;

        public GraphMatrix(int size)
        {
            this.size = size;
            adjMatrix = new int[size, size];
        }

        public void AddEdge(int u, int v)
        {
            adjMatrix[u, v] = 1;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(adjMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void DFS(int start)
        {
            bool[] visited = new bool[size];
            DFSUtil(start, visited);
        }

        private void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write(v + " ");

            for (int i = 0; i < size; i++)
            {
                if (adjMatrix[v, i] == 1 && !visited[i])
                {
                    DFSUtil(i, visited);
                }
            }
        }

        public void BFS(int start)
        {
            bool[] visited = new bool[size];
            Queue<int> queue = new Queue<int>();

            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int v = queue.Dequeue();
                Console.Write(v + " ");

                for (int i = 0; i < size; i++)
                {
                    if (adjMatrix[v, i] == 1 && !visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }

}