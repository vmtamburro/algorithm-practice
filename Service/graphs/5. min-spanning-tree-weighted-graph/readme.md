### Find the Minimum Spanning Tree (MST) of a Weighted Graph

**Problem Statement**:
Given a weighted, undirected graph represented as an adjacency list and using a priority queue (min-heap), write a function to find the Minimum Spanning Tree (MST). The MST is a subset of the edges that connects all vertices together without any cycles and with the minimum possible total edge weight.

**Example**:

Consider the following graph:

```
Graph:
0 --(2)-- 1 --(3)-- 2
|         /   \     |
|       (4)   (5)   |
|      /         \  |
3 --(6)-- 4 --(1)-- 5
```

Expected MST edges with their weights:
- `(0, 1)` with weight `2`
- `(1, 2)` with weight `3`
- `(0, 3)` with weight `6`
- `(1, 4)` with weight `4`
- `(4, 5)` with weight `1`

