public class HashTableExample
{
    public HashTable<string, int> hashTable = new HashTable<string, int>();


    public void Test(){
        AddElements();
        RetrieveElements();
        Remove();
    }
    public void AddElements()
    {
        hashTable.Add("John", 25);
        hashTable.Add("Alice", 30);
        hashTable.Add("Bob", 35);
        hashTable.Add("Victoria", 35);
    }

    public void RetrieveElements()
    {
        Console.WriteLine("Age of John: " + hashTable.Get("John"));
        Console.WriteLine("Age of Alice: " + hashTable.Get("Alice"));
        Console.WriteLine("Age of Bob: " + hashTable.Get("Bob"));
    }

    public void Remove()
    {
        // Removing an element from the hash table
        hashTable.Remove("Alice");

        // Trying to retrieve the removed element
        try
        {
            Console.WriteLine("Age of Alice after removal: " + hashTable.Get("Alice"));
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}