# Counting Inversions using Merge Sort

Given an array of integers, count the number of inversions needed to sort the array. An inversion is defined as a pair of indices (i, j) such that i < j and arr[i] > arr[j].

### Problem Description

You need to write a function that takes an array of integers and returns the number of inversions required to sort the array.

### Function Signature

```python
def countInversions(arr: List[int]) -> int:
    pass
```

### Input

- `arr`: A list of integers representing the array to be sorted.

### Output

Return an integer representing the number of inversions needed to sort the array.

### Constraints

- \(1 \leq n \leq 10^5\) (where `n` is the length of the array)
- \(1 \leq arr[i] \leq 10^9\)

### Example

#### Input

```
arr = [2, 4, 1, 3, 5]
```

#### Output

```
3
```

### Explanation

In the example above, the following pairs of indices are inversions:
1. (1, 2) -> arr[1] > arr[2] (4 > 1)
2. (1, 3) -> arr[1] > arr[3] (4 > 3)
3. (2, 3) -> arr[2] > arr[3] (1 > 3)

Hence, there are 3 inversions in the array.

### Solution Approach

The problem can be efficiently solved using a modified merge sort algorithm, which counts the inversions while sorting the array. The idea is to split the array into halves, recursively count the inversions in each half, and count the inversions across the halves during the merge step.