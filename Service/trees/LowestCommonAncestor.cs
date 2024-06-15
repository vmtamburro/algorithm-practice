using System;
using System.Collections.Generic;
using System.IO;
public class LowestCommonAncestor
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


    public static void Main(String[] args)
    {
        // Read input
        int n = int.Parse(args[0]); // Number of nodes in the tree
        int[] nodeValues = Array.ConvertAll(args[1].Split(' '), int.Parse);
        //Console.WriteLine(String.Join(",", nodeValues.ToList()));

        int[] indexValues = Array.ConvertAll(args[2].Split(' '), int.Parse);

        var firstValue = indexValues[0];
        var secondValue = indexValues[1];

        // Build the binary search tree
        Node root = BuildBST(nodeValues);

        Node lca = FindLCA(root, firstValue, secondValue);
        if (lca != null)
        {
            Console.WriteLine(lca.Value);
        }
    }

    private static Node FindLCA(Node node, int v1, int v2)
    {
        if (node == null) return null;

        if (v1 < node.Value && v2 < node.Value)
        {
            return FindLCA(node.Left, v1, v2);
        }

        if (v1 > node.Value && v2 > node.Value)
        {
            return FindLCA(node.Right, v1, v2);
        }

        return node;
    }

    // In this case a while loop wouldn't work. Need to use recursion in case one value is actually an ancestor of another
    // Otherwise we would just find the ancestor of both, which is incorrect

    // private static Node FindLCA(Node node, int v1, int v2)
    // {
    //     while (node != null)
    //     {
    //         if (v1 < node.Value && v2 < node.Value)
    //         {
    //             // both are on the left side of the tree
    //             node = node.Left;
    //         }
    //         else if (v1 > node.Value && v2 > node.Value)
    //         {
    //             // both are on the right side of the tree
    //             node = node.Right;
    //         }
    //         else
    //         {
    //             // one is on the left, and one is on the right. This is the LCA
    //             break;
    //         }
    //     }
    //     return node;
    // }

    // Function to build a Binary Search Tree (BST)
    private static Node BuildBST(int[] values)
    {
        Node root = null;
        for (var i = 0; i < values.Length; i++)
        {
            root = insert(root, values[i]);
        }
        return root;
    }


    private static Node insert(Node root, int value)
    {
        if (root == null)
        {
            return new Node(value);
        }
        else
        {
            Node cur;
            if (value <= root.Value)
            {
                cur = insert(root.Left, value);
                root.Left = cur;
            }
            else
            {
                cur = insert(root.Right, value);
                root.Right = cur;
            }
            return root;
        }

    }
}
