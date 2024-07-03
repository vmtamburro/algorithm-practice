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

    
}