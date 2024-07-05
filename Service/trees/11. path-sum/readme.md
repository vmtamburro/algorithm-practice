### Path Sum in Binary Tree

#### Problem Statement:
Given a binary tree and a target sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given target sum.

#### Example:
Consider the following binary tree:

```
        5
       / \
      4   8
     /   / \
    11  13  4
   /  \      \
  7    2      1
```

**Input:**
Binary Tree:
```
    5
   / \
  4   8
 /   / \
11  13  4
/  \      \
7    2      1
```
Target Sum: `22`

**Output:** `true`

Explanation:
There exists a root-to-leaf path `5 -> 4 -> 11 -> 2` which sums up to `22`.

**Input:**
Binary Tree:
```
    1
   / \
  2   3
```
Target Sum: `5`

**Output:** `false`

Explanation:
There is no root-to-leaf path that sums up to `5`.

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
    public bool HasPathSum(TreeNode root, int targetSum) {
        // Your implementation here
    }
}
```

#### Constraints:
- The number of nodes in the tree is in the range `[0, 5000]`.
- `-1000 <= Node.val <= 1000`
- `-1000 <= targetSum <= 1000`

#### Notes:
- A leaf is a node with no children.