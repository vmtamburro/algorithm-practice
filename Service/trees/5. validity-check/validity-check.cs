public class CheckValid{
    public class Node{
        public Node Left;
        public Node Right;
        public int Data;
        public Node(int Data){
            this.Data = Data;
            this.Left = null;
            this.Right = null;
        }
    }

    public bool IsValidBsTree(Node root){
        return IsValid(root, Int32.MinValue, Int32.MaxValue);
    }


    public bool IsValid(Node node, int min, int max){
        if(node == null){
            return true;
        }

        if(node.Data < min || node.Data > max){
            return false;
        }

        return IsValid(node.Left, min, node.Data) && IsValid(node.Right, node.Data, max);
    }
}