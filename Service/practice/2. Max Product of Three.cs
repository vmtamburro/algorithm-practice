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

     public int MaxProductOfThree(int[] A) {
        // Initialize variables
        int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
        int min1 = int.MaxValue, min2 = int.MaxValue;

        // Find the required max and min values in one pass
        foreach (int num in A) {
            // Update max values
            if (num > max1) {
                max3 = max2;
                max2 = max1;
                max1 = num;
            } else if (num > max2) {
                max3 = max2;
                max2 = num;
            } else if (num > max3) {
                max3 = num;
            }

            // Update min values
            if (num < min1) {
                min2 = min1;
                min1 = num;
            } else if (num < min2) {
                min2 = num;
            }
        }

        // Compute the two possible max products
        int option1 = max1 * max2 * max3; // Three largest numbers
        int option2 = min1 * min2 * max1; // Two smallest negatives + largest positive

        return Math.Max(option1, option2);
}
