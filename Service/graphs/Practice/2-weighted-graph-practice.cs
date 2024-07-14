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
    }

    public class UndirectedUnWeightedGraph: Graph{
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
    }
}