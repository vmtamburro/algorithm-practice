# Trees and Graphs Overview

1. Basics
* Tree: Data structure consisting of nodes, with each node having zero or more child nodes. Starts with a root and branches out into child Nodes
* Binary Tree: Tree where each node has at most two children (left and right)
* Binary Search Tree (BST): Binary tree where the left child node's value is less than the parent's value, and the right child node's value is greater than the parent's value.
* Balanced Tree: Tree where the height difference between the left and the right subtrees of any node is at most one
* Complete Binary Tree: A binary tree where all levels except possibly the last are fully filled, and the last level has all nodes as far left as possible.
* Full Binary Tree: A binary tre where every node has either 0 or 2 children.
* Perfect Binary Tree: A binary tree where all internal nodes have two children, and all leaves are at the same level.

2. Tree Traversal Methods
* In-order Traversal (Left, Root, Right): Used to retrieve data from a BST in sorted order
* Pre-order Traversal (Root, Left, Right): Useful for creating a copy of the tree.
* Post-Order Traversal (Left, Right Root): Useful for deleting a tree or evaluating  postfix expressions
* Level-order Traversal (Breadth First): Uses a queue to traverse the tree level by level.

3. Binary Search Tree (BST) Operations
* Insertion: Recursively find the correct spot to insert the new node
* Deletion: Handle three cases - deleting a leaf node, a node with one child, and a node with two children.
* Lookup: Recursively search for a value in the BST.

4. Tree Balancing
* AVL Trees: Self Balancing Binary Search Tree where the heights of the two child subtrees of any node differ by at most one.
* Red-Black Trees: A Balanced BST where each node has an extra bit for denoting the color of the node, and it ensures the tree remains balanced through various properties and rotations.

5. Tree Problems and Concepts:
* Common Ancestors: Finding the lowest common ancestor (LCA) of two nodes in a tree
* Subtree Checking: Determining if one tree is a subtree of another
* Tree Reconstruction: Rebuilding a tree from traversal results (e.g. in-order and pre-order)
* Tree Height and Depth: Calculating the height (max depth) of a tree
* Binary Heap: A complete binary tree often implemented as an array where the parent node iis either greater (max heap) or smaller (min heap) than its children

6. Special Trees
* Tries (Prefix Trees): A tree-like data structure that stores a dynamic set of strings, where keys are usually strings. Used for efficient retrieval
* Segment Trees: Used for storing intervals of segments. Allows the querying of the stored segments contain a given point



Traversal Example
        1
       / \
      2   3
     / \   \
    4   5   6


- In-Order (Left, Root, Right) - Depth First
    - 4, 2, 5, 1, 3, 6
- Pre-Order (Root, Left, Right) - Depth First
    - 1, 2, 4, 5, 3, 6
- Post-Order (Left, Right, Root) - Depth First
        - 4, 5, 2, 6, 3, 1
- Breadth-First
    - 1, 2, 3, 4, 5, 6



## Problems


### Tree Height

In the following example, we determine the height of the tree by denoting the number of levels. In the below example, the tree is three levels deep.

```
        1
       / \
      2   3
     / \   \
    4   5   6
```

First we generate the Node data structure for our tree. This will have a property for the value, and two pointers to the left and right nodes.

```cs
public class Node{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value){
        Value = value;
        Left = null;
        Right = null;
    }
}
```

We can then use recursion to determine the height. We do not however want to count each connection between the nodes, which would result in duplicates. If a node has another level (both left and right), we will take the MAX() of their counts (which would be 1) and add a +1 for the current level.

```cs

public static int getHeight(Node root){
    if(root = null) return -1; // traditionally height is indexed, so an empty tree would be a height of -1

    //recursion! add additional depths
    var leftDepth = getHeight(root);
    var rightDepth = getHeight(root);

    return Math.Max(leftDepth, rightDepth) + 1; // the +1 is the counter for this current level
}

```