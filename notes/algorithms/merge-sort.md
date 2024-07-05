### Merge Sort Algorithm

Merge sort is a divide-and-conquer algorithm that divides the input array into smaller subarrays, sorts them, and then merges them back together. It is an efficient, stable, and comparison-based sorting algorithm.

### Key Concepts

1. **Divide:** Split the array into two halves.
2. **Conquer:** Recursively sort each half.
3. **Combine:** Merge the two sorted halves back together.

### Steps to Implement Merge Sort

1. **Divide the Array:** Find the midpoint of the array and divide it into two halves.
2. **Recursive Sorting:** Recursively apply merge sort to both halves.
3. **Merge:** Merge the two sorted halves to produce the sorted array.

### Pseudocode

```text
mergeSort(array, left, right)
    if left < right
        middle = (left + right) / 2
        mergeSort(array, left, middle)
        mergeSort(array, middle + 1, right)
        merge(array, left, middle, right)

merge(array, left, middle, right)
    n1 = middle - left + 1
    n2 = right - middle
    create temporary arrays L[0..n1-1] and R[0..n2-1]
    for i = 0 to n1-1
        L[i] = array[left + i]
    for j = 0 to n2-1
        R[j] = array[middle + 1 + j]
    i = 0, j = 0, k = left
    while i < n1 and j < n2
        if L[i] <= R[j]
            array[k] = L[i]
            i++
        else
            array[k] = R[j]
            j++
        k++
    while i < n1
        array[k] = L[i]
        i++
        k++
    while j < n2
        array[k] = R[j]
        j++
        k++
```

### Time Complexity

- **Best Case:** O(n log n)
- **Average Case:** O(n log n)
- **Worst Case:** O(n log n)

### Space Complexity

- **Space Complexity:** O(n) - Additional space is required for temporary arrays used in merging.

### Implementation in C#

Here is a C# implementation of the merge sort algorithm:

```csharp
using System;

class MergeSort
{
    public static void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            // Recursively sort the first and second halves
            Sort(arr, left, middle);
            Sort(arr, middle + 1, right);

            // Merge the sorted halves
            Merge(arr, left, middle, right);
        }
    }

    private static void Merge(int[] arr, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        // Create temporary arrays
        int[] L = new int[n1];
        int[] R = new int[n2];

        // Copy data to temporary arrays L[] and R[]
        for (int i = 0; i < n1; i++)
            L[i] = arr[left + i];
        for (int j = 0; j < n2; j++)
            R[j] = arr[middle + 1 + j];

        // Merge the temporary arrays back into arr[left..right]
        int iIndex = 0, jIndex = 0;
        int k = left;

        while (iIndex < n1 && jIndex < n2)
        {
            if (L[iIndex] <= R[jIndex])
            {
                arr[k] = L[iIndex];
                iIndex++;
            }
            else
            {
                arr[k] = R[jIndex];
                jIndex++;
            }
            k++;
        }

        // Copy any remaining elements of L[]
        while (iIndex < n1)
        {
            arr[k] = L[iIndex];
            iIndex++;
            k++;
        }

        // Copy any remaining elements of R[]
        while (jIndex < n2)
        {
            arr[k] = R[jIndex];
            jIndex++;
            k++;
        }
    }

    static void Main(string[] args)
    {
        int[] arr = { 38, 27, 43, 3, 9, 82, 10 };
        Console.WriteLine("Unsorted array:");
        Console.WriteLine(string.Join(", ", arr));

        Sort(arr, 0, arr.Length - 1);

        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(", ", arr));
    }
}
```

### Explanation

1. **Divide the Array:** The `Sort` method is called recursively to divide the array into two halves until each subarray has only one element.
2. **Merge:** The `Merge` method is used to merge the two sorted halves back together. Temporary arrays `L` and `R` are created to hold the values of the two halves.
3. **Comparison and Merging:** Elements from `L` and `R` are compared and merged back into the original array `arr` in sorted order.

### Tips for Interview

- **Understand the Algorithm:** Ensure you understand the divide-and-conquer approach and the merging process.
- **Complexity Analysis:** Be prepared to discuss the time and space complexity of merge sort.
- **Edge Cases:** Consider edge cases such as an empty array or an array with one element.
- **Recursion:** Explain the role of recursion in the algorithm.

Merge sort is a foundational algorithm for understanding more complex sorting techniques and is often used in practical applications due to its predictable time complexity and stable sorting properties.

