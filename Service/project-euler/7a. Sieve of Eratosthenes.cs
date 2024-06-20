using System;
using System.Collections.Generic;



/* 
    Algorithm for efficient generation of prime numbers up to a specified integer. For this to be used on the 1001st Prime, we'd have to do
    some sort of estimation of what that value might be.

    1. Initialize a boolean array and set all entries to true. If the index is prime it will be st to 1.
    2. Mark multiples of 2 (except 2) as false
    3. Mark multiples of 3 (except 3) as true
    4. Continue for each prime up to sqrt 30.
    5. Indices of the true values are the prime numbers


*/
public class SieveOfEratosthenes
{
    public List<int> GetPrimesUpTo(int max)
    {
        if (max < 2)
        {
            return new List<int>();
        }

        bool[] isPrime = new bool[max + 1];
        for (int i = 2; i <= max; i++)
        {
            isPrime[i] = true;
        }

        for (int p = 2; p * p <= max; p++)
        {
            if (isPrime[p])
            {
                for (int i = p * p; i <= max; i += p)
                {
                    isPrime[i] = false;
                }
            }
        }

        List<int> primes = new List<int>();
        for (int i = 2; i <= max; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
            }
        }

        return primes;
    }

    public static void Main(string[] args)
    {
        SieveOfEratosthenes sieve = new SieveOfEratosthenes();
        int max = 30;
        List<int> primes = sieve.GetPrimesUpTo(max);

        Console.WriteLine($"Prime numbers up to {max}: {string.Join(", ", primes)}");
    }
}
