public class Euler3{
    /* 
        The prime factors of 13195 are 5, 17, 13, and 29.

        What's the largest prime factor of the number 600851475143
    */

   public long SumPrimeFactors(long n)
    {

        n =  600851475143;
        long sum = 0;

        // Check for divisibility by 2 (the only even prime factor)
        while (n % 2 == 0)
        {
            sum += 2;
            n /= 2;
        }

        // Check for divisibility by odd numbers starting from 3
        for (long i = 3; i <= Math.Sqrt(n); i += 2)
        {
            while (n % i == 0)
            {
                sum += i;
                n /= i;
            }
        }

        // If n is a prime number greater than 2
        if (n > 2)
        {
            sum += n;
        }

        return sum;
    }

}