Let's step through an example of merge sort using the array `[38, 27, 43, 3, 9, 82, 10]`.

### Initial Array
```
[38, 27, 43, 3, 9, 82, 10]
```

### Step-by-Step Process

1. **Divide the Array:**
   - The array is divided into two halves.

```
Left:  [38, 27, 43, 3]
Right: [9, 82, 10]
```

2. **Divide Again:**
   - Each half is recursively divided until each subarray contains a single element.

```
Left:  [38, 27, 43, 3]       ->   [38, 27]   and   [43, 3]
Right: [9, 82, 10]           ->   [9, 82]    and   [10]

Left-Left:  [38, 27]         ->   [38]   and   [27]
Left-Right: [43, 3]          ->   [43]   and   [3]

Right-Left: [9, 82]          ->   [9]    and   [82]
Right-Right: [10]            ->   [10]
```

3. **Merge:**
   - Start merging subarrays in sorted order.

**Left Side Merging:**

```
Merge [38] and [27] -> [27, 38]
Merge [43] and [3]  -> [3, 43]
Merge [27, 38] and [3, 43] -> [3, 27, 38, 43]
```

**Right Side Merging:**

```
Merge [9] and [82]  -> [9, 82]
Merge [9, 82] and [10] -> [9, 10, 82]
```

4. **Final Merge:**
   - Merge the two sorted halves.

```
Merge [3, 27, 38, 43] and [9, 10, 82]

1. Compare 3 and 9. 3 is smaller, add to the merged array: [3]
2. Compare 27 and 9. 9 is smaller, add to the merged array: [3, 9]
3. Compare 27 and 10. 10 is smaller, add to the merged array: [3, 9, 10]
4. Compare 27 and 82. 27 is smaller, add to the merged array: [3, 9, 10, 27]
5. Compare 38 and 82. 38 is smaller, add to the merged array: [3, 9, 10, 27, 38]
6. Compare 43 and 82. 43 is smaller, add to the merged array: [3, 9, 10, 27, 38, 43]
7. Add remaining element 82 to the merged array: [3, 9, 10, 27, 38, 43, 82]
```

### Sorted Array
```
[3, 9, 10, 27, 38, 43, 82]
```

### Detailed Explanation

#### Initial Call

1. **Initial Array:**
   - `arr = [38, 27, 43, 3, 9, 82, 10]`
   - `left = 0`, `right = 6`
   - `middle = 3`

#### First Level of Recursion

2. **Divide:**
   - Left Subarray: `arr = [38, 27, 43, 3]`, `left = 0`, `right = 3`
   - Right Subarray: `arr = [9, 82, 10]`, `left = 4`, `right = 6`

#### Second Level of Recursion

3. **Divide Left Subarray:**
   - Left Subarray: `arr = [38, 27]`, `left = 0`, `right = 1`
   - Right Subarray: `arr = [43, 3]`, `left = 2`, `right = 3`

4. **Divide Right Subarray:**
   - Left Subarray: `arr = [9, 82]`, `left = 4`, `right = 5`
   - Right Subarray: `arr = [10]`, `left = 6`, `right = 6`

#### Third Level of Recursion

5. **Divide Further:**
   - `arr = [38]`, `left = 0`, `right = 0`
   - `arr = [27]`, `left = 1`, `right = 1`
   - `arr = [43]`, `left = 2`, `right = 2`
   - `arr = [3]`, `left = 3`, `right = 3`
   - `arr = [9]`, `left = 4`, `right = 4`
   - `arr = [82]`, `left = 5`, `right = 5`

#### Merging

6. **Merge Small Subarrays:**
   - Merge `[38]` and `[27]` -> `[27, 38]`
   - Merge `[43]` and `[3]` -> `[3, 43]`
   - Merge `[9]` and `[82]` -> `[9, 82]`

7. **Merge Larger Subarrays:**
   - Merge `[27, 38]` and `[3, 43]` -> `[3, 27, 38, 43]`
   - Merge `[9, 82]` and `[10]` -> `[9, 10, 82]`

8. **Final Merge:**
   - Merge `[3, 27, 38, 43]` and `[9, 10, 82]` -> `[3, 9, 10, 27, 38, 43, 82]`

### Final Result
```
[3, 9, 10, 27, 38, 43, 82]
```

This example demonstrates the divide-and-conquer approach of merge sort, breaking the array into smaller parts and merging them back in sorted order.