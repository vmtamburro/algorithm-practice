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