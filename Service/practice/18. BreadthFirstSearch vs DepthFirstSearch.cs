public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution {
    public bool BreadthFirstSearch(TreeNode root, int target) {
        if (root == null) return false;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            TreeNode current = queue.Dequeue();
            if (current.val == target) return true;

            if (current.left != null) queue.Enqueue(current.left);
            if (current.right != null) queue.Enqueue(current.right);
        }

        return false;
    }
     public bool DepthFirstSearch(TreeNode root, int target) {
        if (root == null) return false;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0) {
            TreeNode current = stack.Pop();
            if (current.val == target) return true;

            if (current.right != null) stack.Push(current.right);
            if (current.left != null) stack.Push(current.left);
        }

        return false;
    }
}