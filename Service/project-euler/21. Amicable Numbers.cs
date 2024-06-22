public class Euler21{
    /*
        Amicable numbers are pairs of numbers where each number is the sum of the proper divisors 
        of the other. Proper divisors of a number are those numbers less than the number 
        itself which divide it evenly.
    */

 public int SumOfAmicableNumbers(int limit)
    {
        int sum = 0;

        for (int a = 1; a < limit; a++)
        {
            int b = SumOfProperDivisors(a);
            if (b > a && b < limit && SumOfProperDivisors(b) == a)
            {
                sum += a + b;
            }
        }

        return sum;
    }

    private int SumOfProperDivisors(int n)
    {
        if (n <= 1)
            return 0;

        int sum = 1; // Start with 1 because 1 is a divisor for all numbers except itself
        int sqrtN = (int)Math.Sqrt(n);
        
        for (int i = 2; i <= sqrtN; i++)
        {
            if (n % i == 0)
            {
                sum += i;
                if (i != n / i) // Add the pair divisor if it's not the square root
                    sum += n / i;
            }
        }

        return sum;
    }

    public static void Main(string[] args)
    {
        Euler21 euler = new Euler21();
        int limit = 10000;
        int sumOfAmicableNumbers = euler.SumOfAmicableNumbers(limit);
        Console.WriteLine($"Sum of all amicable numbers under {limit}: {sumOfAmicableNumbers}");
    }
}
