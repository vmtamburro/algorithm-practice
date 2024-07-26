public class RandoPractice_Trees_BinaryTree{
    public class TreeNode{
        public int value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value){
            this.value = value;
            left = null;
            right = null;
        }
    }

    public class BinaryTree{
        private TreeNode root;
        
        public void Insert(int value){
            root = Insert(root, value);
        }

        public TreeNode Insert(TreeNode root, int value){
            if(root == null){
                return new TreeNode(value);
            }

            if(value < root.value){
                root.left = Insert(root.left, value);
            }else{
                root.right = Insert(root.right, value);
            }

            return root;
        }

        public void InOrderTraversal(){
            InOrderTraversal(root);
        }

        public void InOrderTraversal(TreeNode root){
            if(root == null){
                return;
            }

            InOrderTraversal(root.left);
            Console.WriteLine(root.value);
            InOrderTraversal(root.right);
        }


        public void PreOrderTraversal(){
            PreOrderTraversal(root);
        }

        private void PreOrderTraversal(TreeNode root){
            if(root == null){
                return;
            }

            Console.WriteLine(root.value);
            PreOrderTraversal(root.left);
            PreOrderTraversal(root.right);
        }


        public void PostOrderTraversal(){
            PostOrderTraversal(root);
        }

        public void PostOrderTraversal(TreeNode root){
            if(root == null){
                return;
            }

            PostOrderTraversal(root.left);
            PostOrderTraversal(root.right);
            Console.WriteLine(root.value);
        }
    }
}