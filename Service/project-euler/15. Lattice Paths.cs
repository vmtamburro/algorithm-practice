public class Euler15{
    /* 
        Starting in the top left corner of a 2x2 grid, and only being able to move to the right and down, there are exactly six routes to the bottom right corner.
        
        R-R-D-D
        R-D-R-D
        R-D-D-R
        D-R-R-D
        D-R-D-R
        D-D-R-R

        How many such routes are there through a 20x20 grid?
    */

    public enum Directions{
        Right = 1,
        Down = 2
    }

    public int LatticePath(int gridSize = 20){
        var firstPath = new List<int>();

        // BuildString
        for(var i = 0; i < gridSize; i ++){
            firstPath.Add((int)Directions.Down);
            firstPath.Add((int)Directions.Right);
        }

        // Generate Permutations
        var permutations = GetPermutations(firstPath);

        return permutations.Count();
    }

    
    public static List<List<int>> GetPermutations(List<int> list)
    {
        // create a list to store permutations
        var result = new List<List<int>>();
        Permute(list, 0, result);
        return result;
    }



    /* 
        1, 2, 3
        1, 3, 2
        2, 1, 3
        2, 3, 1
        3, 2, 1
        3, 1, 2
    */
    private static void Permute(List<int> list, int start, List<List<int>> result)
    {
        if (start >= list.Count)
        {
            // start index is equal to the list size
            result.Add(new List<int>(list));
        }
        else
        {
            for (int i = start; i < list.Count; i++)
            {
                Swap(list, start, i);
                Permute(list, start + 1, result); // recursive call to permute the rest of the list
                Swap(list, start, i); // backtrack
            }
        }
    }

    private static void Swap(List<int> list, int a, int b)
    {
        int temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }
}