### Bubble Sort Algorithm

Bubble sort is a simple comparison-based sorting algorithm. It repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order. This process is repeated until the list is sorted.

### Key Concepts

1. **Comparison:** Each pair of adjacent elements is compared.
2. **Swapping:** If the elements are in the wrong order, they are swapped.
3. **Passes:** The algorithm makes multiple passes through the list.
4. **Optimization:** The algorithm can be optimized by recognizing if no swaps are made during a pass, indicating the list is already sorted.

### Steps to Implement Bubble Sort

1. **Initialize:** Start at the beginning of the list.
2. **Compare and Swap:** Compare each pair of adjacent elements and swap them if necessary.
3. **Repeat:** Repeat the process for the entire list multiple times.
4. **Optimize:** Stop if no swaps are made in a pass.

### Pseudocode

```text
bubbleSort(array)
    n = length(array)
    for i = 0 to n-1
        swapped = false
        for j = 0 to n-i-2
            if array[j] > array[j+1]
                swap(array[j], array[j+1])
                swapped = true
        if not swapped
            break
```

### Time Complexity

- **Best Case:** O(n) - This occurs when the list is already sorted.
- **Average Case:** O(n^2) - Comparisons and swaps are performed for all elements.
- **Worst Case:** O(n^2) - This occurs when the list is sorted in reverse order.

### Space Complexity

- **Space Complexity:** O(1) - Bubble sort is an in-place sorting algorithm, meaning it requires a constant amount of additional space.

### Implementation in C#

Here is a C# implementation of the bubble sort algorithm:

```csharp
using System;

class BubbleSort
{
    public static void Sort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j + 1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }
            // If no elements were swapped, the array is sorted
            if (!swapped)
                break;
        }
    }

    static void Main(string[] args)
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine("Unsorted array:");
        Console.WriteLine(string.Join(", ", arr));

        Sort(arr);

        Console.WriteLine("Sorted array:");
        Console.WriteLine(string.Join(", ", arr));
    }
}
```

### Explanation

1. **Initialize:** The length of the array `n` is obtained.
2. **Outer Loop:** The outer loop runs from `0` to `n-1`.
3. **Inner Loop:** The inner loop runs from `0` to `n-i-2` to compare adjacent elements.
4. **Swapping:** If the element at `arr[j]` is greater than `arr[j+1]`, they are swapped.
5. **Optimization:** If no swaps are made in an entire pass, the array is considered sorted, and the algorithm breaks out of the loop.

### Tips for Interview

- **Understand the Algorithm:** Make sure you understand the basic steps of the bubble sort algorithm.
- **Edge Cases:** Consider edge cases such as an empty array or an array with one element.
- **Optimize:** Mention the optimization where the algorithm stops if no swaps are made in a pass.
- **Complexity Analysis:** Be prepared to discuss the time and space complexity of the algorithm.

Bubble sort is a good starting point for understanding basic sorting algorithms, though it is not efficient for large datasets compared to more advanced algorithms like quicksort or mergesort.