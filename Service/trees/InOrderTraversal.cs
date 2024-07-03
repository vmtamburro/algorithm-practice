public class InOrderTraversal{
    public class Node{
        public Node Left;
        public Node Right;
        public int Data;
        public Node(int data){
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
    }


    /* 
        Method used to visit all nodes in a binary search tree in a specific order.
        1. Left Subtree is visited (recursively)
        2. Root Node is Visited
        3. Right Subtree is visited  (recursively)



        // Start at Root. Visit the Left

        // Step down to 3, Does it have a left node?
            // Yes? Step Down to Two, Does it have a left node?
                // No? Print and return
            // Back to 3, visit the node. Print.
            // Does it have a right node?
                // Yes? Step down to four, Does it have a right node?
                    // No? Print and Return

                
        // Back to 5, visit the node, Print
            // Does it have a right node?
                // Yes? Step down to six, does it have a 


        // Recursive Function PrintInline
            // Take in the Root Node
            // Search Left (recursive)
            // Print Self
            // Search Right (recursive)


        // Time Complexity:
            - This time complexity is O(n) where n is the number of nodes in the tree
            - Each node is visited exactly once making it optimal for processing all nodes in linear time

        // Space Complexity:
            - This space complexity is O(h) where h is the height of the tree.
            - This is because of the recursive calls that are placed on the stack,
                which corresponds to the maximum depth of recursion (i.e. the height of the tree)
    */

    public void PrintInline(Node node){
        if(node.Left != null){
            PrintInline(node.Left);
        }
        
        Console.WriteLine(node.Data);

        if(node.Right != null){
            PrintInline(node.Right);
        }
    }
}