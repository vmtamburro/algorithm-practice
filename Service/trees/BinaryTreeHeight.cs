
namespace TreeHeight
{

    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Left = null;
            Right = null;
            Value = value;
        }
    }
    public class Program
    {
        public static int getHeight(Node root)
        {
           if (root == null) return -1;
            // recursion! add additional depths
            var leftDepth = getHeight(root.Left);
            var rightDepth = getHeight(root.Right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

    }
}