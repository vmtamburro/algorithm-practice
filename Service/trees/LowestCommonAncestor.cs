using System;
using System.Collections.Generic;
using System.IO;

namespace LCA
{
    class Solution
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


        static void Main(String[] args)
        {
            // Read input
            int n = int.Parse(Console.ReadLine()); // Number of nodes in the tree
            int[] nodeValues = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            //Console.WriteLine(String.Join(",", nodeValues.ToList()));

            int[] indexValues = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var firstValue = indexValues[0];
            var secondValue = indexValues[1];

            // Build the binary search tree
            Node root = BuildBST(nodeValues);
            Console.WriteLine(FindLCA(root, firstValue, secondValue));
        }


        private static int FindLCA(Node node, int v1, int v2){
            while(node != null){
                if(v1 < node.Value && v2 < node.Value){
                    // both are on the left side of the tree
                    node = node.Left;
                }
                if(v1 > node.Value && v2 > node.Value){
                    // both are on the right side of the tree
                    node = node.Right;
                }
                else{
                    // one is on the left, and one is on the right. This is the LCA
                    break;
                }
            }

            return node.Value;
        }

        // Function to build a Binary Search Tree (BST)
        private static Node BuildBST(int[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            Node root = new Node(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                InsertIntoBST(root, values[i]);
            }
            return root;
        }

        // Helper function to insert a value into BST
        private static void InsertIntoBST(Node root, int value)
        {
            if (value < root.Value)
            {
                if (root.Left == null)
                    root.Left = new Node(value);
                else
                    InsertIntoBST(root.Left, value);
            }
            else if (value > root.Value)
            {
                if (root.Right == null)
                    root.Right = new Node(value);
                else
                    InsertIntoBST(root.Right, value);
            }
            // Ignore if value is equal to root.Value (assuming no duplicates in BST)
        }
    }


}