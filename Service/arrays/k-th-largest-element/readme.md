_How would you find the "kth" largest element in an unsorted array"_

## Brute Force
  - Sort the array, and then pull out the kth element from the end.
  - Depending on the sort method, this could be kind of rough.
  - Merge Sort is O(n log(n)) which would probably be the best case scenario

## Optimize using a Min Heap
 - Use a min-heap (priority queue) to find the kth largest element in `O(n log(k))`
 - Iterate through the array and maintain the size of the heap to k
 - If the heap size exceeds k, remove the smallest element
 - Building the heap is `O(k)`
 - For each of he remaining elements, maintaining the heap size k takes `O(log k)`
 - Overall the time complexity is O(n, log(k))

## Comparison
- Brute force approach is Simple and straightforward but less efficient for large arrays due to O(n logn) time complexity
- Min-Heap Approach: More efficient with O(n log k) time complexity. Especially useful when k is much smaller than n.