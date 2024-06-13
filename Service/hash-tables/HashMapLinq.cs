using System;
using System.Collections.Generic;
using System.Linq;

public class HashMap<TKey, TValue>
{
    private readonly List<LinkedList<KeyValuePair<TKey, TValue>>> items;
    private readonly int capacity;

    public HashMap(int capacity = 10)
    {
        this.capacity = capacity;
        items = Enumerable.Range(0, capacity)
            .Select(x => new LinkedList<KeyValuePair<TKey, TValue>>()).ToList();
    }

    private int GetArrayIndex(TKey key)
    {
        int hashCode = key.GetHashCode();
        return Math.Abs(hashCode % capacity);
    }

    public void Add(TKey key, TValue value)
    {
        int index = GetArrayIndex(key);
        if (items[index].Any(item => item.Key.Equals(key)))
        {
            throw new ArgumentException("An item with the same key already exists.");
        }

        items[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
    }
    public TValue Get(TKey key)
    {
        int index = GetArrayIndex(key);
        var item = items[index].FirstOrDefault(x => x.Key.Equals(key));
        if (item.Equals(default(KeyValuePair<TKey, TValue>)))
        {
            throw new KeyNotFoundException("Key not found.");
        }
        return item.Value;
    }

    public void Remove(TKey key)
    {
        int index = GetArrayIndex(key);
        var item = items[index].FirstOrDefault(x => x.Key.Equals(key));
        if (item.Equals(default(KeyValuePair<TKey, TValue>)))
        {
            throw new KeyNotFoundException("Key not found.");
        }
        items[index].Remove(item);
    }

}