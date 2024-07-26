public class RandoPractice_Trees_AVLTree{
    public class AVLNode
{
    public int Value;
    public AVLNode Left;
    public AVLNode Right;
    public int Height;

    public AVLNode(int value)
    {
        Value = value;
        Left = Right = null;
        Height = 1;
    }
}

public class AVLTree
{
    private AVLNode root;

    public void Insert(int value)
    {
        root = InsertRec(root, value);
    }

    private AVLNode InsertRec(AVLNode node, int value)
    {
        if (node == null)
            return new AVLNode(value);

        if (value < node.Value)
            node.Left = InsertRec(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertRec(node.Right, value);
        else
            return node;

        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        int balance = GetBalance(node);

        if (balance > 1 && value < node.Left.Value)
            return RightRotate(node);

        if (balance < -1 && value > node.Right.Value)
            return LeftRotate(node);

        if (balance > 1 && value > node.Left.Value)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        if (balance < -1 && value < node.Right.Value)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    private AVLNode RightRotate(AVLNode y)
    {
        AVLNode x = y.Left;
        AVLNode T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));
        x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));

        return x;
    }

    private AVLNode LeftRotate(AVLNode x)
    {
        AVLNode y = x.Right;
        AVLNode T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));
        y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));

        return y;
    }

    private int GetHeight(AVLNode node)
    {
        return node == null ? 0 : node.Height;
    }

    private int GetBalance(AVLNode node)
    {
        return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
    }
}

}