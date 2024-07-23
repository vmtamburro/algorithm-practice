public class BSTImplementation{
    public class Node{
        public int val;
        public Node left;
        public Node right;
        public Node(int x){
            val = x;
            left = null;
            right = null;
        }
    }

    public Node root;

    public void Insert(int value){
        root = Insert(root, value);
    }

    public Node Insert(Node node, int value){
        if(node == null){
            root =  new Node(value);
            return root;
        }

        if(value < node.val){
            node.left = Insert(node.left, value);
        }
        if(value > node.val){
            node.right = Insert(node.right, value);
        }
        return node;
    }

    public void Delete(int value){
        root = Delete(root, value);
    }

    public Node Delete(Node node, int value){
        if(value < node.val){
            root.left = Delete(node.left, value);
        }
        else if(value > node.val){
            root.right = Delete(node.right, value);
        }
        else{
            // node with only one or no child
            if(node.left == null){
                return node.right;
            }
            else if(node.right == null){
                return node.left;
            }
            // node with two children
            node.val = MinValue(node.right);
            node.right = Delete(node.right, node.val);
        }

        
    }

      private int MinValue(Node root) {
        int minValue = root.val;
        while (root.left != null) {
            minValue = root.left.val;
            root = root.left;
        }
        return minValue;
    }

}