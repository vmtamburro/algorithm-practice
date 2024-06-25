# Heaps and Priority Queues in C#

1. Intro to Heaps

A heap is a specialized tree-based data structure that satisfies the heap property. There are two types of heaps:
- Min-heap: Key at the root is the minimum among all the keys in the heap.
- Max-heap: Key at the root is the maximum among all keys in the heap.

Heap Properties:
- Heaps are complete binary trees, meaning all levels are fully filled except possibly for the last level which is filled from left to right.
-In a max-heap, each parent node is greater than or equal to its children.
- In a min-heap, each parent node is less than or equal to its children.

2. Priority Queues

A priority queue is an abstract data type similar to a regular queue or stack data structure, but where each element has a priority associated with it. Ina  priority queue, an element with high priority is served before an element with low priority.

Priority queues can be efficiently implemented using heaps.

3. Implementing Heaps in C#

The .NET framework does not have a built-in heap implementation, but we can implement one using arrays or lists.

```cs
public class MinHeap
{
    private List<int> _elements = new List<int>();

    public int GetSize()
    {
        return _elements.Count;
    }

    public bool IsEmpty()
    {
        return _elements.Count == 0;
    }

    public int Peek()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Heap is empty");
        return _elements[0];
    }

    public void Add(int element)
    {
        _elements.Add(element);
        HeapifyUp(_elements.Count - 1);
    }

    public int RemoveMin()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Heap is empty");

        int min = _elements[0];
        _elements[0] = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);

        HeapifyDown(0);
        return min;
    }


    // takes in an index of an element that needs to be moved up
    // to maintain the heap property
    private void HeapifyUp(int index)
    {
        // root of the heap is at the index 0, no need to heapify up further than the root
        while (index > 0)
        {
            // calculate the index of the parent node
            int parentIndex = (index - 1) / 2;

            // check if the current element is greater than or equal to the parent - if so we've satisfied the heap property.
            if (_elements[index] >= _elements[parentIndex])
                break;

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        // loop continues as long as the current index
        // is not a leaf node.
        while (index < _elements.Count / 2)
        {
            // get the left node
            int leftChildIndex = 2 * index + 1;
            // get the right node
            int rightChildIndex = 2 * index + 2;
            // assume the left is smaller
            int smallerChildIndex = leftChildIndex;


            // if right exists, and its smaller than the left, update the smaller index
            if (rightChildIndex < _elements.Count && _elements[rightChildIndex] < _elements[leftChildIndex])
            {
                smallerChildIndex = rightChildIndex;
            }

            // if current element is in the correct position, exit
            if (_elements[index] <= _elements[smallerChildIndex])
                break;


            //swap the current element with the smaller child to maintain the min heap property
            Swap(index, smallerChildIndex);

            // Update the index to the smaller child's index
            index = smallerChildIndex;
        }
    }

    private void Swap(int index1, int index2)
    {
        int temp = _elements[index1];
        _elements[index1] = _elements[index2];
        _elements[index2] = temp;
    }
}
```

4. Using the MinHeap Class

Here is how you can use the `MinHeap` class in your application:

```cs
public class Program
{
    public static void Main()
    {
        MinHeap minHeap = new MinHeap();
        minHeap.Add(10);
        minHeap.Add(4);
        minHeap.Add(15);
        minHeap.Add(20);
        minHeap.Add(0);

        Console.WriteLine("Min element: " + minHeap.Peek()); // Output: 0
        Console.WriteLine("Removed Min element: " + minHeap.RemoveMin()); // Output: 0
        Console.WriteLine("New Min element: " + minHeap.Peek()); // Output: 4
    }
}
```

5. Priority Queue Implementation

A priority queue can be implemented using the heap. Here is a simple example:

```cs
public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> _elements = new List<T>();

    public int GetSize()
    {
        return _elements.Count;
    }

    public bool IsEmpty()
    {
        return _elements.Count == 0;
    }

    public T Peek()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Priority queue is empty");
        return _elements[0];
    }

    public void Enqueue(T element)
    {
        _elements.Add(element);
        HeapifyUp(_elements.Count - 1);
    }

    public T Dequeue()
    {
        if (_elements.Count == 0)
            throw new InvalidOperationException("Priority queue is empty");

        T min = _elements[0];
        _elements[0] = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);

        HeapifyDown(0);
        return min;
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (_elements[index].CompareTo(_elements[parentIndex]) >= 0)
                break;

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        while (index < _elements.Count / 2)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallerChildIndex = leftChildIndex;

            if (rightChildIndex < _elements.Count && _elements[rightChildIndex].CompareTo(_elements[leftChildIndex]) < 0)
            {
                smallerChildIndex = rightChildIndex;
            }

            if (_elements[index].CompareTo(_elements[smallerChildIndex]) <= 0)
                break;

            Swap(index, smallerChildIndex);
            index = smallerChildIndex;
        }
    }

    private void Swap(int index1, int index2)
    {
        T temp = _elements[index1];
        _elements[index1] = _elements[index2];
        _elements[index2] = temp;
    }
}
```

6. Using the PriorityQueue class


Here is how you can use the `PriorityQueue` class

```cs
public class Program
{
    public static void Main()
    {
        PriorityQueue<int> pq = new PriorityQueue<int>();
        pq.Enqueue(10);
        pq.Enqueue(4);
        pq.Enqueue(15);
        pq.Enqueue(20);
        pq.Enqueue(0);

        Console.WriteLine("Min element: " + pq.Peek()); // Output: 0
        Console.WriteLine("Removed Min element: " + pq.Dequeue()); // Output: 0
        Console.WriteLine("New Min element: " + pq.Peek()); // Output: 4
    }
}

```