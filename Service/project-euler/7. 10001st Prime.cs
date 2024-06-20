public class Euler7
{
    /*
        By listing the first six prime numbers 2, 3, 5, 6, 11, 13, we can see that the 6th prime is 13.

        What is the 10001st prime?


        Time Complexity is O(sqrt(n)) for prime checking, and O(n logn) for the iterations required.
    */

    public int FindNthPrime()
    {
        int n = 10001;

        if (n < 1)
        {
            throw new ArgumentException("n must be a positive integer.");
        }

        int count = 0;
        int num = 2;
        while (true)
        {
            if (IsPrime(num))
            {
                count++;
                if (count == n)
                {
                    return num;
                }
            }
            num++;
        }
    }


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