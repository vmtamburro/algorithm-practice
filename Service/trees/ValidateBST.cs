public class ValidateBinarySearchTree
{
    public class Node {
        public Node Left;
        public Node Right;
        public int Value;

        public Node(int value){
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }


    /* Implement a function to check if a binary tree is a binary search tree */
    public bool ValidateBST(Node node){
        return ValidateBST(node, int.MinValue, int.MaxValue);
    }

    public bool ValidateBST(Node node, int min, int max){
        if(node == null) return true;

        if(node.Value <= min || node.Value >= max){
            return false;
        }

        return ValidateBST(node.Left, min, node.Value) && ValidateBST(node.Right, node.Value, max);
        
    }
}