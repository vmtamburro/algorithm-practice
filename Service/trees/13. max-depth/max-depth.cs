public class MaxDepth{
    public class Node {
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
        - Create a function that takes in a tree root, and create a default int for a counter
        - If the node is null, that means the previous node was a leaf, so return the counter
        - Recursively call the function on the left and right nodes, incrementing the counter by 1
        - Get the Max between the left and right Depths and return that.
    */


    public int GetMaxDepth(Node node, int counter = 0){
        if(node == null){
            return counter;
        }

        return Math.Max(GetMaxDepth(node.Left, counter + 1), GetMaxDepth(node.Right, counter + 1));
    }
}