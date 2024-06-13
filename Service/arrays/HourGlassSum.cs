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

public class HourGlassSum
{

    private static List<List<int>> HOUR_GLASS_INDEXES = new List<List<int>>{
            new List<int>{0, 0},
            new List<int>{0, 1},
            new List<int>{0, 2},
            new List<int>{1, 1},
            new List<int>{2, 0},
            new List<int>{2, 1},
            new List<int>{2, 2}
        };

    private static int HOUR_GLASS_MAX = 3;

    /*
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int hourglassSum()
    {
        // Define the sample 2D list (List of Lists)
        List<List<int>> arr = new List<List<int>>
        {
            new List<int>{ 1, 1, 1, 0, 0, 0 },
            new List<int>{ 0, 1, 0, 0, 0, 0 },
            new List<int>{ 1, 1, 1, 0, 0, 0 },
            new List<int>{ 0, 0, 2, 4, 4, 0 },
            new List<int>{ 0, 0, 0, 2, 0, 0 },
            new List<int>{ 0, 0, 1, 2, 4, 0 }
        };

        List<int> hourGlassSums = new List<int>();


        for (int i = 0; i < arr.Count; i++)
        {
            for (int j = 0; j < arr[i].Count; j++)
            {
                int currentSum = 0;
                if (HourglassWithinRange(arr, i, j))
                {
                    foreach (var index in HOUR_GLASS_INDEXES)
                    {
                        currentSum += arr[i + index[0]][j + index[1]];
                    }
                    hourGlassSums.Add(currentSum);
                }
            }
        }

        return hourGlassSums.Max();

    }

    private static bool HourglassWithinRange(List<List<int>> arr, int i, int j)
    {
        return i + HOUR_GLASS_MAX <= arr.Count && j + HOUR_GLASS_MAX <= arr[i].Count;
    }
}
