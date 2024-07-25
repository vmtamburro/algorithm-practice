_What are the properties of a Red-Black Tree, and why are they important for maintaining balance?_

## Overview
A red-black tree is a self-balancing binary search tree with the following properties:
1. **Node Color:** every node is either red or black.
2. **Root Property:** the root is always black
3. **Leaf Property:** All leaves (NIL) nodes are black
4. **Red Property:** Red nodes cannot have red children
5. **Black Depth Property:** Every path from a given node to a leaf node has the same number of black nodes.

## Purpose
1. Prevents skewed trees
    * No two consecutive red nodes property ensures that the tree doesn't become too skewed. Can lead to unbalanced tree heights and inefficient operations.
2. Ensuring Uniform Black Depth
    * Black depth property ensures that the tree remains approximately balanced, as the number of black nodes from the root to any leaf is consistent. This uniformity help maintain the logarithmic height of the tree.
3. Height Control
    * The combination of these properties guaranties that the longest path from the root to a leaf is no more than twice the length of the shortest path. 
    * Bounded height ensures that operations can be performed in O(log n) time.