# Hackerrank Quiz

Question 1.

Which of these is the Worst-case time complexity of Quick Sort - and cannot be expressed in lower order te\rms ?

- (a) O(n)
- (b) O(n log n)
- (c) O(n2)
- (d) O(n3)
- (e) O(log n)

Answer - O(n2). The worst-case time complexity of quick sort occurs when the pivot selection consistently divides the array in an unbalanced manner, leading to an o(n2) time complexity.

Question 2.

Which of these is the worst case time complexity of Merge Sort - and cannot be expressed in lower order terms ?
- (a) O(n)
- (b) O(n log n)
- (c) O(n2)
- (d) O(n3)
- (e) O(log n)


Answer - O(n log n). Optimal for comparison-based sorting algorithms.

Question 3.

Which of these is the average case time complexity of Merge Sort - and cannot be expressed in lower order terms ?

- (a) O(n)
- (b) O(n log n)
- (c) O(n2)
- (d) O(n3)
- (e) O(log n)

O(n log n) - Merge sort also has an average-case time complexity of O(n log n), same as worst-case time complexity.

Question 4.

Which of these is the time complexity involved in building a heap of n elements - and cannot be expressed in lower order terms ?

- (a) O(n)
- (b) O(n log n)
- (c) O(n2)
- (d) O(n3)
- (e) O(log n)

O(n) Building a heap of elements has a time complexity of O(n).

Question 5.

A heap is a particular kind of a binary search tree. This statement is:
- (a) True
- (b) False

Answer - false. Heap is not a binary tree. While both structures are tree=based, they have different properties and are used for different purposes. Heaps are specifically used for priority queue operations.

Question 6.

The Floyd-Warshall all-pairs shortest path algorithm for finding the shortest distances between nodes in a graph is an example of:
- (a) A Dynamic Programming formulation.
- (b) A Greedy Algorithm
- (c) A recursion based divide and conquer technique.

Answer - (a) A Dynamic Programming Formulation. The Floyd-Warshall algorithm uses a dynamic programming approach to compute shortest paths between all pairs of nodes in a graph, storing immediate results in a matrix.

Question 7.

A bitwise operation 'f' has an interesting characteristic, such that, if f(a,b) = c, it always turns out to be the case that f(b,a) = c; f(a,c) = b; f(c,a) = b; f(b,c) = a; f(c,b) = a. Which of these functions could 'f' possibly be?
- (a) f(a,b) = a XOR b
- (b) f(a,b) = a + b
- (c) f(a,b) = a - b
- (d) f(a,b) = a * b

(where a and b are the binary representations of any two non-negative integers)

Answer - a XOR b. XOR (exclusive OR) satisfies this characteristic because it is symmetric, and reversible.


Question 8.

A union find data-structure is commonly applied while implementing:
- (a) A depth-first search traversal of a graph.
- (b) A breadth-first search traversal of a graph.
- (c) Computing the minimum spanning tree of a graph using the Kruskal algorithm.
- (d) Computing the all-pairs shortest path in a graph.

Answer: (c) Computing the minimum spanning tree of a graph using the Kruskal algorithm. Union-Find data structure is used in Krushkal's algorithm to efficiently determine whether adding an edge forms a cycle in a graph, which is crucial for constructing a minimum spanning tree.

Question 9.

Which of these is the worst case time complexity for looking up a key in a binary search tree - and cannot be expressed in lower order terms ?

- (a) O(n)
- (b) O(n log n)
- (c) O(n2)
- (d) O(n3)
- (e) O(log n)

Answer: O(log n). The worst-case time complexity for looing up a key in a inary search tree is O(log n), which is optimal for a balanced binary search trees.

Question 10.

The graph algorithm which forms an essential component of the 'make' or 'ant build' used by programmers and software developers is:

- (a) Flow maximization algorithm
- (b) Shortest path algorithm
- (c) Minimum spanning tree algorithm
- (d) Bipartite matching
- (e) Topological sort

Answer: Topological Sort - essential to in build systems like 'make' or 'ant build' to determine the order of tasks or dependencies, ensuring that each task s performed in the correct sequence without circular dependencies.