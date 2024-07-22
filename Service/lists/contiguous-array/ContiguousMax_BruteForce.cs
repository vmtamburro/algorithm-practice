using System;

class ContiguousBruteForce
{
    public static int FindMaxSumOfContiguousSubarray(int[] nums)
    {
        int n = nums.Length;
        int maxSum = int.MinValue;

        // Check all subarrays
        for (int start = 0; start < n; start++)
        {
            for (int end = start; end < n; end++)
            {
                int currentSum = 0;
                // Calculate sum of the current subarray
                for (int k = start; k <= end; k++)
                {
                    currentSum += nums[k];
                }
                // Update the maximum sum if needed
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        return maxSum;
    }

    static void Main()
    {
        int[] array = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        int maxSum = FindMaxSumOfContiguousSubarray(array);
        Console.WriteLine("Maximum sum of contiguous subarray: " + maxSum); // Output: 6
    }
}
