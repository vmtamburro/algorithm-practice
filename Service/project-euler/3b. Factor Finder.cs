using System;
using System.Collections.Generic;

public class Euler3b
{
    public List<long> GetAllFactors(long n)
    {
        List<long> factors = new List<long>();

        // Check for divisors up to the square root of n
        for (long i = 1; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                factors.Add(i);
                if (i != n / i) // Avoid adding the square root twice for perfect squares
                {
                    factors.Add(n / i);
                }
            }
        }

        factors.Sort(); // Sorting the factors in ascending order
        return factors;
    }
}
