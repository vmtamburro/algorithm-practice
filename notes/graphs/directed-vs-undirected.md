### Directed Graph

1. **Definition**:
   - A directed graph consists of vertices (or nodes) connected by edges, where the edges have a direction.
   - Each edge is represented as an ordered pair \((u, v)\), where \(u\) and \(v\) are vertices, indicating a direction from vertex \(u\) to vertex \(v\).

2. **Edge Representation**:
   - The edges are directional, meaning \((u, v) \neq (v, u)\). An edge from \(u\) to \(v\) is different from an edge from \(v\) to \(u\).

3. **Applications**:
   - Modeling one-way streets in a city map.
   - Representing dependencies among tasks in task scheduling.
   - Showing relationships where direction matters, such as follower-followee relationships in social networks.

4. **Example**:
   - Consider a graph with vertices \(A\), \(B\), and \(C\). If there is an edge from \(A\) to \(B\), it is denoted as \((A, B)\).

   ```
   A → B
   ↑
   |
   C
   ```

### Undirected Graph

1. **Definition**:
   - An undirected graph consists of vertices connected by edges, where the edges have no direction.
   - Each edge is represented as an unordered pair \(\{u, v\}\), where \(u\) and \(v\) are vertices, indicating a connection between vertex \(u\) and vertex \(v\) with no direction.

2. **Edge Representation**:
   - The edges are bidirectional, meaning \(\{u, v\} = \{v, u\}\). An edge between \(u\) and \(v\) is the same as an edge between \(v\) and \(u\).

3. **Applications**:
   - Modeling two-way streets in a city map.
   - Representing undirected relationships, such as friendships in a social network.
   - Showing connections in network topology where the direction does not matter.

4. **Example**:
   - Consider a graph with vertices \(A\), \(B\), and \(C\). If there is an edge between \(A\) and \(B\), it is denoted as \(\{A, B\}\).

   ```
   A — B
   | 
   C
   ```

### Comparison

| Aspect                | Directed Graph                     | Undirected Graph                 |
|-----------------------|------------------------------------|----------------------------------|
| **Edge Direction**    | Directional (\(u \rightarrow v\))  | Bidirectional (\(\{u, v\}\))     |
| **Edge Representation**| Ordered pair \((u, v)\)           | Unordered pair \(\{u, v\}\)      |
| **Applications**      | Task scheduling, web page ranking | Social networks, network topology|
| **Example**           | \(A \rightarrow B\)                | \(A \leftrightarrow B\)          |

