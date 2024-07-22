using System;
using System.Collections.Generic;

public class HashTableChaining
{
    private LinkedList<KeyValuePair<string, int>>[] table;
    private int size;

    public HashTableChaining(int size)
    {
        this.size = size;
        table = new LinkedList<KeyValuePair<string, int>>[size];
        for (int i = 0; i < size; i++)
        {
            table[i] = new LinkedList<KeyValuePair<string, int>>();
        }
    }

    private int GetHash(string key)
    {
        return Math.Abs(key.GetHashCode()) % size;
    }

    public void Insert(string key, int value)
    {
        int index = GetHash(key);
        foreach (var pair in table[index])
        {
            if (pair.Key == key)
            {
                // Update the value if key already exists
                table[index].Remove(pair);
                table[index].AddLast(new KeyValuePair<string, int>(key, value));
                return;
            }
        }
        // Key does not exist, add new key-value pair
        table[index].AddLast(new KeyValuePair<string, int>(key, value));
    }

    public int? Get(string key)
    {
        int index = GetHash(key);
        foreach (var pair in table[index])
        {
            if (pair.Key == key)
            {
                return pair.Value;
            }
        }
        return null; // Key not found
    }

    public void Delete(string key)
    {
        int index = GetHash(key);
        var node = table[index].First;
        while (node != null)
        {
            if (node.Value.Key == key)
            {
                table[index].Remove(node);
                return;
            }
            node = node.Next;
        }
    }
}

