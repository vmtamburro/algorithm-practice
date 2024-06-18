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

# Topological Sorting

Topological sorting is a linear ordering of vertices in a directed graph such that for every directed edge \( uv \) from vertex \( u \) to vertex \( v \), \( u \) comes before \( v \) in the ordering. Topological sorting is applicable only to directed acyclic graphs (DAGs), which means graphs that do not contain any cycles.

## Key Characteristics of Topological Sorting

1. **Directed Acyclic Graph (DAG)**:
   - Topological sorting can only be performed on directed graphs that do not contain cycles. If the graph has a cycle, it is impossible to produce a topological order.

2. **Linear Ordering**:
   - The result of a topological sort is a linear sequence of vertices. This sequence ensures that for any directed edge \( uv \), vertex \( u \) appears before vertex \( v \) in the sequence.

3. **Multiple Possible Orders**:
   - A given DAG can have multiple valid topological sorts. The exact order depends on the traversal algorithm and the specific structure of the graph.

## Applications of Topological Sorting

1. **Task Scheduling**:
   - When certain tasks must be performed before others, topological sorting can be used to determine a valid sequence of task execution. Examples include build systems, job scheduling, and course prerequisite planning.

2. **Dependency Resolution**:
   - In software package management, topological sorting helps in resolving dependencies by installing packages in the correct order.

3. **Logical Sequencing**:
   - Any problem requiring a sequence of steps that respect dependencies can be modeled and solved using topological sorting.

## Algorithms for Topological Sorting

There are two main algorithms for performing topological sorting:

### Kahn's Algorithm (BFS-based)

- Uses a queue to maintain nodes with no incoming edges (in-degree zero).
- Repeatedly removes nodes from the queue, adds them to the sorted list, and decreases the in-degree of their neighbors.
- Nodes with in-degree becoming zero are added to the queue.
- If the sorted list contains all nodes, the graph is a DAG; otherwise, it contains a cycle.

### Depth-First Search (DFS-based)

- Performs a depth-first traversal of the graph.
- Nodes are added to the front of a list when the recursion unwinds (post-order).
- This ensures that all dependencies of a node are processed before the node itself.
- If a back edge is found during traversal, it indicates a cycle in the graph.

## Example

Consider a graph representing a set of tasks with dependencies:

- **Tasks**: a, b, c, d, e, f
- **Dependencies**: (a, d), (f, b), (b, d), (f, a), (d, c)

The edges mean:
- Task 'd' depends on 'a' (a → d)
- Task 'b' depends on 'f' (f → b)
- Task 'd' depends on 'b' (b → d)
- Task 'a' depends on 'f' (f → a)
- Task 'c' depends on 'd' (d → c)

### Topological Sorting Steps

#### Kahn's Algorithm

- Initialize the in-degree of all nodes to zero.
- For each edge \( u \to v \), increase the in-degree of \( v \).
- Add all nodes with zero in-degree to the queue.
- Process each node from the queue, append it to the result, and decrease the in-degree of its neighbors.
- Add neighbors with zero in-degree to the queue.
- Continue until the queue is empty.

#### DFS-Based Algorithm

- Perform a DFS traversal from each unvisited node.
- During DFS, mark nodes as visited and add them to a stack when the recursion unwinds.
- The topological order is the reverse of the stack's contents.

### Code Example Using Kahn's Algorithm

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSort
{
    public List<char> TopologicalSortKahn(char[] vertices, char[][] edges)
    {
        Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        Dictionary<char, int> inDegree = new Dictionary<char, int>();
        List<char> sortedList = new List<char>();

        // Initialize the graph and in-degree dictionary
        foreach (var vertex in vertices)
        {
            graph[vertex] = new List<char>();
            inDegree[vertex] = 0;
        }

        // Build the graph and calculate in-degrees
        foreach (var edge in edges)
        {
            var from = edge[0];
            var to = edge[1];
            graph[from].Add(to);
            inDegree[to]++;
        }

        // Queue for vertices with no incoming edges
        Queue<char> queue = new Queue<char>();
        foreach (var vertex in inDegree.Where(v => v.Value == 0).Select(v => v.Key))
        {
            queue.Enqueue(vertex);
        }

        // Process the queue
        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();
            sortedList.Add(vertex);

            foreach (var neighbor in graph[vertex])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        // If sortedList contains all vertices, return it
        if (sortedList.Count == vertices.Length)
        {
            return sortedList;
        }
        else
        {
            throw new Exception("Graph contains a cycle. No valid topological sort exists.");
        }
    }

    public static void Main(string[] args)
    {
        char[] vertices = { 'a', 'b', 'c', 'd', 'e', 'f' };
        char[][] edges = new char[][]
        {
            new char[] { 'a', 'd' },
            new char[] { 'f', 'b' },
            new char[] { 'b', 'd' },
            new char[] { 'f', 'a' },
            new char[] { 'd', 'c' }
        };

        var sorter = new TopologicalSort();
        try
        {
            var result = sorter.TopologicalSortKahn(vertices, edges);
            Console.WriteLine("Topological Sort: " + string.Join(", ", result));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
```