using System;
using System.Collections.Generic;

public class BucketSort
{
    public static void Sort(float[] array)
    {
        if (array.Length == 0)
            return;

        int numberOfBuckets = array.Length;
        List<float>[] buckets = new List<float>[numberOfBuckets];

        // Initialize buckets
        for (int i = 0; i < numberOfBuckets; i++)
        {
            buckets[i] = new List<float>();
        }

        // Distribute input array values into buckets
        foreach (float value in array)
        {
            int bucketIndex = (int)(value * numberOfBuckets);
            buckets[bucketIndex].Add(value);
        }

        // Sort each bucket and concatenate results
        int index = 0;
        foreach (var bucket in buckets)
        {
            bucket.Sort();
            foreach (var value in bucket)
            {
                array[index++] = value;
            }
        }
    }

    public static void Main(string[] args)
    {
        float[] array = { 0.897f, 0.565f, 0.656f, 0.1234f, 0.665f, 0.3434f };
        Console.WriteLine("Original Array: " + string.Join(", ", array));
        
        Sort(array);
        
        Console.WriteLine("Sorted Array: " + string.Join(", ", array));
    }
}
