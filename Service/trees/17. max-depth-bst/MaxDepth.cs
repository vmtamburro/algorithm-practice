public class MaxDepthPractice{
    public class Node{
        public int val;
        public Node left;
        public Node right;
        public Node(int val){
            this.val = val;
            this.left = null;
            this.right = null;
        }
    }

    public int MaxDepth(Node root){
        if(root == null){
            return 0;
        }

        int left = MaxDepth(root.left);
        int right = MaxDepth(root.right);
        return Math.Max(left, right) + 1;
    }
}