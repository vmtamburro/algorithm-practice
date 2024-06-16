# Graphs

## Basics

* Graph: collection of nodes (vertices) and edges connecting pairs on nodes
* Vertex(node): Fundamental part of a graph, representing an entity
* Edge: A connection between two vertices

### Types of Graphs

1. Undirected Graph - Edges have no direction. If there's an edge between vertex A and vertex B you can travel both ways
2. DirectedGraph - Edges have direction
3. Weighted Graph - Each edge has a weight or cost associated with it
4. Unweighted Graph - All edges are of equal weight.

### Graph Representations

1. Adjacency Matrix

* A 2D array where `matrix[i][j]` is true (or the weight) if there is an edge from vertex i to vertex j
* Space Complexity O(V^2) where V is the number of vertices

2.Adjacency List

* An array of lists. The list at index i contains the vertices adjacent to vertex i.
* Space Complexity: O(V + E), where E is the number of edges

## Graph Traversal Algorithms

1. Depth-First Search (DFS):

* Uses a stack (or recursion) to explore as far as possible along each branch before backtracking
* Useful for pathfinding and detecting cycles
* Time complexity: O(V + E)
* Implementation (recursive):

```cs
void DFS(Graph graph, int start, boolean[] visited){
    visited[start] = true;
    foreach(int neighbor in graph.getNeighors(start)){
        if(!visited[neighbor]){
            DFS(graph, neighbor, visited);
        }
    }
}
```

2. Breadth-First Search (BFS):

* Uses a queue to explore all neighbors at the present depth before moving on to nodes at the next depth level
* Useful for finding the shortest path in unweighted graphs
* Time complexity O(V + E)
* Implementation:

```cs
void BFS(Graph graph, int start){
    boolean[visited] = new boolean[graph.size()];
    Queue<int> queue = new LinkedList<>();
    queue.add(start);
    visited[start] = true;
    while(!queue.isEmpty()){
        int current = queue.remove();
        foreach(int neighbor in graph.getNeighbors(current)){
            if(!visited[neighbor]){
                queue.add(neighbor);
                visited[neighbor] = true;
            }
        }
    }
}

```

## Common Graph Problems and Algorithms

1. Shortest Path Algorithms:
    * Dijkstra's Algorithm: Finds the shortest path from a single source node to all other nodes in a weighted graph with non-negative weights
        * Uses a Priority Queue
        * Time Complexity O((V + E) log V)
    * Bellman-Ford Algorithm: Finds the shortest path from a single source to all nodes, handles negative weights.
        * Time complexity O(V E)

2. Cycle Detection
    * Undirected Graph: Using DFS, if you visit a node that is already visited and is not the parent of the current node, a cycle exists.
    * Directed Graph: Using DFS, if you encounter a node that is currently in the recursion stack, a cycle exists.

3. Topological Sorting
    * Applicable to only Directed Acyclic Graphs (DAG)
    * Orders verticies linearly such that for every edge uv, vertex u comes before the v
    * Can e done using DFS or Kahn's algorithm

```csharp
void TopologicalSortUtil(int v, boolean[] visited, Stack<int> stack, Graph graph) {
    visited[v] = true;
    foreach (int neighbor in graph.getNeighbors(v)) {
        if (!visited[neighbor]) {
            TopologicalSortUtil(neighbor, visited, stack, graph);
        }
    }
    stack.push(v);
}

void TopologicalSort(Graph graph) {
    Stack<int> stack = new Stack<>();
    boolean[] visited = new boolean[graph.size()];
    for (int i = 0; i < graph.size(); i++) {
        if (!visited[i]) {
            TopologicalSortUtil(i, visited, stack, graph);
        }
    }
    while (!stack.isEmpty()) {
        System.out.print(stack.pop() + " ");
    }
}

```