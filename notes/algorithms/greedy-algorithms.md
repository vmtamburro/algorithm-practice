A greedy algorithm is a simple, intuitive algorithmic strategy that is used in optimization problems. The main idea behind a greedy algorithm is to make the locally optimal choice at each step with the hope of finding a global optimum solution. 

### Characteristics of Greedy Algorithms:

1. **Local Optimization**: Greedy algorithms make decisions based on the information available at the current step without considering the future consequences extensively. They aim to achieve the best immediate solution.

2. **Iterative Approach**: The algorithm proceeds iteratively by selecting the best option available at each step, without revisiting previous choices or reconsidering the path taken.

3. **Not Always Optimal**: While greedy algorithms often provide a reasonable solution, they do not guarantee finding the globally optimal solution for every problem. Sometimes, a locally optimal choice might lead to a suboptimal solution overall.

### Examples of Greedy Algorithms:

- **Dijkstra's Algorithm**: Used for finding the shortest path from a single source vertex to all other vertices in a weighted graph. At each step, it selects the vertex with the smallest known distance from the source.

- **Prim's Algorithm**: Used for finding the Minimum Spanning Tree (MST) of a connected, undirected graph. It starts with an arbitrary vertex and grows the MST one edge at a time by always adding the cheapest edge that connects a vertex in the MST to a vertex outside of it.

- **Kruskal's Algorithm**: Another algorithm for finding the MST of a graph. It starts with an empty set of edges and adds the smallest edge that does not form a cycle with the edges already in the MST.

### When to Use Greedy Algorithms:

- **Optimization Problems**: When the problem can be decomposed into a set of smaller subproblems, and making a series of locally optimal choices leads to a globally optimal solution.

- **Efficiency**: Greedy algorithms are often efficient in terms of time complexity, making them suitable for large datasets or real-time applications where quick decisions are required.

### Limitations of Greedy Algorithms:

- **Suboptimality**: Due to their myopic nature (focusing on immediate benefits), greedy algorithms may not always produce the best possible solution.

- **Complexity Considerations**: The choice of the greedy strategy may heavily depend on the problem structure and the specific constraints involved. Not all problems lend themselves well to greedy approaches.

In summary, a greedy algorithm is a powerful and straightforward approach to solving optimization problems by making locally optimal choices at each step, aiming to find a solution that is reasonably good, if not always the absolute best.