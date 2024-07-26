public class RandoPractice_Trees_BinarySearchTree
{
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            this.Value = value;
            Left = null;
            Right = null;
        }
    }
    public class BST
    {
        private TreeNode root;

        public void Insert(int value)
        {
            root = InsertRec(root, value);
        }

        private TreeNode InsertRec(TreeNode node, int value)
        {
            if (node == null)
            {
                node = new TreeNode(value);
                return node;
            }

            if (value < node.Value)
                node.Left = InsertRec(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertRec(node.Right, value);

            return node;
        }

        public bool Search(int value)
        {
            return SearchRec(root, value);
        }

        private bool SearchRec(TreeNode node, int value)
        {
            if (node == null)
                return false;
            if (node.Value == value)
                return true;
            if (value < node.Value)
                return SearchRec(node.Left, value);
            else
                return SearchRec(node.Right, value);
        }

        public void Delete(int value)
        {
            root = DeleteRec(root, value);
        }

        private TreeNode DeleteRec(TreeNode root, int value)
        {
            if (root == null)
                return root;

            if (value < root.Value)
                root.Left = DeleteRec(root.Left, value);
            else if (value > root.Value)
                root.Right = DeleteRec(root.Right, value);
            else
            {
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                root.Value = MinValue(root.Right);
                root.Right = DeleteRec(root.Right, root.Value);
            }

            return root;
        }

        private int MinValue(TreeNode node)
        {
            int minValue = node.Value;
            while (node.Left != null)
            {
                minValue = node.Left.Value;
                node = node.Left;
            }
            return minValue;
        }
    }

}