public class RandomPractice_Arrays{
    public void AccessingElements(){
        int[] array = {1, 2, 3, 4, 5};
        int element = array[2];
        Console.WriteLine(element);
    }

    public void Insertion(){
        int[] array = {1, 2, 3, 4, 5};
        int[] newArray = new int[array.Length + 1];
        int indexToInsert = 2;

        Array.Copy(array, newArray, indexToInsert);
        newArray[indexToInsert] = 10;

        Array.Copy(array, indexToInsert, newArray, indexToInsert + 1, array.Length - indexToInsert);
        Console.WriteLine(string.Join(", ", newArray));
    }

    public void Deletion(){

    }

    public void DynamicArrays(){

    }
}