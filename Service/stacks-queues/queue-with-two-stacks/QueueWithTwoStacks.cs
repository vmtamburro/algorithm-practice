using System;
using System.Collections.Generic;

public class QueueUsingStacks<T>
{
    private Stack<T> _stack1;
    private Stack<T> _stack2;

    public QueueUsingStacks()
    {
        _stack1 = new Stack<T>();
        _stack2 = new Stack<T>();
    }

    public void Enqueue(T item)
    {
        _stack1.Push(item);
    }

    public T Dequeue()
    {
        if (_stack2.Count == 0)
        {
            // Move elements from stack1 to stack2
            while (_stack1.Count > 0)
            {
                _stack2.Push(_stack1.Pop());
            }
        }

        if (_stack2.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        return _stack2.Pop();
    }

    public bool IsEmpty => _stack1.Count == 0 && _stack2.Count == 0;
}
