using System;
using System.Collections.Generic;
using System.Linq;

public class Euler23
{
    private const int Limit = 28123;

    public int SumOfNonAbundantSums()
    {
        var abundantNumbers = GetAbundantNumbers(Limit);
        var canBeWrittenAsAbundantSum = new bool[Limit + 1];

        for (int i = 0; i < abundantNumbers.Count; i++)
        {
            for (int j = i; j < abundantNumbers.Count; j++)
            {
                int sum = abundantNumbers[i] + abundantNumbers[j];
                if (sum <= Limit)
                {
                    canBeWrittenAsAbundantSum[sum] = true;
                }
                else
                {
                    break;
                }
            }
        }

        int sumOfNonAbundantSums = 0;
        for (int i = 1; i <= Limit; i++)
        {
            if (!canBeWrittenAsAbundantSum[i])
            {
                sumOfNonAbundantSums += i;
            }
        }

        return sumOfNonAbundantSums;
    }

    private List<int> GetAbundantNumbers(int limit)
    {
        var abundantNumbers = new List<int>();
        for (int i = 1; i <= limit; i++)
        {
            if (IsAbundant(i))
            {
                abundantNumbers.Add(i);
            }
        }
        return abundantNumbers;
    }

    private bool IsAbundant(int number)
    {
        return SumOfProperDivisors(number) > number;
    }

    private int SumOfProperDivisors(int number)
    {
        int sum = 1; // Start with 1 because 1 is a proper divisor for all numbers
        int sqrt = (int)Math.Sqrt(number);

        for (int i = 2; i <= sqrt; i++)
        {
            if (number % i == 0)
            {
                sum += i;
                if (i != number / i)
                {
                    sum += number / i;
                }
            }
        }

        return sum;
    }

    public static void Main(string[] args)
    {
        Euler23 euler = new Euler23();
        int result = euler.SumOfNonAbundantSums();
        Console.WriteLine($"Sum of all the positive integers which cannot be written as the sum of two abundant numbers: {result}");
    }
}
