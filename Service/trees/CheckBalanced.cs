public class CheckBalanced{
    public class Node{
        public Node Left;
        public Node Right;
        public int Value;
    }

    /* 
        Implement a function to check if a binary tree is balanced.
        For the purposes of this question, a balanced tree is one thats heights
        of the subtrees never differ by more than one.
    */

    public bool IsBalanced(Node root){
        if(root == null) return true;

        var leftSubTrees =  GetHeight(root.Left);
        var rightSubTrees = GetHeight(root.Right);

        if(Math.Abs(leftSubTrees - rightSubTrees) > 1){
            return false;
        }
        else{
            return IsBalanced(root.Left) && IsBalanced(root.Right);
        }
    }

    public int GetHeight(Node current){
        if(current == null) return 0;

        return Math.Max(GetHeight(current.Left), GetHeight(current.Right)) + 1;
    }

    /*
        Above solution is not very efficient. O(N * log(N)), we call the getHeight repeatedly on the same nodes. 
    */
}