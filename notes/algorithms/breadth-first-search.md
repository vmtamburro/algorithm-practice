
### Notes on Breadth-First Search (BFS) in C#

#### Introduction

- **Breadth-First Search (BFS)** is an algorithm for traversing or searching tree or graph data structures.
- It starts at the tree root (or an arbitrary node in the case of a graph) and explores the neighbor nodes at the present depth prior to moving on to nodes at the next depth level.

#### Characteristics

- **Level-order traversal**: Explores nodes layer by layer.
- **Queue-based implementation**: Uses a queue to keep track of the next location to visit.
- **Suitable for**: Finding the shortest path in an unweighted graph, checking connectivity, etc.

#### Time Complexity

- **O(V + E)**, where `V` is the number of vertices and `E` is the number of edges in the graph.

#### Space Complexity

- **O(V)**, where `V` is the number of vertices. This is due to the storage of the queue and the visited set.

#### Implementation in C#

##### Using an Adjacency List

```csharp
using System;
using System.Collections.Generic;

public class Graph
{
    private int Vertices;
    private List<int>[] AdjList;

    // Constructor
    public Graph(int vertices)
    {
        Vertices = vertices;
        AdjList = new List<int>[vertices];
        for (int i = 0; i < vertices; i++)
        {
            AdjList[i] = new List<int>();
        }
    }

    // Add edge to the graph
    public void AddEdge(int v, int w)
    {
        AdjList[v].Add(w);
    }

    // BFS algorithm
    public void BFS(int start)
    {
        // Mark all vertices as not visited
        bool[] visited = new bool[Vertices];

        // Create a queue for BFS
        Queue<int> queue = new Queue<int>();

        // Mark the current node as visited and enqueue it
        visited[start] = true;
        queue.Enqueue(start);

        while (queue.Count != 0)
        {
            // Dequeue a vertex from the queue and print it
            int vertex = queue.Dequeue();
            Console.Write(vertex + " ");

            // Get all adjacent vertices of the dequeued vertex
            // If an adjacent vertex has not been visited, mark it visited and enqueue it
            foreach (int adjVertex in AdjList[vertex])
            {
                if (!visited[adjVertex])
                {
                    visited[adjVertex] = true;
                    queue.Enqueue(adjVertex);
                }
            }
        }
    }
}

// Example usage
public class Program
{
    public static void Main()
    {
        Graph g = new Graph(4);

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 0);
        g.AddEdge(2, 3);
        g.AddEdge(3, 3);

        Console.WriteLine("Breadth First Traversal (starting from vertex 2):");

        g.BFS(2); // Output: 2 0 3 1
    }
}
```

##### Explanation of Code

1. **Graph Initialization**:
   - The `Graph` class initializes with the number of vertices and an adjacency list to store edges.

2. **AddEdge Method**:
   - Adds an edge between two vertices in the adjacency list.

3. **BFS Method**:
   - Initializes a `visited` array to keep track of visited vertices.
   - Uses a `Queue<int>` to manage the BFS traversal.
   - Marks the starting node as visited and enqueues it.
   - Dequeues a vertex, prints it, and enqueues all its adjacent, unvisited vertices.

4. **Example Usage**:
   - Demonstrates BFS traversal starting from vertex 2.

#### Summary

- **Breadth-First Search (BFS)** is a fundamental graph traversal algorithm.
- Utilizes a queue to manage nodes to be explored.
- Effective for shortest path search in unweighted graphs and connectivity checks.
- Implemented efficiently using adjacency lists in C#.


### Find Islands

"Find Islands" typically refers to a problem in computer science and graph theory where the task is to identify distinct connected components in a grid or a graph. An island, in this context, represents a group of connected cells or nodes that are surrounded by water or empty spaces (depending on the context).

### Key Points:

1. **Grid Representation**: Often, the problem is presented with a 2D grid where each cell can be land ('1') or water ('0'). Islands are contiguous groups of '1's connected horizontally or vertically (not diagonally).

2. **Graph Representation**: Alternatively, islands can also be represented as nodes and edges in a graph. Here, nodes represent land cells ('1'), and edges represent connections (typically horizontal or vertical).

3. **Task**: The main task is to count or identify all distinct islands in the grid or graph. Sometimes, additional tasks include calculating the size of each island or finding the maximum island size.

4. **Algorithm**: Various algorithms can be used to solve the "Find Islands" problem, including Depth-First Search (DFS) or Breadth-First Search (BFS). These algorithms help traverse and mark connected components efficiently.

### Example Scenario:

Consider a 2D grid:

```
[
  ["1", "1", "0", "0", "0"],
  ["1", "1", "0", "0", "0"],
  ["0", "0", "1", "0", "0"],
  ["0", "0", "0", "1", "1"]
]
```

In this grid, there are two islands:
- The first island is composed of the top-left corner and center-left cells.
- The second island is composed of the bottom-right corner cells.

### Conclusion:

"Find Islands" is a problem that involves identifying clusters or groups of connected components (islands) within a grid or graph. The solution typically involves using graph traversal techniques to explore and mark these connected components efficiently.


```cs
using System;
using System.Collections.Generic;

public class FindIslandsBFS
{
    public int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0)
            return 0;

        int rows = grid.Length;
        int cols = grid[0].Length;
        int numIslands = 0;

        // Directions for BFS (4 possible directions: up, down, left, right)
        int[] directionX = { -1, 1, 0, 0 };
        int[] directionY = { 0, 0, -1, 1 };

        // Visited array to track visited cells
        bool[,] visited = new bool[rows, cols];

        // BFS function
        void BFS(int x, int y)
        {
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { x, y });
            visited[x, y] = true;

            while (queue.Count > 0)
            {
                int[] curr = queue.Dequeue();
                int currX = curr[0];
                int currY = curr[1];

                // Explore all 4 directions
                for (int i = 0; i < 4; i++)
                {
                    int nextX = currX + directionX[i];
                    int nextY = currY + directionY[i];

                    // Check boundaries and if the neighboring cell is part of an island
                    if (nextX >= 0 && nextX < rows && nextY >= 0 && nextY < cols &&
                        grid[nextX][nextY] == '1' && !visited[nextX, nextY])
                    {
                        // Mark as visited and enqueue for further exploration
                        visited[nextX, nextY] = true;
                        queue.Enqueue(new int[] { nextX, nextY });
                    }
                }
            }
        }

        // Traverse the grid
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == '1' && !visited[i, j])
                {
                    // Found an unvisited island, perform BFS to mark all connected land cells
                    BFS(i, j);
                    numIslands++;
                }
            }
        }

        return numIslands;
    }
}

// Example usage:
public class Program
{
    public static void Main()
    {
        char[][] grid = new char[][]
        {
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '1', '1', '0', '0', '0' },
            new char[] { '0', '0', '1', '0', '0' },
            new char[] { '0', '0', '0', '1', '1' }
        };

        FindIslandsBFS finder = new FindIslandsBFS();
        int numIslands = finder.NumIslands(grid);
        Console.WriteLine($"Number of islands: {numIslands}"); // Output: 2
    }
}

```