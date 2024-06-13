using System;
using System.Collections.Generic;
using System.Linq;

public class HourGlassSum
{
    private static List<List<int>> HourGlassIndexes = new List<List<int>>
    {
        new List<int>{0, 0},
        new List<int>{0, 1},
        new List<int>{0, 2},
        new List<int>{1, 1},
        new List<int>{2, 0},
        new List<int>{2, 1},
        new List<int>{2, 2}
    };

    private static int HourGlassMax = 3;

    public static int hourglassSum(List<List<int>> arr)
    {
        int maxSum = int.MinValue;

        for (int i = 0; i <= arr.Count - HourGlassMax; i++)
        {
            for (int j = 0; j <= arr[i].Count - HourGlassMax; j++)
            {
                int currentSum = 0;

                foreach (var index in HourGlassIndexes)
                {
                    currentSum += arr[i + index[0]][j + index[1]];
                }
                maxSum = Math.Max(maxSum, currentSum);

            }
        }

        return maxSum;
    }


}
