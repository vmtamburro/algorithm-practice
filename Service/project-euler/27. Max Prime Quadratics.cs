using System.Runtime.CompilerServices;

public class Euler27{
    /*
        Find the product of coefficients a and b for the quadratic expression
        n^2 + an + b that produces the maximum number of priems for consecutive
        values of n starting with n = 0;

        - Function to check if a number is prime
        - Maximize number of primes for consecutive values of n
        - Keep track of the (a, b) pair that produces the max number of primes
    */

    public (int a, int b) CheckMaxConsecutivePrime(int limit = 1000){
        int a = 0; int b = 0;
        var maxConsecutivePrimes = 0;
        for(var i = 0; i < limit; i++){
            for(var j = 0; j < limit; j++){
                int n = 0;
                while(IsPrime(n * n + i * n + j)){
                    n++;
                }

                if(n > maxConsecutivePrimes){
                    maxConsecutivePrimes = n;
                    a = i;
                    b = j;
                }
            }

        }

        return (a, b);
    }


    public bool IsPrime(int number){
        if(number < 2) return false;
        if(number == 2) return true;
        if(number % 2 == 0) return false;
        
        for(var i = 3; i < (int)Math.Sqrt(number); i+= 2){
            if(number % i == 0) return false;
        }

        return true;
    }
}