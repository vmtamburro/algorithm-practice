public class MinimalTree{


    public class Node{
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value){
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }

    /*
        Given a sorted (increasing order) array with unique integer elements, write an algorithm to create
        a binary search tree with minimal height.

        Need to match the number of nodes in the left and right subtrees. We want the root to be the middle of the array.
        Each following sub-tree needs to follow the same behavior.
    */
    public void BuildMinimalTree(int[] arr){

    }
}