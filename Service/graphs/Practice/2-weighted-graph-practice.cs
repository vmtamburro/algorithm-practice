public class WeightedGraphPractice{

    public class DirectedWeightedGraph: Graph{
        public void AddEdge(int source, int destination, int weight){
            if(!graph.ContainsKey(source)){
                AddVertex(source);
            }
            if(!graph.ContainsKey(destination)){
                AddVertex(destination);
            }

            graph[source].Add((destination, weight));
        }

        // Only Directed and Acyclic Graphs can use a Topological Sort
        // Useful for scheduling tasks, or finding the order of dependencies
        public List<int> TopologicalSortDFS(){
            var visited = new List<int>();
            var stack = new Stack<int>();

            foreach(var vertex in graph.Keys){
                if(!visited.Contains(vertex)){
                    TopologicalSortUtil(vertex, visited, stack);
                }
            }

            return stack.ToList();
        }

        public void TopologicalSortUtil(int vertex, List<int> visited, Stack<int> stack){
            visited.Add(vertex);

            foreach(var neighbor in graph[vertex]){
                if(!visited.Contains(neighbor.destination)){
                    TopologicalSortUtil(neighbor.destination, visited, stack);
                }
            }

            stack.Push(vertex);
        }

        // Topological Sort using BFS 
        public void KahnsAlgorithm(){
            var inDegree = new int[graph.Count];
            var queue = new Queue<int>();
            var result = new List<int>();

            foreach(var vertex in graph.Keys){
                foreach(var neighbor in graph[vertex]){
                    // when adding the vertex to the graph, it would be best to increment the inDegee count
                    // looping is fine here, but it's not the most efficient
                    inDegree[neighbor.destination]++;
                }
            }

            // add all vertices with an inDegree of 0 to the queue
            for(int i = 0; i < inDegree.Length; i++){
                if(inDegree[i] == 0){
                    queue.Enqueue(i);
                }
            }

            // loop through the queue, decrementing the inDegree of the neighbors
            while(queue.Count > 0){
                // dequeue the current vertex
                var currentVertex = queue.Dequeue();
                result.Add(currentVertex);
                // loop through the neighbors of the current vertex
                foreach(var neighbor in graph[currentVertex]){
                    // decrement the inDegree of the neighbor
                    inDegree[neighbor.destination]--;
                    // if the inDegree of the neighbor is 0, add it to the queue
                    if(inDegree[neighbor.destination] == 0){
                        queue.Enqueue(neighbor.destination);
                    }
                }
            }

            if(result.Count != graph.Count){
                Console.WriteLine("Graph has a cycle");
            }else{
                foreach(var vertex in result){
                    Console.WriteLine(vertex);
                }
            }
        }
    }

    public class UndirectedWeightedGraph: Graph{
        public void AddEdge(int source, int destination, int weight){
            if(!graph.ContainsKey(source)){
                AddVertex(source);
            }
            if(!graph.ContainsKey(destination)){
                AddVertex(destination);
            }

            graph[source].Add((destination, weight));
            graph[destination].Add((source, weight)); // since this is an undirected graph, we'll add the source to the destination's list as well
        }
    }

    public class Graph{
        // dictionary of nodes, and a list of nodes that are connected to the key node
        protected Dictionary<int, List<(int destination, int weight)>> graph;
        public Graph(){
            graph = new Dictionary<int, List<(int destination, int weight)>>();
        }

        public void AddVertex(int vertex){
            if(!graph.ContainsKey(vertex)){
                graph[vertex] = new List<(int destination, int weight)>();
            }
        }


        public void PrimsAlgorithm_FindMinimumSpanningTree(){
            var parent = new int[graph.Count];
            var key = new int[graph.Count]; // key values used to pick minimum weight edge
            var mstSet = new bool[graph.Count]; // set to keep track of vertices included in MST

            for(int i = 0; i < graph.Count; i++){
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0; // key value of the first vertex is always 0
            parent[0] = -1; // first node is always the root of MST

            for(int count = 0; count < graph.Count - 1; count++){
                // get the minimum key vertex from the set of verticies not yet visited
                int u = MinKey(key, mstSet);
                // set picked vertex to visited
                mstSet[u] = true;

                // update the key value and parent index of the adjacent vertices of the picked vertex
                foreach(var neighbor in graph[u]){
                    // only update if the vertex is not in the MST set and the weight is less than the current key value
                    if(!mstSet[neighbor.destination] && neighbor.weight < key[neighbor.destination]){
                        parent[neighbor.destination] = u;
                        key[neighbor.destination] = neighbor.weight;
                    }
                }
            }

            for(int i = 1; i < graph.Count; i++){
                Console.WriteLine($"{parent[i]} - {i} : {key[i]}");
            }
        }

        // util function to find the vertex with the minimum key value
        public int MinKey(int[] key, bool[] mstSet){
            int min = int.MaxValue;
            int minIndex = -1;

            for(int v = 0; v < graph.Count; v++){
                if(mstSet[v] == false && key[v] < min){
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }
    }

}