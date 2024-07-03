using System;

public class RedBlackTree{
    private enum NodeColor{
        Red = 1,
        Black = 2
    }

    private class Node{
        public int Data;
        public Node Left;
        public Node Right;
        public NodeColor Color;

        public Node(int data){
            Data = data;
            Color = NodeColor.Red; // New Nodes are initially red.
        }

    }

    private Node root;

    // Constructor
    public RedBlackTree(){
        root = null;
    }

    // Insertion Method

    public void Insert(int data){
        root = Insert(root, data);
        root.Color = NodeColor.Black; // Ensure the root is always black
    }

    private Node Insert(Node node, int data){
        if(node == null){
            return new Node(data); //generating new tree
        }

        // traverse down to point of insertion
        if(data < node.Data){
            node.Left = Insert(node.Left, data);
        }
        else if(data > node.Data){
            node.Right = Insert(node.Right, data);
        }
        else{
            // duplicate value, don't allow insertion (depends on requirements)
            return node;
        }


        // Perform rotations and recoloring to maintain red-black tree properties
        if(IsRed(node.Right) && !IsRed(node.Left)){
            node = RotateLeft(node);
        }
        if(IsRed(node.Left) && IsRed(node.Left.Left)){
            node = RotateRight(node);
        }
        if(IsRed(node.Left) && IsRed(node.Right)){
            FlipColors(node);
        }

        return node;
    }


    private Node DeleteNode(Node root, int value){
        if(root == null) return root;

        if(value < root.Data){
            root.Left = DeleteNode(root.Left, value);
        }
        else if(value > root.Data){
            root.Right = DeleteNode(root.Right, value);
        }
        else{
            // Case 1: Node has no children or only one child
            if (root.Left == null || root.Right == null)
            {
                Node temp = root.Left ?? root.Right;

                // Case 1.1: Node has no children
                if (temp == null)
                {
                    temp = root;
                    root = null;
                }
                // Case 1.2: Node has one child
                else
                {
                    // Copy the contents of the non-null child
                    root = temp;
                }
                temp = null; // Free memory
            }
            else
            {
                // Case 2: Node has two children
                // Find the minimum value node in the right subtree
                Node temp = MinimumValueNode(root.Right);

                // Copy the minimum value node's content to this node
                root.Data = temp.Data;

                // Delete the minimum value node
                root.Right = DeleteNode(root.Right, temp.Data);
            }
        }

        // If the tree had only one node then return
        if (root == null)
            return root;

        // Step 2: Balance the tree
        // TODO: Implement balancing code here

        return root;
    }

     // Helper function to find the node with the minimum value
    private Node MinimumValueNode(Node node)
    {
        Node current = node;
        while (current.Left != null)
        {
            current = current.Left;
        }
        return current;
    }

    // Helper methods for rotations and color flipping
    private bool IsRed(Node node)
    {
        if (node == null)
        {
            return false; // Null nodes are considered black
        }
        return node.Color == NodeColor.Red;
    }

    private Node RotateLeft(Node node)
    {
        Node temp = node.Right;
        node.Right = temp.Left;
        temp.Left = node;
        temp.Color = node.Color;
        node.Color = NodeColor.Red;
        return temp;
    }

    private Node RotateRight(Node node)
    {
        Node temp = node.Left;
        node.Left = temp.Right;
        temp.Right = node;
        temp.Color = node.Color;
        node.Color = NodeColor.Red;
        return temp;
    }

    private void FlipColors(Node node)
    {
        node.Color = NodeColor.Red;
        node.Left.Color = NodeColor.Black;
        node.Right.Color = NodeColor.Black;
    }
}