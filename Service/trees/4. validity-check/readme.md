### BST Validity Check

#### Problem Statement:
You are given the root of a binary tree. Write a function to determine if it is a valid binary search tree (BST).

A valid BST is defined as follows:
- The left subtree of a node contains only nodes with keys less than the node's key.
- The right subtree of a node contains only nodes with keys greater than the node's key.
- Both the left and right subtrees must also be binary search trees.

#### Function Signature:
```python
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

def isValidBST(root: TreeNode) -> bool:
```

#### Example:
**Input:**
```
    2
   / \
  1   3
```

**Output:** `True`

**Input:**
```
    5
   / \
  1   4
     / \
    3   6
```

**Output:** `False`

#### Constraints:
- The number of nodes in the tree is in the range [1, 10^4].
- -2^31 <= Node.val <= 2^31 - 1

#### Approach:
1. Use recursion to traverse the tree.
2. Ensure that for each node, all values in the left subtree are less than the node's value and all values in the right subtree are greater than the node's value.
3. Utilize additional parameters to keep track of the valid range for each node during the traversal.
