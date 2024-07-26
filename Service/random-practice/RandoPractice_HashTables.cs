using System;
using System.Collections.Generic;

public class RandoPractice_HashTables
{
    public class HashTable_Chaining<TKey, TValue>
    {

        private List<KeyValuePair<TKey, TValue>>[] table;
        private int size;

        public HashTable_Chaining(int size)
        {
            table = new List<KeyValuePair<TKey, TValue>>[size];
            this.size = size;
            for (int i = 0; i < size; i++)
            {
                table[i] = new List<KeyValuePair<TKey, TValue>>();
            }
        }

        public int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }

        public void Insert(TKey key, TValue value)
        {
            int index = GetIndex(key);
            var bucket = table[index];
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    bucket.Remove(pair);
                    break;
                }
            }

            bucket.Add(new KeyValuePair<TKey, TValue>(key, value));
        }


        public bool Delete(TKey key)
        {
            int index = GetIndex(key);
            var bucket = table[index];
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    bucket.Remove(pair);
                    return true;
                }
            }

            return false;
        }

        public TValue Search(TKey key)
        {
            int index = GetIndex(key);
            var bucket = table[index];
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }

            throw new InvalidOperationException("Key not found");
        }


    }

    public class HashTable_OpenAddressing<TKey, TValue>
    {
        private (TKey, TValue)[] table;
        private int size;
        private int count;
        public HashTable_OpenAddressing(int size)
        {
            table = new (TKey, TValue)[size];
            this.size = size;
            count = 0;
        }
        private int GetIndex(TKey key, int attempt)
        {
            int hash = Math.Abs(key.GetHashCode());
            return (hash + attempt) % size;
        }

        public void Insert(TKey key, TValue value)
        {
            if (count >= size * 0.7)
            {
                throw new InvalidOperationException("Table is full");
            }

            int attempt = 0;
            int index = GetIndex(key, attempt);

            while (true)
            {
                index = GetIndex(key, attempt);
                if (table[index] == (null, null) || table[index].Item1.Equals(key))
                {
                    table[index] = (key, value);
                    count++;
                    return;
                }
                attempt++;
            }
        }

        public bool Delete(TKey key)
        {
            int attempt = 0;
            int index;

            while (true)
            {
                index = GetIndex(key, attempt);
                if (table[index] == (null, null))
                {
                    return false;
                }
                if (table[index].Item1.Equals(key))
                {
                    table[index] = (default(TKey), default(TValue));
                    count--;
                    return true;
                }
                attempt++;
            }
        }


        public TValue Lookup(TKey key)
        {
            int attempt = 0;
            int index;
            while (true)
            {
                index = GetIndex(key, attempt);
                if (table[index] == (null, null))
                {
                    throw new KeyNotFoundException("Key not found");
                }
                if (table[index].Item1.Equals(key))
                {
                    return table[index].Item2;
                }
                attempt++;
            }

        }
    }
}