public class Successor{
    public class Node {
        public Node Left;
        public Node Right;
        public Node Parent;
        public int Value;
        public Node(int value){
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }

    /*
        Write an algorithm to find the "next" node (i.e. in-order successor) of a given node in a binary search tree.
        You may assume that each node has a link to its parent.

                      9
                   /    \
                  7      11
                 / \    /  \
                6   8  10   12

        F(9)  = 12
        F(7) = 8
        F(6) = 7
        F(8) = 9 // Not necessarily adjacent. Need to back up two nodes


        Option 1: Flatten the tree to an array, and scan the array. Probably not ideal.
        Option 2: 
            - Find the node we are looking for, and see if we can traverse down to the right.
            - Otherwise traverse up nodes until we find the next successor
    */

    public Node InOrderSuccessor(Node node){
        if(node == null) return null;

        if(node.Right != null){
            return LeftChild(node);
        }
        else{
            Node q = node;
            Node x = q.Parent;
            while (x != null && x.Left != q){
                q = x; //set the old parent to q
                x = x.Parent; // set x to the current parent
            }
            return x;
        }
    }

    public Node LeftChild(Node node){
        if(node == null) return null;
        while(node.Left != null){
            node = node.Left;
        }
        return node;
    }
}