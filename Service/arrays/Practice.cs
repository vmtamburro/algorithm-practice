using System;
using System.Collections.Generic;
using System.Linq;

public class ArrayPractice
{

    /// <summary>
    /// Algorithm that determines if a string has all unique chars.
    /// What if you cannot use additional data structures?
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public bool IsUnique(string input)
    {
        // Convert to an array

        HashSet<char> seenChars = new HashSet<char>();

        foreach (char ch in input)
        {
            if (seenChars.Contains(ch))
            {
                return false;
            }

            seenChars.Add(ch);
        }

        return true;

        /* 
            Time Complexity is O(n) where n is the length of the input string
            Iterates through each char once, and the hash table lookup is a constant-time operation.
        */
    }


    /// <summary>
    /// Determine if one string is a permutation of another
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <returns></returns>
    public bool IsPermutation(string str1, string str2)
    {
        if (str1.Length != str2.Length) return false;

        char[] arr1 = str1.ToCharArray();
        char[] arr2 = str2.ToCharArray();

        Array.Sort(arr1);
        Array.Sort(arr2);

        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
            {
                return false;
            }
        }

        return true;

        /* 
            Time Complexity is O(n log n) due to the sorting step
        
            What Array.Sort does under the hood:
            For arrays with fewer than 16 elements: It uses a simple insertion sort algorithm. This algorithm is efficient for small arrays because it has low overhead.

            For arrays with 16 or more elements: It uses a modified version of Quicksort algorithm known as Introsort. Introsort combines the strengths of Quicksort, 
            Heapsort, and Insertion sort algorithms. It begins with Quicksort, but if the recursion depth exceeds a certain threshold, it switches to Heapsort to avoid 
            Quicksort's worst-case performance. Additionally, for small subarrays, it resorts to Insertion sort, which performs well on nearly sorted data.
        */
    }
}