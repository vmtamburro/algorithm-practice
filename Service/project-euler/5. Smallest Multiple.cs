public class Euler5{
    /*
        2520 is the smallest number that can be divided by each of the numbers
        1-10 without any remainder.

        What is the smallest number that is evenly divisible by all of the numbers from 1-20?
    
        1. Start at lower limit Least Common Multiple
        2. Check divisibility
        3. Increment by the highest number in range (20)  


        Solution is O(n log n) because w loop through iterating numbers, and the GCD calculation is logarithmic  
    */

    public int SmallestMultiple(){
        int lcm = 1; // Initialize to 1 because LCM with 0 is always technically 0.
        for(var i = 1; i <= 20; i++)
        {
            lcm = LCM(lcm, i);
        }
        return lcm;
    }



    /*
        Calculates least common multiple of two different integers
    */
    public int LCM(int a, int b){
        return (a  * b) / GCD(a, b);
    }

    /*
        Euclidean algorithm. Calculates the Greatest Common Divisor.
    */
    public int GCD(int a, int b){
        while(b != 0){
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}