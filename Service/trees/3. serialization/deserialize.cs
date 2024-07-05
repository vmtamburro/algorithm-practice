public class Deserialize{
    public class Node{
        public Node Left;
        public Node Right;
        public int Data;
        public Node(int data){
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
    }


    /* 
        - 1,2,#,#,3,4,#,#,5,#,#

        - Build a function that builds a tree from a string
        - Split the string by commas into an array
        - Loop through the array, and add to the tree structure if the value is a number

        - Adding to Tree
            - Start at the root
            - If the left node is null, add the value
            - If the right node is null, add the value
            - If both are not null, move to the next node
            - If the value is #, move to the next node


        - Note we made the assumption that this is a binary search tree.
        - This could lead to incorrect tree construction if the input is not a binary search tree.
    */

    public Node DeserializeTree(string data){
        var arr = data.Split(",");
        var root = new Node(Int32.Parse(arr[0]));

        // start at the first index since we've already added the root
        for(var i = 1; i < arr.Length; i++){
            if(arr[i] != "#"){
                InsertNonBST(root, Int32.Parse(arr[i]));
            }
        }

        return root;
    }

    public void Insert(Node node, int data){
        if(data < node.Data){
            if(node.Left == null){
                node.Left = new Node(data);
            }else{
                Insert(node.Left, data);
            }
        }
        else if(data > node.Data){
            if(node.Right == null){
                node.Right = new Node(data);
            }else{
                Insert(node.Right, data);
            }
        }

    }

    public void InsertNonBST(Node node, int data){
        if(node.Left == null){
            node.Left = new Node(data);
        }else if(node.Right == null){
            node.Right = new Node(data);
        }else{
            InsertNonBST(node.Left, data);
        }
    }
}