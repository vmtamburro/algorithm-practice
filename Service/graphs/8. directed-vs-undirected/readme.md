_How would you find the shortest path in a directed graph with positive edge weights?_


### Dijkstra's Algorithm

**Overview**:
- **Goal**: Find the shortest path from a single source vertex to all other vertices in a graph with positive edge weights.
- **Method**: Iteratively selects the vertex with the smallest known distance from the source, updates the distances to its neighbors, and continues until all vertices are processed.

**Steps**:
1. **Initialization**:
   - Set the distance to the source vertex to 0 and all other vertices to infinity.
   - Create a priority queue (or a min-heap) to keep track of vertices with the smallest distance.
   - Add the source vertex to the priority queue with a distance of 0.

2. **Processing**:
   - While the priority queue is not empty:
     - Extract the vertex with the smallest distance from the priority queue.
     - For each adjacent vertex, calculate the new distance through the current vertex. If this new distance is smaller than the known distance, update it and add the adjacent vertex to the priority queue with the updated distance.

3. **Termination**:
   - The algorithm terminates when the priority queue is empty, and the shortest paths to all reachable vertices have been found.

### Key Points

- **Initialization**: Set up distances and the priority queue.
- **Priority Queue**: A priority queue (or min-heap) is used to efficiently get the vertex with the smallest distance. In C#, `SortedSet` can be used to simulate this behavior, but specialized priority queue implementations may be more efficient.
- **Distance Update**: Update the distances of neighboring vertices if a shorter path is found.
- **Efficiency**: Dijkstra’s algorithm runs in O((V + E) log V) time complexity using a priority queue, where V is the number of vertices and E is the number of edges.

### Trade-offs and Considerations

- **Graph Density**: Dijkstra’s algorithm is well-suited for graphs with positive edge weights. For very dense graphs or graphs with negative weights, different algorithms may be more appropriate (e.g., Bellman-Ford for negative weights).
- **Priority Queue**: Efficient priority queue operations are crucial for optimal performance. Specialized implementations like binary heaps or Fibonacci heaps can offer better performance compared to simple sorted sets.
