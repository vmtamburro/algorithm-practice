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
            for(int i = 0; i < size; i++)
            {
                table[i] = new List<KeyValuePair<TKey, TValue>>();
            }
        }

        public int GetIndex(TKey key){
            return Math.Abs(key.GetHashCode()) % size;
        }

        public void Insert(TKey key, TValue value){
            int index = GetIndex(key);
            var bucket = table[index];
            foreach(var pair in bucket){
                if(pair.Key.Equals(key)){
                    bucket.Remove(pair);
                    break;
                }
            }

            bucket.Add(new KeyValuePair<TKey, TValue>(key, value));
        }


        public bool Delete(TKey key){
            int index = GetIndex(key);
            var bucket = table[index];
            foreach(var pair in bucket){
                if(pair.Key.Equals(key)){
                    bucket.Remove(pair);
                    return true;
                }
            }

            return false;
        }

        public TValue Search(TKey key){
            int index = GetIndex(key);
            var bucket = table[index];
            foreach(var pair in bucket){
                if(pair.Key.Equals(key)){
                    return pair.Value;
                }
            }

            throw new InvalidOperationException("Key not found");
        }


    }
}