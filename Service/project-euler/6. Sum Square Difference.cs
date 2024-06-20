public class Euler6{
    /*
        The sum of squares of the first ten natural numbers is 1^2 + 2^2 + 2^2 + ... + 10 ^ 2 = 385.

        The square of the sum of the first ten natural numbers is (1 + 2 + 3 + ... + 10)^2 = 55 ^2 = 3025.

        The difference between the sum of squares and the squares of the sum is 3025 - 385 = 2640.

        Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.



        
    */

    public int SumSquareDifferences(){
        int n = 100;

        return SquareOfSum(n) - SumOfSquares(n);

    }

    // public int sumOfSquares(int n){
    //     var sum = 0;

    //     for(int i = 1; i <= n; i++){
    //         sum += (int)Math.Pow(i, 2);
    //     }

    //     return sum;

    // }

    // public int squareOfSum(int n){
    //     var sum = 0;

    //     for(int i = 1; i <= n; i++){
    //         sum += i;
    //     }

    //     return (int)Math.Pow(sum,2);
    // }


    /* 
        Opportunity for Optimization.

        Use Mathematical properties of sum of squares instead of looping. We can go from O(n) instead to O(1).
    */

    public int SumOfSquares(int n)
    {
        // Using the formula for the sum of squares of the first n natural numbers
        return (n * (n + 1) * (2 * n + 1)) / 6;
    }

    public int SquareOfSum(int n)
    {
        // Using the formula for the sum of the first n natural numbers
        int sum = (n * (n + 1)) / 2;
        return sum * sum;
    }
}