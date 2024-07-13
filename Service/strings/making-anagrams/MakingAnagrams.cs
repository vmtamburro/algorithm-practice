using System;
using System.Collections.Generic;

public class MakingAnagrams {
    public static void Main(string[] args) {
        // Read input strings
        string a = Console.ReadLine();
        string b = Console.ReadLine();

        // Call function to compute minimum deletions
        int result = makeAnagram(a, b);

        // Print the result
        Console.WriteLine(result);
    }

    /*
        * Function to compute the minimum number of deletions required to make two strings anagrams
        * a: The first string
        * b: The second string
        * Returns the minimum number of deletions needed
    */
    public static int makeAnagram(string a, string b) {
        // Initialize arrays to count occurrences of each character ('a' to 'z')
        int[] countA = new int[26];
        int[] countB = new int[26];

        // Populate character counts for string a
        foreach (char c in a) {
            countA[c - 'a']++;
        }

        // Populate character counts for string b
        foreach (char c in b) {
            countB[c - 'a']++;
        }

        // Calculate the number of deletions required
        int deletions = 0;
        for (int i = 0; i < 26; i++) {
            deletions += Math.Abs(countA[i] - countB[i]); // Add the difference in counts
        }

        return deletions;
    }
}
