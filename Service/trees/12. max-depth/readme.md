### Interview Question: Maximum Depth of Binary Tree

#### Problem Statement:
Given a binary tree, find its maximum depth. The maximum depth is defined as the number of nodes along the longest path from the root node down to the farthest leaf node.

#### Example:
Consider the following binary tree:

```
    3
   / \
  9  20
    /  \
   15   7
```

**Output:** `3`

Explanation:
The maximum depth of this tree is 3, which is the path `3 -> 20 -> 15`.

#### Function Signature:
```csharp
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    public int MaxDepth(TreeNode root) {
        // Your implementation here
    }
}
```

#### Constraints:
- The number of nodes in the tree is in the range `[0, 104]`.
- `-100 <= Node.val <= 100`

#### Notes:
- The maximum depth of an empty tree is 0.
- The depth of the root node is 1 if the tree is not empty.

