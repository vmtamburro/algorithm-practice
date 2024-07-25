using System;

public class ArrayStack<T>
{
    private T[] _array;
    private int _size;
    private const int InitialCapacity = 4;

    public ArrayStack(int capacity = InitialCapacity)
    {
        _array = new T[capacity];
        _size = 0;
    }

    public void Push(T item)
    {
        if (_size == _array.Length)
        {
            Resize();
        }
        _array[_size++] = item;
    }

    public T Pop()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        T item = _array[--_size];
        _array[_size] = default; // Clear the reference
        return item;
    }

    public T Peek()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return _array[_size - 1];
    }

    public bool IsEmpty => _size == 0;

    private void Resize()
    {
        int newCapacity = _array.Length * 2;
        T[] newArray = new T[newCapacity];
        Array.Copy(_array, newArray, _size);
        _array = newArray;
    }
}
