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


    public static void minimumBribesAlternate(List<int> q)
    {
        int bribeCount = 0;
        bool chaotic = false;

        for (int i = 0; i < q.Count; i++)
        {
            if (q[i] - (i + 1) > 2) // if the value is greater than it's intended position by 2, it's chaotic. Exit early
            {
                chaotic = true;
                break;
            }

            for (int j = Math.Max(0, q[i] - 2); j < i; j++)
            {
                if (q[j] > q[i])
                {
                    bribeCount++;
                }
            }
        }

        if (chaotic)
        {
            Console.WriteLine("Too chaotic");
        }
        else
        {
            Console.WriteLine(bribeCount);
        }
    }

}
