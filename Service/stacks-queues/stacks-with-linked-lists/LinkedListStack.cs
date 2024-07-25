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
