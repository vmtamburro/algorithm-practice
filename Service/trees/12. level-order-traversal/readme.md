### Binary Tree Level Order Traversal

#### Problem Statement:
Given a binary tree, return the level order traversal of its nodes' values. Level order traversal means visiting all nodes of a level from left to right, level by level.

#### Example:
Consider the following binary tree:

```
    3
   / \
  9  20
    /  \
   15   7
```

**Output:** `[[3], [9, 20], [15, 7]]`

Explanation:
- Level 0: Only node 3.
- Level 1: Nodes 9 and 20.
- Level 2: Nodes 15 and 7.

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
    public IList<IList<int>> LevelOrder(TreeNode root) {
        // Your implementation here
    }
}
```

#### Constraints:
- The number of nodes in the tree is in the range `[0, 1000]`.
- `-1000 <= Node.val <= 1000`

#### Notes:
- Nodes are processed level by level, from left to right.
- Each level's nodes should be stored in a separate list within the result list (`List<List<int>>`).

