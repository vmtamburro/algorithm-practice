public class DetectCycle{
    // Use the DFS algorithm with a list for visited, and a list to keep track of the vertices currently part of the DFS function
    // If a vertex is visited and is in the current path, then there is a cycle


    /*

    Graph:
        0 -> 1 -> 2 -> 3 -> 0
        4 -> 5

    - 0 points to 1, 1 points to 2, 2 points to 3, 3 points to 0
    - Nodes 4 and 5 are isolated

    - Start at 0
    - Add 0 to visited and current path
    - Explore neighbors of 0
        - Visit 1
        - Add 1 to visited and current path
        - Explore neighbors of 1
            - Visit 2
            - Add 2 to visited and current path
            - Explore neighbors of 2
                - Visit 3
                - Add 3 to visited and current path
                - Explore neighbors of 3
                    - Visit 0
                    - 0 is visited and in the current path, cycle detected. Return True
                - Early Exit


        Time Complexity: O(V + E)
        Space Complexity O(V) for `visited  ` and `currentPath` and O(V + E) for the adjacency list

    */

    public class Graph{
        public Dictionary<int, List<int>> adjacencyList;
        public Graph(){
            adjacencyList = new Dictionary<int, List<int>>();
        }


        public bool IsCyclic(int startVertex){
            var visited = new HashSet<int>();
            var currentPath = new HashSet<int>();
            
            return IsCyclicUtil(startVertex, visited, currentPath);
        }

        public bool IsCyclicUtil(int vertex, HashSet<int> visited, HashSet<int> currentPath){
            // mark current vertex visited
            visited.Add(vertex);
            // add it to the current path
            currentPath.Add(vertex);

            foreach(var neighbor in adjacencyList[vertex]){
                // neighbor is not yet visited
                if(!visited.Contains(neighbor)){
                    // check if there is a cycle in the neighbor
                    if(IsCyclicUtil(neighbor, visited, currentPath)){
                        return true;
                    }
                }
                else if(currentPath.Contains(neighbor)){
                    // neighbor is visited and is in the current path, indicates a cycle
                    return true;
                }
            }
            
            // prevent false positives by removing the vertex from the current path
            currentPath.Remove(vertex);
            return false;
        }
    }
}