using System;

public class LinkedListStack<T>
{
    private Node _top;

    private class Node
    {
        public T Value;
        public Node Next;

        public Node(T value, Node next)
        {
            Value = value;
            Next = next;
        }
    }

    public void Push(T item)
    {
        _top = new Node(item, _top);
    }

    public T Pop()
    {
        if (_top == null)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        T value = _top.Value;
        _top = _top.Next;
        return value;
    }

    public T Peek()
    {
        if (_top == null)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return _top.Value;
    }

    public bool IsEmpty => _top == null;
}

public class Program
{
    public static void Main()
    {
        var stack = new LinkedListStack<int>();
        
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        
        Console.WriteLine(stack.Peek()); // Outputs: 3
        Console.WriteLine(stack.Pop());  // Outputs: 3
        Console.WriteLine(stack.Peek()); // Outputs: 2
        
        stack.Push(4);
        Console.WriteLine(stack.Pop());  // Outputs: 4
    }
}
