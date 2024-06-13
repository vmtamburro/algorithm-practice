using System;
using System.Collections.Generic;
using System.Linq;

public class ArrayManipulation
{



    /*
        Starting with a 1-indexed array of zeros and a list of operations, for each operation add a value to each the array element between two given indices, inclusive. 
        Once all operations have been performed, return the maximum value in the array.

        Example


        Queries are interpreted as follows:

            a b k
            1 5 3
            4 8 7
            6 9 1
        Add the values of  between the indices  and  inclusive:

        index->	 1 2 3 4 5 6 7 8 9 10
            [0,0,0,0,0,0,0,0,0,0]
            [3,3,3,3,3,0,0,0,0,0]
            [3,3,3,10,10,7,7,7,0,0]
            [3,3,3,10,10,8,8,8,1,0]
        The largest value is 10 after all operations are performed.
    */
    public static long arrayManipulation(int n, List<List<int>> queries)
    {
        long[] arr = new long[n + 1]; // Using long to avoid integer overflow

        foreach (var query in queries)
        {
            int a = query[0];
            int b = query[1];
            int k = query[2];

            arr[a - 1] += k; // Add k at index a-1 (0-based)
            if (b < n)
            {
                arr[b] -= k; // Subtract k at index b (but not beyond the end of array)
            }
        }

        long max = 0;
        long sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
            if (sum > max)
            {
                max = sum;
            }
        }

        return max;
    }



}
