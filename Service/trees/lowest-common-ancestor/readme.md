### Lowest Common Ancestor in a Binary Search Tree

#### Problem Statement:

Given a binary search tree (BST) and two nodes, find the lowest common ancestor (LCA) of the two nodes. The LCA of two nodes `p` and `q` in a BST is defined as the lowest node that has both `p` and `q` as descendants (where we allow a node to be a descendant of itself).

#### Requirements:

1. Implement a function `TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)` that takes the root of a BST and two nodes `p` and `q`, and returns the LCA of the two nodes.

#### Example:

Given the following binary search tree:

```
        6
       / \
      2   8
     / \ / \
    0  4 7  9
      / \
     3   5
```

- For nodes `p = 2` and `q = 8`, the LCA is `6`.
- For nodes `p = 2` and `q = 4`, the LCA is `2`.

#### Constraints:

- All nodes in the tree contain unique values.
- `p` and `q` will exist in the tree.
- The function should operate in O(h) time complexity, where h is the height of the tree.

#### Tips:

- Utilize the properties of the binary search tree to make the solution efficient.
- If both `p` and `q` are greater than the current node, explore the right subtree.
- If both `p` and `q` are less than the current node, explore the left subtree.
- If `p` and `q` diverge in the tree, the current node is the LCA.

---
