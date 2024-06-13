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
}
