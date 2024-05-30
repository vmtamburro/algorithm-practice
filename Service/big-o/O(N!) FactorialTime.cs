using System;
using System.Collections.Generic;

public class FactorialTime
{

    /// <summary>
    /// Base Case - if it's empty, return a list containing an empty list.
    /// Recursive case - for each element, generate all permutations of the remaining elements. 
    /// Add to list of all permutations.
    /// 
    /// Permutations have a Factorial Time Complexity O(n!)
    /// </summary>
    /// <param name="list"></param>
    /// <param name="k"></param>
    /// <param name="m"></param>
    public void GeneratePermutations(List<int> list, int k, int m)
    {
        if (k == m)
        {
            foreach (int item in list)
                Console.Write(item + " ");
            Console.WriteLine();
        }
        else
        {
            for (int i = k; i <= m; i++)
            {
                Swap(list, k, i);
                GeneratePermutations(list, k + 1, m);
                Swap(list, k, i); // backtrack
            }
        }
    }
    
    private void Swap(List<int> list, int i, int j)
    {
        int temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
