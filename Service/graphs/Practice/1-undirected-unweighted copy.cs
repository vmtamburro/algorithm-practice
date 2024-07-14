public class GraphPractice{
    public class UndirectedUnWeightedGraph{
        // dictionary of nodes, and a list of nodes that are connected to the key node
        public Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        public UndirectedUnWeightedGraph(){
            // initialize a new dictionary
            this.graph = new Dictionary<int, List<int>>();
        }

        public void AddVertex(int vertex){
            // check first to see if the vertex already exists - if not, add it
            if(!this.graph.ContainsKey(vertex)){
                // add the vertex to the dictionary
                this.graph[vertex] = new List<int>();
            }
        }

        public void AddEdge(int source, int destination){
            // check to see if the source and destination nodes exist
            if(!this.graph.ContainsKey(source)){
                this.AddVertex(source);
            }
            if(!this.graph.ContainsKey(destination)){
                this.AddVertex(destination);
            }

            // add the destination node to the source node's list
            this.graph[source].Add(destination);
            this.graph[destination].Add(source); // since this is an undirected graph, we'll add the source to the destination's list as well
        }

        public void BFS(int startVertex){
            // initialize list to keep track of the nodes visited
            var visited = new List<int>();
            // initialize a queue to keep track of the nodes to visit
            var queue = new Queue<int>();


            // add the start vertex to the visited list and the queue
            var currentVertex = startVertex;
            visited.Add(currentVertex);
            queue.Enqueue(currentVertex);

            // loop through the queue until it is empty
            while(queue.Count > 0){
                currentVertex = queue.Dequeue();
                Console.WriteLine(currentVertex);

                // loop through the neighbors of the current vertex
                foreach(var neighbor in this.graph[currentVertex]){
                    // if the neighbor has not been visited, add it to the visited list and the queue
                    if(!visited.Contains(neighbor)){
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}