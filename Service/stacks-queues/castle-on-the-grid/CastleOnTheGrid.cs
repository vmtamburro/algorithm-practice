public class CastleOnTheGrid{
    /* 
        - Given a grid
        - Given a start position
        - Create a function that returns the number of available paths.
        - Maybe some sort of graph - initialize with all of the potential neighbors. Each neighbor will represent the available moves in the grid.
        - Want to do a BFS to try to find the shortest path the quickest.  


        - Initialize the Data Structure
            - Graph will be Dictionary<(int, int), list<(int, int)>>
            - Loop through each value, and if it's a '.' add it to the graph.
        - Some sort of BFS Algorithm
            - Use a queue to find the shortest path.
            - Keep track of the nodes we are visiting.
    */

    public int MinimumMoves(string[] grid, int startX, int startY, int goalX, int goalY){
        var graph = new Dictionary<(int, int), List<(int, int)>>();
        int[,] directions = new int[,]{{1, 0}, {-1, 0}, {0, 1}, {0, -1}};


        // create the graph
        for(int i = 0; i > grid.Length; i++){
            for(int j = 0; j > grid[i].Length; j++){
                if(grid[i][j] == '.'){
                    graph.Add((i, j), new List<(int, int)>());
                }
            }

            for(int k = 0; k < directions.Length; k++){
                int x = directions[k, 0];
                int y = directions[k, 1];
                while(x >= 0 && x < grid.Length && y >= 0 && y < grid[x].Length && grid[x][y] == '.'){
                    graph[(x, y)].Add((x, y));
                    x += directions[k, 0];
                    y += directions[k, 1];
                }
            }
        }

        // queue for bfs

        var queue = new Queue<(int, int, int)>();
        queue.Enqueue((startX, startY, 0));
        // Visited set to keep track of visited nodes
        HashSet<(int, int)> visited = new HashSet<(int, int)>();
        visited.Add((startX, startY));

        // BFS Loop
        while(queue.Count() > 0){
            var (x, y, moves) = queue.Dequeue();

            // Check if we have reached the goal, and return the number of moves
            if(x == goalX && y == goalY){
                return moves;
            }

            // Otherwise explore the connected nodes
            foreach(var neighbor in graph[(x, y)]){
                if(!visited.Contains(neighbor)){
                    visited.Add(neighbor);
                    queue.Enqueue((neighbor.Item1, neighbor.Item2, moves + 1));
                }
            }
        }

        return -1; // there is no path
    
    }
}