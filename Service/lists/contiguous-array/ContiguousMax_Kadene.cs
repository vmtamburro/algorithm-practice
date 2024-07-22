using System;

class ContiguousKadene
{
    public static int FindMaxSumOfContiguousSubarray(int[] nums)
    {
        if (nums.Length == 0)
            throw new ArgumentException("Array cannot be empty");

        int maxSoFar = nums[0];
        int maxEndingHere = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
            maxSoFar = Math.Max(maxSoFar, maxEndingHere);
        }

        return maxSoFar;
    }

    static void Main()
    {
        int[] array = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        int maxSum = FindMaxSumOfContiguousSubarray(array);
        Console.WriteLine("Maximum sum of contiguous subarray: " + maxSum); // Output: 6
    }
}
