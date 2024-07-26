public class RandomPractice_Arrays
{
    public void AccessingElements()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        int element = array[2];
        Console.WriteLine(element);
    }

    public void Insertion()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        int[] newArray = new int[array.Length + 1];
        int indexToInsert = 2;

        Array.Copy(array, newArray, indexToInsert);
        newArray[indexToInsert] = 10;

        Array.Copy(array, indexToInsert, newArray, indexToInsert + 1, array.Length - indexToInsert);
        Console.WriteLine(string.Join(", ", newArray));
    }

    public void Deletion()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        int indexToDelete = 2;
        int[] newArray = new int[array.Length - 1];

        // Copy elements before the deletion point
        Array.Copy(array, newArray, indexToDelete);

        // Copy elements after the deletion point
        Array.Copy(array, indexToDelete + 1, newArray, indexToDelete, array.Length - indexToDelete - 1);

        Console.WriteLine(string.Join(", ", newArray)); // Output: 1, 2, 4, 5
    }

    public void DynamicArrays()
    {
        List<int> dynamicArray = new List<int> { 1, 2, 3, 4, 5 };

        // Access
        int element = dynamicArray[2]; // Access the element at index 2
        Console.WriteLine(element); // Output: 3

        // Insertion
        dynamicArray.Insert(2, 6);
        Console.WriteLine(string.Join(", ", dynamicArray)); // Output: 1, 2, 6, 3, 4, 5

        // Deletion
        dynamicArray.RemoveAt(2);
        Console.WriteLine(string.Join(", ", dynamicArray)); // Output: 1, 2, 3, 4, 5

        // Resizing (handled automatically by List<T>)
        dynamicArray.Add(7); // Adding an element beyond the initial capacity
        Console.WriteLine(string.Join(", ", dynamicArray)); // Output: 1, 2, 3, 4, 5, 7
    
    }
}