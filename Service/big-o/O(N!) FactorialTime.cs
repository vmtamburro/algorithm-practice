using System;
using System.Collections.Generic;

public class FactorialTime
{
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
