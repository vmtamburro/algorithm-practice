### Notes on Queues in C#

#### Introduction

- **Queues** are a collection of elements with a First In, First Out (FIFO) access pattern.
- In C#, the `Queue<T>` class, defined in the `System.Collections.Generic` namespace, is used to implement queues.

#### Creating a Queue

- **Declaration**:
  ```csharp
  Queue<int> queue = new Queue<int>();
  ```

- **Initialization with Values**:
  ```csharp
  Queue<int> queue = new Queue<int>(new int[] { 1, 2, 3, 4, 5 });
  ```

#### Adding Elements

- **Using `Enqueue` Method**:
  ```csharp
  queue.Enqueue(6);
  ```

#### Removing Elements

- **Using `Dequeue` Method**:
  ```csharp
  int frontElement = queue.Dequeue(); // Removes and returns the front element
  ```

#### Viewing the Front Element

- **Using `Peek` Method**:
  ```csharp
  int frontElement = queue.Peek(); // Returns the front element without removing it
  ```

#### Checking for Elements

- **Using `Contains` Method**:
  ```csharp
  bool containsThree = queue.Contains(3);
  ```

#### Checking the Number of Elements

- **Using `Count` Property**:
  ```csharp
  int count = queue.Count;
  ```

#### Iterating Over a Queue

- **Using `foreach` Loop**:
  ```csharp
  foreach (var item in queue)
  {
      Console.WriteLine(item);
  }
  ```

#### Clearing a Queue

- **Using `Clear` Method**:
  ```csharp
  queue.Clear();
  ```

#### Example Usage

```csharp
public class QueueExample
{
    public static void Main()
    {
        // Creating a queue
        Queue<int> queue = new Queue<int>();

        // Enqueuing elements onto the queue
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        // Viewing the front element
        Console.WriteLine("Front element: " + queue.Peek()); // Output: Front element: 3

        // Dequeuing elements from the queue
        Console.WriteLine("Dequeued element: " + queue.Dequeue()); // Output: Dequeued element: 1
        Console.WriteLine("Dequeued element: " + queue.Dequeue()); // Output: Dequeued element: 2

        // Checking the number of elements
        Console.WriteLine("Queue count: " + queue.Count); // Output: Queue count: 1

        // Iterating over the queue
        queue.Enqueue(4);
        queue.Enqueue(5);
        foreach (var item in queue)
        {
            Console.WriteLine(item);
        }
        // Output:
        // 3
        // 4
        // 5

        // Clearing the queue
        queue.Clear();
        Console.WriteLine("Queue count after clearing: " + queue.Count); // Output: Queue count after clearing: 0
    }
}
```

#### Summary

- Queues are useful for scenarios where you need FIFO access to elements.
- Key operations include `Enqueue`, `Dequeue`, and `Peek`.
- The `Queue<T>` class in C# provides a simple and efficient way to implement queue behavior.
