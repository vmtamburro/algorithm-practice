using System;
using System.Collections.Generic;
using System.Linq;

public class MinBribes
{

    /*
     * Complete the 'minimumBribes' function below.
     *
     * The function accepts INTEGER_ARRAY q as parameter.
     */

    public static void minimumBribes(List<int> q)
    {
        var bribeCount = 0;
        var highestNum = q.Count;


        while (highestNum > 0)
        {
            var originalIndex = highestNum - 1;
            var actualIndex = q.IndexOf(highestNum);
            if (actualIndex != originalIndex)
            {
                int bribesPerPerson = Math.Abs(originalIndex - actualIndex);
                for (var j = 0; j < bribesPerPerson; j++)
                {
                    Swap(ref q, actualIndex + j, actualIndex + j + 1);
                }

                bribeCount += bribesPerPerson;

                if (bribesPerPerson > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
            }
            highestNum--;
        }

        Console.WriteLine(bribeCount);
    }

    public static void Swap(ref List<int> arr, int a, int b)
    {

        var temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }

}
