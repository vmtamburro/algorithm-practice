using System;
using System.Collections.Generic;

public class RadixSort
{
    public static void Sort(int[] array)
    {
        if (array.Length == 0)
            return;

        int maxNumber = FindMaxNumber(array);
        int numberOfDigits = CalculateNumberOfDigits(maxNumber);

        for (int digit = 0; digit < numberOfDigits; digit++)
        {
            array = CountingSortByDigit(array, digit);
        }
    }

    private static int FindMaxNumber(int[] array)
    {
        // Assume array has at least one element
        int maxNumber = array[0];

        // Find the maximum number in the array
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxNumber)
                maxNumber = array[i];
        }
        return maxNumber;
    }

    private static int CalculateNumberOfDigits(int number)
    {
        int digits = 0;
        while (number > 0)
        {
            digits++;
            number /= 10; // Remove the last digit
        }
        return digits;
    }

    private static int[] CountingSortByDigit(int[] array, int digit)
    {
        int[] sortedArray = new int[array.Length];
        int[] count = new int[10]; // create an array to store the count of each digit

        int divisor = (int)Math.Pow(10, digit); // calculate the divisor to extract the digit
        
        // Counting occurrences of digits
        foreach (int number in array)
        {
            int digitValue = (number / divisor) % 10; // extract the digit
            count[digitValue]++;// increment the count of the digit
        }

        // Calculate cumulative count
        for (int i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        // Place numbers into sorted order
        for (int i = array.Length - 1; i >= 0; i--)
        {
            int number = array[i];
            int digitValue = (number / divisor) % 10;
            sortedArray[count[digitValue] - 1] = number;
            count[digitValue]--;
        }

        return sortedArray;
    }

    public static void Main(string[] args)
    {
        int[] array = { 170, 45, 75, 90, 802, 24, 2, 66 };
        Console.WriteLine("Original Array: " + string.Join(", ", array));
        
        Sort(array);
        
        Console.WriteLine("Sorted Array: " + string.Join(", ", array));
    }
}
