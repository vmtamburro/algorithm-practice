_How would you convert a binary search tree to a doubly linked list?_


## What is the goal?
To convert a binary search tree (BST) to a doubly linked list (DLL), we aim to create a list where the nodes are in the same order as an in-order traversal of the BST. This means the left subtree of any node in the DLL will be less than the node, and the right subtree will be greater than the node.

## Node Structure
- Tree Node Class
    - Left Node Property 
    - Right Node Property
    - Value

- Linked List Class
    - Prev Node
    - Value (current)
    - Next Node

## Approach
- Perform an in-order traversal of the bst, and convert it into a doubly linked list (DLL)
- While Traversing, add the nodes to the DLL