public class BalancedForest{
    /*
        - Split tree into three connected components, so each component has the same sum of values
        - Remove exactly one edge from the tree to create two disconnected subtrees
        - Remove exactly one edge from the resulting subtrees to create two additional subtrees.


        - Build the tree from the given input
        - Calculate the sums of the trees
        - Identify edges that can be removed to split the tree into three parts with equal sums
    */

    public bool CanSplitIntoThreeParts(int n, int[] values, int[,] edges){
        // create an adjacency list for the tree
        var adj = new List<int>[n];
        for(int i = 0; i < n; i++){
            adj[i] = new List<int>();
        }

        // build the adjacency list
        for(int i = 0; i < n - 1; i++){
            int u = edges[i, 0] - 1;
            int v = edges[i, 1] - 1;
            adj[u].Add(v);
            adj[v].add(u);
        }

        int totalSum = values.Sum();

        if(totalSum % 3 != 0){
            return false;
        }


        int targetSum = totalSum / 3;   

        int[] subtreeSums = new int[n];
        bool[] visited = new bool[n];

        int CalculateSubtreeSum(int node){
            visited[node] = true;
            int sum = values[node];
            foreach(int child in adj[node]){
                if(!visited[child]){
                    sum += CalculateSubtreeSum(child);
                }
            }
            subtreeSums[node] = sum;
            return sum;
        }

        CalculateSubtreeSum(0);

        int foundParts = 0;
        foreach(int sum in subtreeSums){
            if(sum == targetSum){
                foundParts++;
            }
        }

        return foundParts >= 2;
    }
}