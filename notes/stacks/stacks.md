# Stacks

### Intro

- **Stacks** are a collection of elements with a LIFO access pattern
- `Stack<T>` in c# is built into the `System.Collections.Generic namespace.

#### Creating a Stack

- **Declaration**:
  ```csharp
  Stack<int> stack = new Stack<int>();
  ```

- Initialization with alues

```cs
Stack<int> stack = new Stack<int>(new int[] { 1, 2, 3, 4, 5 });

```

- Using a `Push` method

```cs
stack.Push(6);

```

- Removing Elements

```cs
int topElement = stack.Pop(); // Removes and returns the top element

int topElement = stack.Peek(); // Returns the top element without removing it

```

- Checking for elements

```cs
bool containsThree = stack.Contains(3);
int count = stack.Count;


```

- Iterating over a stack

```cs
foreach (var item in stack)
{
    Console.WriteLine(item);
}

```

- Clearing a stack

```cs
stack.Clear();

```