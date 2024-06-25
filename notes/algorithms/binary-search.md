### Notes on Binary Search Algorithm in C#

#### Introduction

- **Binary Search** is an efficient algorithm for finding an item from a sorted list of items.
- It works by repeatedly dividing in half the portion of the list that could contain the item, until you've narrowed down the possible locations to just one.

#### Requirements

- The list or array must be sorted before performing a binary search.

#### How Binary Search Works

1. **Initial Setup**: Set the lower (`left`) and upper (`right`) bounds of the search to the first and last indices of the array.
2. **Calculate Middle**: Find the middle element of the current bounds.
3. **Comparison**:
   - If the middle element is equal to the target, the search is complete.
   - If the target is less than the middle element, adjust the upper bound to `mid - 1`.
   - If the target is greater than the middle element, adjust the lower bound to `mid + 1`.
4. **Repeat**: Continue the process until the bounds overlap.

#### Time Complexity

- **O(log n)**, where `n` is the number of elements in the array. This is because the search area is halved with each step.

#### Implementation in C#

##### Iterative Approach

```csharp
public int BinarySearch(int[] array, int target)
{
    int left = 0;
    int right = array.Length - 1;

    while (left <= right)
    {
        int mid = left + (right - left) / 2; // Avoids overflow

        if (array[mid] == target)
            return mid;
        else if (array[mid] < target)
            left = mid + 1;
        else
            right = mid - 1;
    }

    return -1; // Element not found
}
```

##### Recursive Approach

```csharp
public int BinarySearchRecursive(int[] array, int target, int left, int right)
{
    if (left > right)
        return -1; // Element not found

    int mid = left + (right - left) / 2; // Avoids overflow

    if (array[mid] == target)
        return mid;
    else if (array[mid] < target)
        return BinarySearchRecursive(array, target, mid + 1, right);
    else
        return BinarySearchRecursive(array, target, left, mid - 1);
}
```

##### Example Usage

```csharp
public class BinarySearchExample
{
    public static void Main()
    {
        int[] sortedArray = { 1, 3, 5, 7, 9, 11, 13, 15 };
        int target = 7;

        // Using iterative approach
        int index = BinarySearch(sortedArray, target);
        Console.WriteLine(index); // Output: 3

        // Using recursive approach
        index = BinarySearchRecursive(sortedArray, target, 0, sortedArray.Length - 1);
        Console.WriteLine(index); // Output: 3
    }

    public static int BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Avoids overflow

            if (array[mid] == target)
                return mid;
            else if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1; // Element not found
    }

    public static int BinarySearchRecursive(int[] array, int target, int left, int right)
    {
        if (left > right)
            return -1; // Element not found

        int mid = left + (right - left) / 2; // Avoids overflow

        if (array[mid] == target)
            return mid;
        else if (array[mid] < target)
            return BinarySearchRecursive(array, target, mid + 1, right);
        else
            return BinarySearchRecursive(array, target, left, mid - 1);
    }
}
```

#### Summary

- Binary Search is a powerful technique for finding elements in a sorted array efficiently.
- It reduces the search space by half with each step, leading to a time complexity of O(log n).
- It can be implemented both iteratively and recursively.
