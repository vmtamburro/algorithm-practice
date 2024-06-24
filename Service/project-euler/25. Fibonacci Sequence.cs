using System;
using System.Numerics;

public class Euler25
{
    public int FindFibonacciIndexWithDigits(int digits = 1000)
    {
        BigInteger first = 1;
        BigInteger second = 1;
        int index = 2;


        // written as a while instead of the recursive approach
        // because it is inefficient for large repeated calculations
        while (second.ToString().Length < digits)
        {
            BigInteger temp = second;
            second = first + second;
            first = temp;
            index++;
        }

        return index;
    }

    public static void Main(string[] args)
    {
        Euler25 euler = new Euler25();
        int result = euler.FindFibonacciIndexWithDigits(1000);
        Console.WriteLine($"The index of the first term in the Fibonacci sequence to contain 1000 digits is: {result}");
    }
}
