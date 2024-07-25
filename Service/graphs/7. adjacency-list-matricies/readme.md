_How would  you represent a graph using adjacency lists and adjacency matricies? What are the trade-offs between these representations?_

## 1. Adjacency List
* Represent a graph using an array of lists. Each list corresponds to a vertex and contains all verticies in it
* For an undirected graph, if there is an edge between vertex `u` and vertex `v`, then both `u`'s will contain `v` and `v`'s will contain `u`.
* For a directed graph, if there is a directed edge from vertex `u` to vertex `v`, then only `u`'s list will contain `v`


## 2. Adjacency Matrix
* 2D array where element at position `[i][j]` is `true` if there is an edge from vertex `i` to vertex `j` and `false` if otherwise
* For undirected graph, the matrix is symmetric
* For directed graph, the matrix is not symmetric


## Tradeoffs
* Adjacency List is often preferred for sparse graphs due to its efficient use of space and is typically more flexible for various graph algorithms. 
* It can be more suitable for scenarios where edge operations are frequent and you need to efficiently traverse neighbors.
* Adjacency Matrix is useful for dense graphs and scenarios where quick edge existence checks and updates are necessary. 
* It provides constant-time complexity for edge-related operations but can be inefficient in terms of space for large, sparse graphs.