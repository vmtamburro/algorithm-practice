public class Euler10{
    /* 
        The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

        Find the Sum of all primes below Two Million.


        Use the Sieve of Eratosthenes.

    */

    public int SumOfPrimes(int num){
        num = 2000000;
        return GetPrimesUpTo(num).Sum();
    }

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

}