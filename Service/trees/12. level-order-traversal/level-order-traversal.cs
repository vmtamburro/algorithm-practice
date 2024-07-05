public class LevelOrder{
    public class Node{
        public Node Left;
        public Node Right;
        public int Data;
        public Node(int data){
            this.Left = null;
            this.Right = null;
            this.Data = data;
        }
    }

    /*
        - Create a result list of lists for return
        - Set the level to the index 0

        - Function to do a level order traversal
            - Check to see if the index of the level exists in the result list
                - If it does not, add a new list to the result list
            - Add the current node to the list at the level index
            - Recursively call the function on the left and right nodes

        - Time Complexity is O(n) where n is the number of nodes in the binary tree
        - Space Complexity is O(n) space used by the result list to store node values, an the recursion stack space.
    */

    public List<List<int>> LevelOrderTraversal(Node root){
        var result = new List<List<int>>();
        int level = 0;
        LevelOrderTraversal(root, result, level);

        return result;
        
    }

    public void LevelOrderTraversal(Node node, List<List<int>> result, int level){
        if(node == null) return;

        if(result.Count == level){
            result.Add(new List<int>());
        }

        result[level].Add(node.Data);
        LevelOrderTraversal(node.Left, result, level + 1);
        LevelOrderTraversal(node.Right, result, level + 1);
    }
}