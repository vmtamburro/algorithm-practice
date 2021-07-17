# Hoare's vs Lomuto partition scheme in Quick Sort


## Quick Sort

Quick Sort is a Divide and Conquer algorithm.
    - Picks an element as a pivot and partitions the given array around the picked pivot.
    - Many different versions of quickSort that pick pivot in different ways.
        - Always pick the first element as pivot
        - Always pick the last elemtn as pivot
        - Pick a random element as pivot
        - Pick a median as pivot

Key process is the partition(). The target is given an array and put all smaller elements before x and put all greater elements after x. All of this should be done in linear time.


```
/* low  --> Starting index,  high  --> Ending index */
quickSort(arr[], low, high)
{
    if (low < high)
    {
        /* pi is partitioning index, arr[pi] is now
           at right place */
        pi = partition(arr, low, high);

        quickSort(arr, low, pi - 1);  // Before pi
        quickSort(arr, pi + 1, high); // After pi
    }
}
```


Partition Algorithm
- CLRS book type aprtition.
    - start from the left most element
    - Keep track of an index smaller than or equal to elements as i
    - When traversing if we find a smaller element, we swap current element with arr[i] otherwise we ignore the current element

```
/* This function takes last element as pivot, places
   the pivot element at its correct position in sorted
    array, and places all smaller (smaller than pivot)
   to left of pivot and all greater elements to right
   of pivot */
partition (arr[], low, high)
{
    // pivot (Element to be placed at right position)
    pivot = arr[high];  
 
    i = (low - 1)  // Index of smaller element and indicates the 
                   // right position of pivot found so far

    for (j = low; j <= high- 1; j++)
    {
        // If current element is smaller than the pivot
        if (arr[j] < pivot)
        {
            i++;    // increment index of smaller element
            swap arr[i] and arr[j]
        }
    }
    swap arr[i + 1] and arr[high])
    return (i + 1)
}
```

Lomuto's Partition Scheme - performance is inferior to Hoare's QuickSort

```
partition(arr[], lo, hi) 
    pivot = arr[hi]
    i = lo     // place for swapping
    for j := lo to hi – 1 do
        if arr[j] <= pivot then
            swap arr[i] with arr[j]
            i = i + 1
    swap arr[i] with arr[hi]
    return i

```

# Hoare's Partition Scheme

Works by initializing two indexes that start at two ends. The two indexes move towared each other until an inversion is found. (A smaller value on the left and a greater value on the right) When the inversion is found, the process is repeated

```
partition(arr[], lo, hi)
   pivot = arr[lo]
   i = lo - 1  // Initialize left index
   j = hi + 1  // Initialize right index

   // Find a value in left side greater
   // than pivot
   do
      i = i + 1
   while arr[i] < pivot

   // Find a value in right side smaller
   // than pivot
   do
      j--;
   while (arr[j] > pivot);

   if i >= j then 
      return j

   swap arr[i] with arr[j]
```