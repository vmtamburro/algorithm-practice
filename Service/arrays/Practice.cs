using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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


    /// <summary>
    /// Determine if a string is a permutation of a palindrome.
    /// EXAMPLE: tact coa
    /// OUTPUT: "taco cat", "atco cta"
    /// </summary>
    /// <param name="inputStr"></param>
    /// <returns></returns>
    public bool PalindromePermutation(string inputStr){

        char[] chars = inputStr.ToCharArray();
       List<string> permutationList = new List<string>();
       List<string> palindromeList = new List<string>();
       int k = 0; // starting index
       int m = chars.Length - 1; // ending index;

       GeneratePermutations(inputStr.ToCharArray(), k, m, permutationList);
        
        // If palindrome array is greater than 0, return true.
        foreach(var permutation in permutationList){
            var reverse = permutation.Reverse().ToString();
            if(reverse.ToLower() == permutation.ToLower()){
                palindromeList.Add(permutation);
            }
        }

        return palindromeList.Count() > 0;
    }

    public void GeneratePermutations(char[] inputStr, int k, int m, List<string> permutationList){
        if(k == m){
            permutationList.Add(inputStr.ToString());
        }
        
       for(var i = k; i <= m; i++){
            Swap(inputStr, k, i);
            GeneratePermutations(inputStr, k + 1, m, permutationList);
            Swap(inputStr, k, i);
       }
    }

    private void Swap(char[] charArray, int i, int j)
    {
        char temp = charArray[i];
        charArray[i] = charArray[j];
        charArray[j] = temp;
    }


    /*
        abc
        acb
        bca
        bac
        cba
        cab
        3 * 2 * 1 = 6 = 3!
    */


    /*
        The O(N!) is not an ideal time complexity. Instead, consider what is unique about a palindrome permutation.
        - Only one char can have an odd count
        - All other chars must have even counts
        - If this is the case, it's a palindrome permutation.
    */
    public bool PalindromePermutation_Counts(string inputStr){
        inputStr = inputStr.Replace(" ", "").ToLower(); // remove the whitespace and make it lowercase

        // Create a dictionary for char and frequency
        Dictionary<char, int> charCounts = new Dictionary<char, int>();
        foreach(char c in inputStr){
            if(charCounts.ContainsKey(c)){
                charCounts[c]++;
            }
            else{
                charCounts[c] = 1;
            }
        }

        int oddCount = 0;
        foreach(var count in charCounts.Values){
            if(count %2 != 0){
                oddCount++;
            }
        }

        return oddCount <= 1;
    }


    /*
        Three types of edits can be performed on strings
            - Insert
            - Remove
            - Replace
        - Given Two strings, write a function to check if they are one edit (or zero edits) away

        pale, ple -> true
        pales, pale -> false
        pale, bale -> true
        pale, bake -> false
    */
    public bool OneAway(string str1, string str2){
        str1 = str1.Replace(" ", "").ToLower();
        str2 = str2.Replace(" ", "").ToLower();

        if(str1 == str2) return false;
        var lengthDifference=  Math.Abs(str1.Length - str2.Length) ;

        if(lengthDifference > 1) return false;

        if(lengthDifference == 0){
            return CheckReplacement(str1, str2);
        }

        // If length difference is 1, check for insertion or deletion
        if (lengthDifference == 1)
        {
            // Ensure str1 is the shorter one
            if (str1.Length > str2.Length)
            {
                return CheckInsertionOrDeletion(str2, str1);
            }
            else
            {
                return CheckInsertionOrDeletion(str1, str2);
            }
        }

        return false; // default
      
    }

    private bool CheckInsertionOrDeletion(string shorter, string longer)
    {
        int index1 = 0, index2 = 0;

        while (index1 < shorter.Length && index2 < longer.Length)
        {
            if (shorter[index1] != longer[index2])
            {
                if (index1 != index2)
                {
                    return false; // More than one character is different
                }
                index2++; // Move the pointer of the longer string
            }
            else
            {
                index1++;
                index2++;
            }
        }

        return true; // Only one character was different
    }
    private bool CheckReplacement(string str1, string str2)
    {
        bool foundDifference = false;

        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i])
            {
                if (foundDifference)
                {
                    return false; // More than one character is different
                }
                foundDifference = true;
            }
        }

        return true; // Exactly one character is different
    }


    /* 
        String Compression
        Perform basic string compression using the counts of repeated characters.
        aabcccccaaa => a2b1c5a3.

        - If the compressed string is not smaller than the original string, your method should return the original string.
        - You can assume the string has only uppercase and lowercase letters

    */
    public string StringCompression(string str)
    {
        // Handle empty string
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        // Use StringBuilder for efficiency
        StringBuilder compressed = new StringBuilder();

        // Initialize variables
        char prevChar = str[0];
        int count = 1;

        // Iterate through the string starting from the second character
        for (int i = 1; i < str.Length; i++)
        {
            if (str[i] == prevChar)
            {
                count++;
            }
            else
            {
                compressed.Append(prevChar).Append(count);
                prevChar = str[i];
                count = 1;
            }
        }

        // Append the last set of character and count
        compressed.Append(prevChar).Append(count);

        string compressedStr = compressed.ToString();
        
        // Return the original string if the compressed string is not smaller
        return compressedStr.Length < str.Length ? compressedStr : str;
    }
}