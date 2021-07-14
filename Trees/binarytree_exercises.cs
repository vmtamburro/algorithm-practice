using System;

class MainClass {
    public static void Main (string[] args) {

        var root = new Node(1);
                root.insert(2);
                root.insert(5);
                root.insert(3);
                root.insert(6);
                root.insert(4);
            // Console.WriteLine(depthCount(root) + 1);
                Console.WriteLine(levelOrder(root));
    }
    public static string levelOrder(Node root){
            
        var prntString = "";

        var height = depthCount(root) + 1;
        for(var i = 0; i < height; i++){
            prntString = $"{prntString}{printCurrentLevel(root, i)}";

        }
        
        return prntString.Trim(' ');
    }


    public static string printCurrentLevel(Node node, int index)
    {
        var prntString = "";
        if(node == null) return "";
        if(index == 0) return $" {node.key}";

        prntString = prntString + printCurrentLevel(node.left, index - 1);
        prntString = prntString + printCurrentLevel(node.right, index - 1);

        return prntString;

    }

    public static int depthCount(Node node){

        if(node == null || (node.left == null && node.right == null)) return 0;
        
        int leftDepth = depthCount(node.left) + 1;
        int rightDepth = depthCount(node.right) + 1;

        if(leftDepth > rightDepth){
        return leftDepth;
        }

        return rightDepth;
    }




    public  class Node{
        public int key;
        public Node left;
        public Node right;
        public Node(int key)
        {
            this.key = key;
            this.left = null;
            this.right = null;
        }

        public void insert(int value)
        {
            if(value <= key)
            {
                if(left == null)
                {
                    left = new Node(value);
                }
                else
                {
                    left.insert(value);
                }
            }
            else
            {
                if(right == null)
                {
                    right = new Node(value);   
                }
                else
                {
                    right.insert(value);
                }
            }
            
        }


        public bool contains(int value){
            if(value == key){
                return true;
            }

            if(value < key){
                if(this.left == null) return false;
                return this.left.contains(value);
            }
            else{
                if(this.right == null) return false;
                return this.right.contains(value);
            }
        }

        // In Order Traversals.
        // Left Root Right
        public void printInOrder(){
            if(left != null){
                left.printInOrder();
            }

            Console.WriteLine(key);

            if(right != null){
                right.printInOrder();
            }
        }

        // Pre Order Traversals.
        // Root Left Right
        public void printPreOrder(){
            Console.WriteLine(key);

            if(left != null){
                left.printPreOrder();
            }
            
            if(right != null){
                right.printPreOrder();
            }
        }

        // Post Order Traversals
        // Left Right Root
        public void printPostOrder(){
            if(left != null){
                left.printPostOrder();
            }
            if(right != null){
                right.printPostOrder();
            }
            Console.WriteLine(key);

        }
    }
}