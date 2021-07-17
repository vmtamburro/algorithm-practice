
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    private static int lowCount = 0; // number of values in the low half; for efficiency
    private static int highCount = 0; // number of values in the high half; for efficiency
    private static SortedDictionary<int, int> lowHalf = new SortedDictionary<int, int>(); // low half values
    private static SortedDictionary<int, int> highHalf = new SortedDictionary<int, int>(); // high half values
    
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());        
        int val;

        for (int i = 0; i < n; i++)
        {
            // read next value
            val = int.Parse(Console.ReadLine());
            
            // if the low values dictionary is empty, add value
            if (lowHalf.Count == 0)
            {
                lowHalf.Add(val, 1);
                lowCount++;
                PrintMedian();
                continue;
            }
            
            // if value is smaller or equal than the greatest low value, add to low values
            if (val <= lowHalf.Last().Key)
            {
                IncreaseCount(lowHalf, val);
                lowCount++;
                Rebalance();
                PrintMedian();
                continue;
            }
            
            // otherwise, add it to the high values dictionary
            IncreaseCount(highHalf, val);
            highCount++;
            Rebalance();
            PrintMedian();
        }
    }
    
    // adds or increases the count of a value in a dictionary
    static void IncreaseCount(SortedDictionary<int, int> dict, int val)
    {        
        if (!dict.ContainsKey(val))
        {
            dict.Add(val, 1);
            return;
        }
        
        dict[val]++;
    }
    
    // removes or decreases the count of a value in a dictionary
    static void DecreaseCount(SortedDictionary<int, int> dict, int val)
    {
        if (!dict.ContainsKey(val))
        {
            return;
        }
       
        dict[val]--;
        
        if (dict[val] == 0)
        {
            dict.Remove(val);
        }
    }
    
    static void Rebalance()
    {
       
       if (lowCount == highCount || lowCount == highCount + 1)
       {
           // low and high are balanced
           return;
       }
        
       int val = 0;
        
       if (lowCount == highCount + 2)
       {
           // we need to move one value from low to high
           val = lowHalf.Last().Key;
           
           DecreaseCount(lowHalf, val);
           lowCount--;
           
           IncreaseCount(highHalf, val);
           highCount++;
           
           return;
       }
        
       // we need to move one value from high to low
       val = highHalf.First().Key;
       
       DecreaseCount(highHalf, val);
       highCount--;
           
       IncreaseCount(lowHalf, val);
       lowCount++;     
    }
    
    static void PrintMedian()
    {
        double median;
        
        if (lowCount == highCount + 1)
        {
            // odd number of values; pick the one in the middle
            median = lowHalf.Last().Key;
            Console.WriteLine(median.ToString("F1"));
        }
        else
        {
            // even number of values; take the mean of the two middle values
            median = .5 * (lowHalf.Last().Key + highHalf.First().Key);
            Console.WriteLine(median.ToString("F1"));
        }              
    }
}