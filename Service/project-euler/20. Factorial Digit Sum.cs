using System.Numerics;
using System.Security.Cryptography.X509Certificates;

public class Euler20{
    /*
        n! means n × (n − 1) × ... × 3 × 2 × 1

        For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
        and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.

        Find the sum of the digits in the number 100!
    */

    public int FactorialDigitSum(int n = 100){
        BigInteger factorial = CalculateFactorial(n);
        
        int sumOfDigits = SumDigits(factorial);
        return sumOfDigits;
    }

    public BigInteger CalculateFactorial(int n){
        BigInteger factorial = 1;
        for(int i = 2; i <= n; i++){
            factorial *= i;
        }
        return factorial;
    }

    private int SumDigits(BigInteger number){
        string numberStr = number.ToString();
        int sum = 0;
        foreach(char c in numberStr){
            sum += (int)Char.GetNumericValue(c);
        }
        return sum;
    }
}