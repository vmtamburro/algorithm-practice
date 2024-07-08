public class MazeSolver{
    /*
        - Create a Graph Class, with a dictionary that stores the adjacency list
        - Add a method to construct the graph from the maze
        - Add a method to solve the maze using BFS
            - Create a queue to store the vertices
            - Create a hash set to store visited nodes
            - Add the start vertex to the queue and visited set
            - While the queue is not empty
                - Dequeue the vertex
                - If the vertex is the destination, return the steps
                - Iterate through the neighbors of the vertex
                    - If the neighbor is not visited
                        - Add the neighbor to the queue and visited set
            - Return the steps


            - Space Complexity (O(V + E))
                - V is the number of vertices to be processed
                - E is the number of edges to be processed
            - Time Complexity (O(V + E))
                - V is the number of vertices to be processed
                - E is the number of edges to be processed
    */
    public class Graph{
        public Dictionary<int, List<int>> adjacencyList;
        public Graph(){
            adjacencyList = new Dictionary<int, List<int>>();
        }

        public void ConstructGraph(int[][] maze){
            int rows = maze.Length;
            int cols = maze[0].Length;
            int n = rows * cols;

            // create an adjacency list for each vertex in the maze
            for(int i = 0; i < n; i++){
                adjacencyList[i] = new List<int>();
            }

            for(int i = 0; i < rows; i++){
                for(int j = 0; j < cols; j++){
                    int index = i * cols + j;
                    if(maze[i][j] == 0){
                        continue;
                    }
                    // and the neighbors to the adjacency list

                    
                    if(i - 1 >= 0 && maze[i - 1][j] == 0){ // up neighbor
                        adjacencyList[index].Add((i - 1) * cols + j);
                    }

                    if(i + 1 < rows && maze[i + 1][j] == 0){ // down neighbor
                        adjacencyList[index].Add((i + 1) * cols + j);
                    }

                    if(j - 1 >= 0 && maze[i][j - 1] == 0){ // left neighbor
                        adjacencyList[index].Add(i * cols + j - 1);
                    }

                    if(j + 1 < cols && maze[i][j + 1] == 0){ // right neighbor
                        adjacencyList[index].Add(i * cols + j + 1);
                    }
                }
            }
        }

        public int BFS(int[] start, int[] destination){
            int startVertex = start[0] * destination[1] + start[1];
            int destinationVertex = destination[0] * destination[1] + destination[1];
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            queue.Enqueue(startVertex);
            visited.Add(startVertex);
            int steps = 0;
            while(queue.Count() > 0){
                int size = queue.Count();
                for(int i = 0; i < size; i++){
                    int currentVertex = queue.Dequeue();
                    if(currentVertex == destinationVertex){
                        return steps;
                    }
                    foreach(var neighbor in adjacencyList[currentVertex]){
                        if(!visited.Contains(neighbor)){
                            queue.Enqueue(neighbor);
                            visited.Add(neighbor);
                        }
                    }
                }
                steps++;
            }
            return steps;
        }
    }

    public int MinStepsToReachDestniation(int[][] maze, int[] start, int[] destination){
        var graph = new Graph();
        graph.ConstructGraph(maze);
        return graph.BFS(start, destination);
    }
}