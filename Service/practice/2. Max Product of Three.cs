using System;
using System.Linq;

public class Solution {
    public int MaxProductOfThree(int[] A) {
        // Sort the array
        Array.Sort(A);

        int n = A.Length;
        
        // Option 1: Product of three largest numbers
        int option1 = A[n - 1] * A[n - 2] * A[n - 3];

        // Option 2: Product of two smallest numbers (most negative) and the largest number
        int option2 = A[0] * A[1] * A[n - 1];

        // Return the maximum of the two options
        return Math.Max(option1, option2);
    }
}
