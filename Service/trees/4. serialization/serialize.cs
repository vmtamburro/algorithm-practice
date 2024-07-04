public class Serialize{
    public class Node 
    {
        public Node Left;
        public Node Right;
        public int Data;
        public Node(int data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
    }

    /*
        Method used to serialize a binary tree into a string
            - Pre-Order Traversal
            - Center, Left (recursive), Right(recursive)

    1
   / \
  2   3
     / \
    4   5


            - Start at the Root (1)
                - Print 1
            - Traverse Left (2)
                - Print 2
                - Traverse Left (null)
                - Traverse Right (null)
            - Return up to 1
            - Traverse Right
                - Print 3
                - Traverse Left
                    - Print 4
                    - Traverse Left
                        - Print 4
                        - Traverse Left null
                        - Traverse Right null
                - Return up to 3
                - Traverse Right
                    - Print 5
                    - Traverse Left
                    - Traverse Right
    */

    public string SerializeTree(Node node)
    {
        if (node == null)
        {
            return "null";
        }

        return node.Data + "," + SerializeTree(node.Left) + "," + SerializeTree(node.Right);
    }
}