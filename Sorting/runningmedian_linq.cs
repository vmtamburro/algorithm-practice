using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'runningMedian' function below.
     *
     * The function is expected to return a DOUBLE_ARRAY.
     * The function accepts INTEGER_ARRAY a as parameter.

     Currently this is timing out several of the test cases.
     */

    public static List<double> runningMedian(List<int> a)
    {
        var returnList = new List<double>();
        var sortedNumbers = new List<double>();
        foreach(var val in a){
            sortedNumbers.Add(val);
           sortedNumbers = sortedNumbers.OrderBy(x => x).ToList();
            
            var sortedNumbersCount = sortedNumbers.Count();
            
            if(sortedNumbersCount == 1){
              returnList.Add(val);   
            }
            else if(sortedNumbersCount % 2 == 0){
                int halfIndex = (sortedNumbersCount / 2);
                var firstMiddle = sortedNumbers[halfIndex - 1];
                var secondMiddle = sortedNumbers[halfIndex];
                
                returnList.Add((firstMiddle + secondMiddle) / 2);
                
            }else{
                double half = (sortedNumbersCount / 2);
                var middleIndex = Math.Ceiling(half);
                returnList.Add(sortedNumbers[(int)middleIndex]);
                
            }
        }
        
        return returnList;
    }



    public List<int> runningMedianDictionary(List<int> a){
        int lowCount = 0;
        int highCount = 0;
        List<double> returnList = new List<double>();
        SortedDictionary<int, int> lowNumbers = new SortedDictionary<int, int>();
        SortedDictionary<int, int> hightNumbers = new SortedDictionary<int, int>();

        foreach(var val in a){
            
        }


        return returnList;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int aCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = new List<int>();

        for (int i = 0; i < aCount; i++)
        {
            int aItem = Convert.ToInt32(Console.ReadLine().Trim());
            a.Add(aItem);
        }

        List<double> result = Result.runningMedian(a);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
