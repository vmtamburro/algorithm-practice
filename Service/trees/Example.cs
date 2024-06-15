namespace Example
{
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int value)
        {
            Left = null;
            Right = null;
            Value = value;
        }
    }

    public class BinaryTree
    {
        public TreeNode Root;
        public BinaryTree()
        {
            Root = null;
        }

        public void BFS()
        {
            if (Root == null) return;

            Queue<TreeNode> queue = new Queue<TreeNode>(); //LIFO
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                Console.WriteLine(current.Value + " ");

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
        }


        // DFS Pre-order Traversal
        public void DFSPreOrder(TreeNode node)
        {
            if (node == null) return;

            Console.Write(node.Value + " ");
            DFSPreOrder(node.Left);
            DFSPreOrder(node.Right);
        }


        // DFS In-order Traversal
        public void DFSInOrder(TreeNode node)
        {
            if (node == null) return;

            DFSInOrder(node.Left);
            Console.Write(node.Value + " ");
            DFSInOrder(node.Right);
        }

        // DFS Post-order Traversal
        public void DFSPostOrder(TreeNode node)
        {
            if (node == null) return;

            DFSPostOrder(node.Left);
            DFSPostOrder(node.Right);
            Console.Write(node.Value + " ");
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            // Creating the binary tree:
            //         1
            //        / \
            //       2   3
            //      / \   \
            //     4   5   6

            tree.Root = new TreeNode(1);
            tree.Root.Left = new TreeNode(2);
            tree.Root.Right = new TreeNode(3);
            tree.Root.Left.Left = new TreeNode(4);
            tree.Root.Left.Right = new TreeNode(5);
            tree.Root.Right.Right = new TreeNode(6);

            Console.WriteLine("BFS Traversal:");
            tree.BFS();
            Console.WriteLine();

            Console.WriteLine("DFS Pre-order Traversal:");
            tree.DFSPreOrder(tree.Root);
            Console.WriteLine();

            Console.WriteLine("DFS In-order Traversal:");
            tree.DFSInOrder(tree.Root);
            Console.WriteLine();

            Console.WriteLine("DFS Post-order Traversal:");
            tree.DFSPostOrder(tree.Root);
            Console.WriteLine();
        }


        public TreeNode BuildBST(int[] values){
            if(values == null || values.Length == 0){
                return null;
            }

            TreeNode root = new TreeNode(values[0]);
            for(var i =1; i < values.Length; i++){ // start at second index since we already added the first as the root
               InsertIntoBST(root, values[i]);
            }

            return root;
        }

        private static void InsertIntoBST(TreeNode root, int value)
        {
            if (value < root.Value)
            {
                if (root.Left == null)
                    root.Left = new TreeNode(value);
                else
                    InsertIntoBST(root.Left, value);
            }
            else if (value > root.Value)
            {
                if (root.Right == null)
                    root.Right = new TreeNode(value);
                else
                    InsertIntoBST(root.Right, value);
            }
            // Ignore if value is equal to root.Value (assuming no duplicates in BST)
        }
    }
}