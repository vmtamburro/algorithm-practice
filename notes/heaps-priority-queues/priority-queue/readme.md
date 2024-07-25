_How would you impelment a priority queue using a heap? What are the time complexities for insertion and extraction?_

## Background
A heap is a complete binary tree that satisfies the heap property
    * For a max heap, every parent node is greater than or qual to its children
    * For a min heap, every parent node is less than or equal to its children.

## Implementation
1. Initialiize the heap: Using a simple list or array
2. Insertion: Add the new element to the end of the list, and then "heapify up" to restore the heap property
3. Extraction: Remove the root element, move the last element to the root, and then "heapify down"

## Time Complexities
* **Insertion** O(log n) where `n` is the number of elements in the heap.
* **Extraction** O(log n) because after removing the root and placing the last element at the root, it may need to be moved down the height of the tree to restore the heap property.