# Trees

Trees - Unlike arrays, linked lists, stacks, and queues, which are linear data structures, trees are hierarchical data st ructures

Vocab
- Root
- Children
- Parent
- Leaves

Why Trees?
- You might want to store information that naturally forms a hierarchy.
- Privde moderate access/search (Quicker than a linked list, and slower than an array.)
- Don't have an upper limit as the number of nodes are linked lists using pointers.


Applications
- Manipulate hierarchical data
- Make information easy to use
- Manipulate sorted lists of data
- Composing digital images
- Router algorithms
- Multi-stage decisino-making (Look up Business Chess)


# Binary Trees
Binary Tree - A tree whose element have at most two children is called a binary tree. Since ther are often two children, we typically name the child left and right.

1. The maximum number of nodes at level 'l' of a binary tree is 2.
- Here the level is the number of nodes on the path from the root to the node (including the root and the node)
- Level of the root is 0.
- This can be proved by induction (Look up Induction)
- For root l = 0, the max number of nodes 2^0 is 1
- Assume that the maximum number of nodes on level 'l' is 2
- Since in Binary tree, every node has at most 2 children, the next level would have twice as many nodes.

2. The maximum number of nodes in a binary tree of height 'h' is 2^h -1
- Here the height of a tree is the maximum number of nodes on the root to leaf path. Height of a tree with a single node is considered as 1.
- This result ca be derived from point 2 above. A tree has a mximum of nodes if all levels have maxumum nodes. So the maximum number of nodes in a binary tree is 1 + 2 + 4 + ... + 2^h. This is a simple geometric series with h terms and sum of this series is 2^h-1
- In some books, the height of the root is considered as 0. In this convention, the above formula becomes 2 ^(h+1) - 1


*Note: Node values are inserted into a binary search tree before a reference to the tree's root node is passed into yur function. In a binary search tree, all nodes on the left branch of a node are less than the nodes value. All nopdes on the right branch are greater than the nodes value.*


# Binary Search Tree
Binary Search Tree that fulfills an ordering property. Makes finding a node very fast.

Inserts
- Begin with an element you want to insert.  Is it bigger or smaller than the root? if bigger, traverse to the right, if smaller, traverse to the left. Do this over and over until you get to a null node.
- Issue is that the binary search tree could get unbalanced.
- If you start at 1, you get a data structure that is more like an array, and more like a long list.

- Most of the time in interviews, we will assume we have a banlanced tree

## Traversing


Three types of traversing in a binary search tree
- InOrder Traversal
    - Visit the Left node, the root node, then the right node
- PreOrder Traversal
     - Visit the root first, then visit the left and the right
- PostOrder Traversal
    - Left right and then root.
- Level Order Traversal
    - Root, left then right.


Typically, we do InOrder traversals, because we want the nodes to be printed in order.

# BFS vs DFS

BFS stands for Breadth first search.
- Uses the Queue data structure for finding the shortest path
- Can be used to find single source shortest path in an unweighted graph, becasue in BFS we reach a vertex with the minimum number of edges from a source vertex
- More suitable for searching verticies which are closr to the given source.
- Considers all neighbors first and therefore not suitable for decision making trees used in games or puzzles
