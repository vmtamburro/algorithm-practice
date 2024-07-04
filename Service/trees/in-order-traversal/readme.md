### Tree Operations

#### Problem Statement:

You are given a binary search tree (BST) and need to implement a function that performs an in-order traversal to print all the node values in sorted order.

#### Requirements:

1. Implement a function `printInOrder(TreeNode root)` that takes the root of a binary search tree and prints all node values in sorted order using in-order traversal.
   
2. Ensure that your solution runs in O(n) time complexity, where n is the number of nodes in the tree, and uses O(h) additional space, where h is the height of the tree.

#### Example:

Given the following binary search tree:

```
        5
       / \
      3   8
     / \ / \
    2  4 6  10
```

Output of `printInOrder(root)` should be: `2 3 4 5 6 8 10`

#### Constraints:

- Nodes of the tree contain unique integer values.
- You cannot modify the structure of the tree.

#### Tips:

- Use recursion to implement the in-order traversal.
- Ensure that your solution handles edge cases, such as empty trees or trees with only one node.
- Discuss the time and space complexity of your solution during the interview.
