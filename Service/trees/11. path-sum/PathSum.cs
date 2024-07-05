public class PathSum{
    public class Node{
        public Node Left;
        public Node Right;
        public int Data;
        public Node(int data){
            this.Left = null;
            this.Right = null;
            this.Data = data;
        }
    }

    /*
        - Create a function that checks if a path exists in a binary tree that sums up to a target value
        - First check if the root is null, if it is return false
        - Second check if the root is a leaf node, if it is check if the value is equal to the target
        - If the root is not a leaf node, subtract the value from the target and recursively call the function on the left and right nodes
        - If either of the recursive calls return true, return true
        - If both recursive calls return false, return false


        OR
        - First check if the root is null, if it is, then return false
        - Then check if the root is a leaf, if it is, check if the value is equal to the target
            - Leaf means that the left and right nodes are null
        - Set a sum variable at 0
        - If the root is not a leaf, add the value to the sum
        - Recursively call the function on the left and the right nodes until we hit a leaf.
        - Once we hit a leaf, if the sum equals the target, return true

    */

    public bool HasPathSum(Node root, int target, int sum = 0){
        if(root == null) return false;

        if(root.Left == null && root.Right == null){
            return (sum + root.Data) == target;
        }

        return HasPathSum(root.Left, target, sum + root.Data) || HasPathSum(root.Right, target, sum + root.Data);
    }
}