using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'swapNodes' function below.
     *
     * The function is expected to return a 2D_INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY indexes
     *  2. INTEGER_ARRAY queries
     */
    public class Node{
        public int Data {get; set;}
        public Node Left {get; set;}
        public Node Right {get; set;}
        public int Depth {get; set;}
    }

    public static List<List<int>> swapNodes(List<List<int>> indexes, List<int> queries)
    {
        var returnList = new List<List<int>>();
        var root = new Node(){Data = 1, Depth = 1};
        
        BuildTree(root, indexes);
        
        
        for(int i = 0; i < queries.Count(); i++){
            var swapList = new List<int>();
            var nodeQueue = new Queue<Node>();
            if(root.Depth % queries[i] == 0){
                Swap(root);
            }
              //  Console.WriteLine("Left" + root.Left.Data);
              //  Console.WriteLine("Right" + root.Right.Data);
              //  Console.WriteLine("Root" + root.Data);
            
            EnqueueChildren(nodeQueue, root);
            while(nodeQueue.Count > 0){
                var node = nodeQueue.Dequeue();
                if(node.Depth % queries[i] == 0){
                    Swap(node);
                }
                EnqueueChildren(nodeQueue, node);
            }
            PopulateList(root, swapList);
            
            returnList.Add(swapList);
            
        }
        
        return returnList;
        
    }
    
    public static void PopulateList(Node node, List<int> returnList){
        if(node.Left != null){
            PopulateList(node.Left, returnList);
        }
        
     //   Console.WriteLine("Adding " + node.Data + " to list");
        returnList.Add(node.Data);
        
        if(node.Right != null){
            PopulateList(node.Right, returnList);
        }
    }
    
    
    
    public static void EnqueueChildren(Queue<Node> nodeQueue, Node node){
        // Add Left To Queue
        if(node.Left != null){
            nodeQueue.Enqueue(node.Left);
        }
        
        // Add Right To Queue
        if(node.Right != null){
            nodeQueue.Enqueue(node.Right);
        }
    }
    
    public static void Swap(Node node){
        var temp = node.Left;
        node.Left = node.Right;
        node.Right = temp;
    }
    
    
    
    public static void BuildTree(Node node, List<List<int>> swapNodes){
        // Retrieve Data
        var leftData = swapNodes[node.Data - 1][0];
        var rightData = swapNodes[node.Data - 1][1];
        
        //Build Left Node
        if(leftData == -1){
            node.Left = null;
        }else{
            var leftNode = new Node(){
                Data = leftData,
                Depth = node.Depth + 1
            };
            node.Left = leftNode;
            BuildTree(leftNode, swapNodes);
        }
        
        //Build Right Node
        if(rightData == -1){
            node.Right = null;
        }
        else{
            var rightNode = new Node(){
                Data = rightData,
                Depth = node.Depth + 1
            };
            node.Right = rightNode;
            BuildTree(rightNode, swapNodes);
        }
        
    }
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> indexes = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            indexes.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(indexesTemp => Convert.ToInt32(indexesTemp)).ToList());
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> queries = new List<int>();

        for (int i = 0; i < queriesCount; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<List<int>> result = Result.swapNodes(indexes, queries);

        textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

        textWriter.Flush();
        textWriter.Close();
    }
}