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
        var runningList = new List<int>();
        foreach(var val in a){
            runningList.Add(val);
            returnList.Add(FindMedian(runningList, 0, runningList.Length - 1, (runningList.Length / 2)++));
        }
        return returnList;
    }

    public int FindMedian(List<int> a, int leftbound, int rightBound, int medianIndex){
        int index = Partition(a, leftBound, rightBound);

        if((index - leftBound) == medianIndex)
            return arr[index];
        
        if((index - leftBound) > (medianIndex - 1))
            return Findmedian(arr, leftBound, index - 1, medianIndex);
        
        return FindMedin(arr, index + 1, rightBound, (medianIndex - index + leftBound - 1));
        

    }

    public int Partition(List<int> a, int leftBound, int rightBound){

        var pivot = arr[rightBound];
        var indeOfPivot = leftBound;
        for(var j = leftBound; j <= rightBound - 1; j++){
            if(a[j] <= pivot){
                Swap(a, indexOfPivot, j);
                indexOfPivot++;
            }
        }
        Swap(a, indexOfPivot; rightBound);
        return indexOfPivot;
    }

    public void Swap(List<int> a, int index1, int index2){
        var temp = a[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
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
