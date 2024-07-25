public class HashTable<TKey, TValue>
{
    private const int InitialCapacity = 16;
    private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;

    public HashTable()
    {
        this.buckets = new LinkedList<KeyValuePair<TKey, TValue>>[InitialCapacity];
        for (int i = 0; i < buckets.Length; i++)
        {
            buckets[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
        }
    }

    private int GetBucketIndex(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % this.buckets.Length;
    }

    public void Insert(TKey key, TValue value)
    {
        // compute the bucket index
        int bucketIndex = GetBucketIndex(key);
        LinkedList<KeyValuePair<TKey, TValue>> bucket = buckets[bucketIndex];

        foreach (var kvp in bucket)
        {
            // check to see if the bucket already exists
            if (kvp.Key.Equals(key))
            {
                // Key exists, update the value
                bucket.Remove(kvp);
                break;
            }
        }

        bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
    }


    public TValue Get(TKey key)
    {
        int bucketIndex = GetBucketIndex(key);
        LinkedList<KeyValuePair<TKey, TValue>> bucket = buckets[bucketIndex];

        foreach (var kvp in bucket)
        {
            if (kvp.Key.Equals(key))
            {
                return kvp.Value;
            }
        }

        throw new KeyNotFoundException("Key not found.");
    }

    public bool Remove(TKey key)
    {
        int bucketIndex = GetBucketIndex(key);
        LinkedList<KeyValuePair<TKey, TValue>> bucket = buckets[bucketIndex];

        foreach (var kvp in bucket)
        {
            if (kvp.Key.Equals(key))
            {
                bucket.Remove(kvp);
                return true;
            }
        }

        return false;
    }


}