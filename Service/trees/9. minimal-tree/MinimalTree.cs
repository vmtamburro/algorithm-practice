using System.Linq;

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
    
    public Node CreateMinimalTree(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return null;

        return CreateMinimalTree(arr, 0, arr.Length - 1);
    }

    private Node CreateMinimalTree(int[] arr, int start, int end)
    {
        if (start > end)
            return null;

        int mid = (start + end) / 2;
        Node node = new Node(arr[mid]);

        node.Left = CreateMinimalTree(arr, start, mid - 1);
        node.Right = CreateMinimalTree(arr, mid + 1, end);

        return node;
    }
}