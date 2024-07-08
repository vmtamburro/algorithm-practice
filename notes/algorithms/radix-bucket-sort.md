Radix sort and bucket sort are two distinct sorting algorithms, although they are related in that both are designed for particular types of data distributions and have linear time complexities under specific conditions.

### Radix Sort:

**Definition**: Radix sort is a non-comparative sorting algorithm that sorts numbers by processing individual digits. It sorts numbers digit by digit from the least significant digit (LSD) to the most significant digit (MSD). Radix sort can be performed in two ways: LSD (Least Significant Digit) and MSD (Most Significant Digit).

**Example**: Let's consider an example of sorting an array of integers using LSD radix sort:

1. **Input Array**: `[170, 45, 75, 90, 802, 24, 2, 66]`

2. **Step-by-Step Process**:
   - **First Pass (Sort by Ones Digit)**:
     - Create 10 buckets (0-9).
     - Place each number into its respective bucket based on the least significant digit.
     - Combine all buckets into a new array.
     - Result after first pass: `[170, 90, 802, 2, 24, 45, 75, 66]`
   
   - **Second Pass (Sort by Tens Digit)**:
     - Repeat the process for the tens digit.
     - Result after second pass: `[802, 2, 24, 45, 66, 170, 75, 90]`
   
   - **Third Pass (Sort by Hundreds Digit)**:
     - Since none of the numbers have a hundreds digit, they remain sorted.
     - Final sorted array: `[2, 24, 45, 66, 75, 90, 170, 802]`

**Complexity**: Radix sort has a time complexity of \(O(d * (n + k))\), where \(n\) is the number of elements, \(k\) is the range of the numbers (0 to 9 for digits), and \(d\) is the number of digits in the longest number. When \(k\) is relatively small (like digits, which is 10), radix sort can be very efficient.

### Bucket Sort:

**Definition**: Bucket sort is a sorting algorithm that divides the input into a number of buckets. Each bucket is then sorted individually, typically with another sorting algorithm or recursively with bucket sort itself, and then the sorted buckets are merged to produce a sorted output.

**Example**: Sorting an array of floating-point numbers using bucket sort:

1. **Input Array**: `[0.42, 0.32, 0.33, 0.52, 0.37, 0.47, 0.51]`

2. **Step-by-Step Process**:
   - **Bucket Creation**: Divide the range of the input (0 to 1 in this case) into 5 equal-sized buckets.
   - **Insertion into Buckets**: Place each element into its corresponding bucket based on its value.
   - **Sorting Each Bucket**: Sort each bucket (using another sorting algorithm like insertion sort or recursively with bucket sort).
   - **Merging Buckets**: Concatenate all sorted buckets to get the final sorted array.

**Complexity**: Bucket sort has a time complexity of \(O(n + k)\), where \(n\) is the number of elements and \(k\) is the number of buckets. The performance of bucket sort depends heavily on the distribution of the input elements into the buckets.

### Key Differences:

- **Usage**: Radix sort is typically used for sorting integers by digit, while bucket sort is often used for sorting uniformly distributed data.
- **Complexity**: Radix sort's time complexity depends on the number of digits, whereas bucket sort's complexity depends on the number of buckets and the distribution of data.
- **Stability**: Radix sort is stable (preserves the relative order of records with equal keys), whereas bucket sort can be stable if the underlying sorting algorithm used within each bucket is stable.

Both radix sort and bucket sort are efficient under specific conditions and can be adapted based on the type and distribution of data to be sorted.


Sure, here's an example of radix sort and bucket sort implemented in C#:

### Radix Sort Example in C#

```csharp
using System;
using System.Collections.Generic;

public class RadixSortExample
{
    public static void RadixSort(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return;

        // Find the maximum number to know the number of digits
        int max = FindMax(arr);

        // Perform counting sort for every digit, starting from the least significant digit (LSD)
        for (int exp = 1; max / exp > 0; exp *= 10)
        {
            CountingSort(arr, exp);
        }
    }

    private static int FindMax(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }
        return max;
    }

    private static void CountingSort(int[] arr, int exp)
    {
        int[] output = new int[arr.Length];
        int[] count = new int[10]; // 0 to 9 digits

        // Count occurrences of each digit in count array
        foreach (int num in arr)
        {
            count[(num / exp) % 10]++;
        }

        // Adjust count[i] to now contain actual position of this digit in output[]
        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        // Build the output array
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            output[count[(arr[i] / exp) % 10] - 1] = arr[i];
            count[(arr[i] / exp) % 10]--;
        }

        // Copy the output array to arr[], so that arr[] now contains sorted numbers according to current digit
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = output[i];
        }
    }

    public static void Main(string[] args)
    {
        int[] arr = { 170, 45, 75, 90, 802, 24, 2, 66 };

        Console.WriteLine("Original Array:");
        PrintArray(arr);

        RadixSort(arr);

        Console.WriteLine("\nSorted Array:");
        PrintArray(arr);
    }

    private static void PrintArray(int[] arr)
    {
        foreach (var num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
```

### Bucket Sort Example in C#

```csharp
using System;
using System.Collections.Generic;

public class BucketSortExample
{
    public static void BucketSort(float[] arr)
    {
        if (arr == null || arr.Length <= 1)
            return;

        int n = arr.Length;
        List<float>[] buckets = new List<float>[n];

        // Initialize buckets
        for (int i = 0; i < n; i++)
        {
            buckets[i] = new List<float>();
        }

        // Add elements to buckets
        foreach (float num in arr)
        {
            int bucketIndex = (int)(num * n);
            buckets[bucketIndex].Add(num);
        }

        // Sort each bucket (using insertion sort here)
        for (int i = 0; i < n; i++)
        {
            InsertionSort(buckets[i]);
        }

        // Concatenate all buckets into arr[]
        int index = 0;
        for (int i = 0; i < n; i++)
        {
            foreach (float num in buckets[i])
            {
                arr[index++] = num;
            }
        }
    }

    private static void InsertionSort(List<float> bucket)
    {
        for (int i = 1; i < bucket.Count; i++)
        {
            float key = bucket[i];
            int j = i - 1;
            while (j >= 0 && bucket[j] > key)
            {
                bucket[j + 1] = bucket[j];
                j--;
            }
            bucket[j + 1] = key;
        }
    }

    public static void Main(string[] args)
    {
        float[] arr = { 0.42f, 0.32f, 0.33f, 0.52f, 0.37f, 0.47f, 0.51f };

        Console.WriteLine("Original Array:");
        PrintArray(arr);

        BucketSort(arr);

        Console.WriteLine("\nSorted Array:");
        PrintArray(arr);
    }

    private static void PrintArray(float[] arr)
    {
        foreach (var num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
```

### Explanation:

- **Radix Sort**: This implementation sorts an array of integers by processing digits from the least significant digit (LSD) to the most significant digit (MSD) using counting sort as a subroutine.

- **Bucket Sort**: This implementation sorts an array of floating-point numbers by dividing the range into buckets and then sorting each bucket individually. It uses insertion sort to sort each bucket.

Both algorithms are efficient for their respective use cases, and they illustrate different approaches to sorting based on the nature of the data being sorted.