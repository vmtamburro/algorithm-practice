public class GraphPractice{
    public class UndirectedUnWeightedGraph: Graph{
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
    }

    public class DirectedUnweightedGraph: Graph{
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
        }
    }

    public class Graph{
        // dictionary of nodes, and a list of nodes that are connected to the key node
        public Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        protected Graph(){
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
        protected void BFS(int startVertex){
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

        protected void DFS(int startVertex){
            // create an empty list to kep track of visited nodes
            var visited = new List<int>();
            // create a stack to keep track of nodes to visit
            var stack = new Stack<int>();

            // add the start vertex to the stack
            stack.Push(startVertex);

            // loop through the stack until it is empty
            while(stack.Count() > 0){
                // pop the current vertex from the stack
                var currentVertex = stack.Pop();
                
                // if the current vertex has not been visited, add it to the visited list and print it
                if(!visited.Contains(currentVertex)){
                    // add the current vertex to the visited list
                    visited.Add(currentVertex);
                    Console.WriteLine(currentVertex);

                    // loop through the neighbors of the current vertex
                    foreach(var neighbor in this.graph[currentVertex]){
                        // if the neighbor has not been visited, add it to the stack
                        if(!visited.Contains(neighbor)){
                            stack.Push(neighbor);
                        }
                    }
                }
            }
        }


        // Another alternative would be the DFS in a recursive manner
        public void DFSRecursive(int startIndex){
            // initialize an empty visited list
            var visited = new List<int>();
            // call recursive helper method
            DFSHelper(startIndex, visited);
        }

        public void DFSHelper(int vertex, List<int> visited){
            // add the current vertex to the visited list and print it
            visited.Add(vertex);
            Console.WriteLine(vertex);

            // loop through the neighbors of the current vertex
            foreach(var neighbor in this.graph[vertex]){
                // if the neighbor has not been visited, call the helper method recursively
                if(!visited.Contains(neighbor)){
                    DFSHelper(neighbor, visited);
                }
            }
        }
    }
}