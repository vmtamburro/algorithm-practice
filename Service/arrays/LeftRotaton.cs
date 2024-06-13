using System;
using System.Collections.Generic;
using System.Linq;

public class LeftRotation
{
    /*
    * Complete the 'rotLeft' function below.
    *
    * The function is expected to return an INTEGER_ARRAY.
    * The function accepts following parameters:
    *  1. INTEGER_ARRAY a
    *  2. INTEGER d
    */
    public static List<int> rotLeft(List<int> a, int d)
    {
        var b = a.Slice(0, d);
        a.RemoveRange(0, d);
        a.AddRange(b);
        return a;
    }
    public static List<int> rotLeftAlternate(List<int> a, int d)
    {
        // Ensure d is within bounds of array size
        d = d % a.Count;

        // Create a new list to hold rotated elements
        List<int> rotated = new List<int>();

        // Add elements from index d to end of original list
        rotated.AddRange(a.GetRange(d, a.Count - d));

        // Add elements from start to index d-1 of original list
        rotated.AddRange(a.GetRange(0, d));

        return rotated;
    }

}
