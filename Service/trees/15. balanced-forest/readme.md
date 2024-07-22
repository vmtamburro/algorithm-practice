The "Balanced Forest" problem is a classic challenge that involves finding a way to divide a tree into three balanced parts with equal sums of node values. Here's a typical problem statement for this challenge:

---

**Problem Statement: Balanced Forest**

You are given a tree with \( n \) nodes, where each node has a value. You need to find out if it is possible to split this tree into three connected components such that each component has the same sum of node values. 

To do this, you can remove exactly one edge from the tree to create two disconnected subtrees. Then, remove exactly one edge from one of the resulting subtrees to create two additional subtrees. The goal is to check whether it is possible to split the original tree into three connected components with equal sums of node values by performing the above steps.

### Input

- The first line contains an integer \( n \) (\( 3 \leq n \leq 10^5 \)), the number of nodes in the tree.
- The second line contains \( n \) integers \( a_1, a_2, \ldots, a_n \) (\( 1 \leq a_i \leq 10^6 \)), where \( a_i \) is the value of the \( i \)-th node.
- The next \( n-1 \) lines contain two integers \( u \) and \( v \) (\( 1 \leq u, v \leq n \)) each, representing an undirected edge between nodes \( u \) and \( v \). The tree is guaranteed to be connected.

### Output

- Output "YES" if it is possible to split the tree into three connected components each with the same sum of node values.
- Output "NO" otherwise.

### Example

**Input**
```
7
1 2 3 4 5 6 7
1 2
1 3
2 4
2 5
3 6
3 7
```

**Output**
```
YES
```

**Explanation:**

In this example, the tree can be split into three connected components each with a sum of 6.

### Constraints

- The tree is guaranteed to be connected.
- The number of nodes in the tree is at most \( 10^5 \).
- The values of the nodes are positive integers.

---

### Notes

1. **Tree Representation:** The tree is usually represented using adjacency lists or adjacency matrices.
2. **Balanced Forest:** A balanced forest involves dividing the tree into connected components where each component has the same sum of node values.

This problem typically requires an efficient algorithm, as the constraints can make a brute force approach infeasible. Techniques like depth-first search (DFS) or breadth-first search (BFS), combined with careful consideration of subtree sums, are often used to solve this problem.