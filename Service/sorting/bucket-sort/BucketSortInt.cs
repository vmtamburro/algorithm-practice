using System;
using System.Collections.Generic;

public class BucketSortInt
{
    // Sorts an array of integers using bucket sort
    public static void Sort(int[] array)
    {
        // Return if the array is empty
        if (array.Length == 0)
            return;

        // Find the maximum value in the array to determine the range of buckets
        int maxValue = FindMaxValue(array);

        // Determine the number of buckets to use
        int numberOfBuckets = (int)Math.Sqrt(array.Length);
        
        // Initialize buckets as a list of lists
        List<int>[] buckets = new List<int>[numberOfBuckets];
        
        // Create individual buckets
        for (int i = 0; i < numberOfBuckets; i++)
        {
            buckets[i] = new List<int>();
        }

        // Distribute array values into buckets
        foreach (int value in array)
        {
            // Calculate bucket index for the value
            int bucketIndex = (value * numberOfBuckets) / (maxValue + 1);
            // Add the value to the appropriate bucket
            buckets[bucketIndex].Add(value);
        }

        // Initialize the index for the sorted array
        int index = 0;
        
        // Sort each bucket and concatenate results
        foreach (var bucket in buckets)
        {
            // Sort the current bucket
            bucket.Sort();
            // Add sorted values from the bucket to the array
            foreach (var value in bucket)
            {
                array[index++] = value;
            }
        }
    }

    // Helper method to find the maximum value in the array
    private static int FindMaxValue(int[] array)
    {
        int maxValue = array[0];
        foreach (int value in array)
        {
            if (value > maxValue)
                maxValue = value;
        }
        return maxValue;
    }

    // Main method to demonstrate bucket sort
    public static void Main(string[] args)
    {
        // Sample array of integers
        int[] array = { 78, 17, 39, 26, 72, 94, 21, 12, 23, 68 };
        // Print the original array
        Console.WriteLine("Original Array: " + string.Join(", ", array));
        
        // Sort the array using bucket sort
        Sort(array);
        
        // Print the sorted array
        Console.WriteLine("Sorted Array: " + string.Join(", ", array));
    }
}
