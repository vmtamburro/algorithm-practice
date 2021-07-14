public class Node{
    public int key;
    public Node left, right;
    public Node(int key){
        this.key= key;
        this.left = null;
        this.right = null;
    }
}


public class BinaryTree{
    //Root of Binary tree
    Node root;

    BinaryTree(int key){
        this.root = new Node(key);
    }

    BinaryTree(){
        this.root = null;
    }


    public static void Main(String[] args){

        var tree = new BinaryTree(new Node(1));

        tree.root.left = new Node(2);
        tree.root.right = new Noe(3);


        /*
                1
            /       \
          2           3
         /   \      /   \
        null null null null 

        */


        tree.root.left.left = new Node(4);
        tree.root.left.right = new Node(5);

        /*
                1
            /       \
          2           3
         /   \      /   \
        4     5    null null 
     /     \  ETC  
   null    null
        */
        tree.root.right.left = new Node(6);
        tree.root.right.right = new Node(7);

    }
}

