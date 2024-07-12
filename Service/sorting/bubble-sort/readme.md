# Sorting: Bubble Sort

Consider the following version of Bubble Sort:

```python
for(int i = 0; i < n; i++){
    for(int j = 0; j < n -1; j++){
        // swap adjacent elements if they are in decreasing order
        if(a[j] > a[j + 1]){
            swap(a[j], a[j + 1]);
        }
    }
}
```

Given an array of integers, sort the array in ascending order using the Bubble Sort algorithm above. Once sorted, print the following three lines:

1. `Array is sorted in numSwaps swaps.` where `numSwaps` is the number of swaps that took place.
2. `First Element: firstElement` where `firstElement` is the first element in the sorted array.
3. `Last Element: lastElement` where `lastElement` is the last element in the sorted array.

### Input Format

- The first line contains an integer, `n`, the number of elements in the array `a`.
- The second line contains `n` space-separated integers describing the elements of the array `a`.

### Output Format

- Print the three lines as described above.

### Sample Input

```
3
3 2 1
```

### Sample Output

```
Array is sorted in 3 swaps.
First Element: 1
Last Element: 3
```

### Explanation

The array is sorted in `3` swaps:
1. Swap `3` and `2`, resulting in the array `[2, 3, 1]`.
2. Swap `3` and `1`, resulting in the array `[2, 1, 3]`.
3. Swap `2` and `1`, resulting in the array `[1, 2, 3]`.

The first element of the sorted array is `1`, and the last element is `3`.