using Example;

public class InOrder
{
    public class Node
    {
        public Node Left;
        public Node Right;
        public int Data;
        public Node(int data)
        {
            this.Data = Data;
            this.Left = null;
            this.Right = null;
        }
    }

    public void PrintInline(Node node)
    {
        if (node.Left != null)
        {
            PrintInline(node.Left);
        }

        Console.WriteLine(node.Data);

        if (node.Right != null)
        {
            PrintInline(node.Right);
        }
    }

}