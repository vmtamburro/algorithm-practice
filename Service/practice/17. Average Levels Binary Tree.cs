/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
 IList<IList<int>> answer = new List<IList<int>>();

    private void Order(TreeNode node, int level){
        if(node == null) return;

        if(level == answer.Count()){ // we're breaking into a new level
            answer.Add(new List<int>());
        }

        answer[level].Add(node.val);

        if(node.left != null){
            Order(node.left, level + 1);
        }
        if(node.right != null){
            Order(node.right, level + 1);
        }
    }


    public IList<double> AverageOfLevels(TreeNode root) {
        Order(root, 0);
        var averageList = new List<double>();
        foreach(var list in answer){
            averageList.Add(list.Average());
        }
        return averageList;
    }
}