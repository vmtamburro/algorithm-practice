using System;

public class Euler3a
{
    public bool IsPrime(int n)
    {
        // Prime numbers are defined as natural numbers greater than 1.
        if (n <= 1)
        {
            return false;
        }

        // 2 is the smallest and only even prime number.
        if (n == 2)
        {
            return true;
        }

        // If the number is even, it's not prime because it can be divided by two
        if (n % 2 == 0)
        {
            return false;
        }

        // Check for divisors from 3 up to sqrt(n)
        // Any divisors other than 1 and n will be less than or equal to sqrt(n)
        int limit = (int)Math.Sqrt(n);
        for (int i = 3; i <= limit; i += 2)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
