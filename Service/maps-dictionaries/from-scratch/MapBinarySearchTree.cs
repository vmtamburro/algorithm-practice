using System;

public class TreeNode
{
    public string Key { get; set; }
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(string key, int value)
    {
        Key = key;
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinarySearchTree
{
    private TreeNode root;

    public void Insert(string key, int value)
    {
        root = Insert(root, key, value);
    }

    private TreeNode Insert(TreeNode node, string key, int value)
    {
        if (node == null)
        {
            return new TreeNode(key, value);
        }

        int compare = string.Compare(key, node.Key);
        if (compare < 0)
        {
            node.Left = Insert(node.Left, key, value);
        }
        else if (compare > 0)
        {
            node.Right = Insert(node.Right, key, value);
        }
        else
        {
            node.Value = value; // Update value if key already exists
        }
        return node;
    }

    public int? Get(string key)
    {
        return Get(root, key);
    }

    private int? Get(TreeNode node, string key)
    {
        if (node == null)
        {
            return null;
        }

        int compare = string.Compare(key, node.Key);
        if (compare < 0)
        {
            return Get(node.Left, key);
        }
        else if (compare > 0)
        {
            return Get(node.Right, key);
        }
        else
        {
            return node.Value;
        }
    }

    public void Delete(string key)
    {
        root = Delete(root, key);
    }

    private TreeNode Delete(TreeNode node, string key)
    {
        if (node == null)
        {
            return null;
        }

        int compare = string.Compare(key, node.Key);
        if (compare < 0)
        {
            node.Left = Delete(node.Left, key);
        }
        else if (compare > 0)
        {
            node.Right = Delete(node.Right, key);
        }
        else
        {
            // Node with only one child or no child
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }

            // Node with two children: Get the inorder successor (smallest in the right subtree)
            TreeNode temp = MinValueNode(node.Right);

            node.Key = temp.Key;
            node.Value = temp.Value;

            node.Right = Delete(node.Right, temp.Key);
        }
        return node;
    }

    private TreeNode MinValueNode(TreeNode node)
    {
        TreeNode current = node;
        while (current.Left != null)
        {
            current = current.Left;
        }
        return current;
    }
}

