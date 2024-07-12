using System;

public class BubbleSort
{
    public static void BubbleSortArray(int[] arr)
    {
        int numSwaps = 0;
        int n = arr.Length;
        bool swapped;

        for (int i = 0; i < n; i++)
        {
            swapped = false;
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    Swap(arr, j, j + 1);
                    numSwaps++;
                    swapped = true;
                }
            }
            // If no elements were swapped, break early
            if (!swapped)
                break;
        }

        Console.WriteLine("Array is sorted in " + numSwaps + " swaps.");
        Console.WriteLine("First Element: " + arr[0]);
        Console.WriteLine("Last Element: " + arr[n - 1]);
    }

    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}

class Program
{
    static void Main()
    {
        int[] arr = { 3, 2, 1 };
        BubbleSort.BubbleSortArray(arr);
    }
}
