public class Euler1
{
    /* 
        If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6, and 9. The sum of these multiples is 23.

        Find the sum of all the multiples of 3 or 5 below 1000.
    */

    public void MultiplesOf3Or5()
    {
        int sum = 0;

        for (var i = 0; i < 1000; i++)
        {
            // ex i =  10
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }

        Console.WriteLine(sum);
    }


    /* 
        Improvements:
            - Remove Magic Num
            - Instead oof O(N) iterating over the entire set, you could use a formula to compute the sum directly. This could reduce time complexity to O(1)

            int sum = SumDivisibleBy(3) + SumDivisibleBy(5) - SumDivisibleBy(15);

            int SumDivisibleBy(int n)
            {
                int p = (limit - 1) / n;
                return n * p * (p + 1) / 2;
            }

    */
}