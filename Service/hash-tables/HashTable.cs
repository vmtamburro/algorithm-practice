using System;
using System.Collections.Generic;

public class HashTable<TKey, TValue>
{
    private const int DefaultCapacity = 10;
    private LinkedList<KeyValuePair<TKey, TValue>>[] items;


    public HashTable()
    {
        items = new LinkedList<KeyValuePair<TKey, TValue>>[DefaultCapacity];
    }

    public HashTable(int capacity)
    {
        items = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
    }


    /// <summary>
    /// Generate a hash code of the provided key which represents the key.
    /// Calculate an index within the bounds of the internal array.
    /// Handle Negative Hash Codes
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    private int GetArrayIndex(TKey key)
    {
        int hashCode = key.GetHashCode();
        int index = hashCode % items.Length;
        return Math.Abs(index);
    }


    public void Add(TKey key, TValue value)
    {
        int index = GetArrayIndex(key);
        if (items[index] == null)
        {
            items[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
        }

        foreach (var item in items[index])
        {
            if (item.Key.Equals(key))
            {
                throw new ArgumentException("An item with the same key already exists.");
            }
        }

        items[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
    }

    public void Remove(TKey key)
    {
        int index = GetArrayIndex(key);
        if (items[index] == null)
        {
            throw new KeyNotFoundException("Key not found.");
        }

        LinkedListNode<KeyValuePair<TKey, TValue>> current = items[index].First;
        while (current != null)
        {
            if (current.Value.Key.Equals(key))
            {
                items[index].Remove(current);
                return;
            }
            current = current.Next;
        }

        throw new KeyNotFoundException("Key not found.");
    }
    public TValue Get(TKey key)
    {
        int index = GetArrayIndex(key);
        if (items[index] == null)
        {
            throw new KeyNotFoundException("Key not found.");
        }

        foreach (var item in items[index])
        {
            if (item.Key.Equals(key))
            {
                return item.Value;
            }
        }

        throw new KeyNotFoundException("Key not found.");
    }
}


