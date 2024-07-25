using System;
using System.Collections.Generic;

public class SimpleHashSet<T>
{
    private const int InitialCapacity = 16;
    private LinkedList<T>[] buckets;
    private int count;

    public SimpleHashSet(int capacity = InitialCapacity)
    {
        buckets = new LinkedList<T>[capacity];
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new LinkedList<T>();
        }
    }

    private int GetBucketIndex(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        return item.GetHashCode() % buckets.Length;
    }

    public bool Add(T item)
    {
        int bucketIndex = GetBucketIndex(item);
        LinkedList<T> bucket = buckets[bucketIndex];
        
        // Check if item already exists
        foreach (var element in bucket)
        {
            if (element.Equals(item))
            {
                return false; // Item already exists
            }
        }
        
        // Add item to the bucket
        bucket.AddLast(item);
        count++;
        return true;
    }

    public bool Contains(T item)
    {
        int bucketIndex = GetBucketIndex(item);
        LinkedList<T> bucket = buckets[bucketIndex];
        
        foreach (var element in bucket)
        {
            if (element.Equals(item))
            {
                return true; // Item found
            }
        }
        
        return false; // Item not found
    }

    public bool Remove(T item)
    {
        int bucketIndex = GetBucketIndex(item);
        LinkedList<T> bucket = buckets[bucketIndex];
        
        var node = bucket.First;
        while (node != null)
        {
            if (node.Value.Equals(item))
            {
                bucket.Remove(node);
                count--;
                return true; // Item removed
            }
            node = node.Next;
        }
        
        return false; // Item not found
    }

    public int Count => count;

    public void Clear()
    {
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i].Clear();
  
