public class Euler5{
    /*
        2520 is the smallest number that can be divided by each of the numbers
        1-10 without any remainder.

        What is the smallest number that is evenly divisible by all of the numbers from 1-20?
    
        1. Start at lower limit Least Common Multiple
        2. Check divisibility
        3. Increment by the highest number in range (20)    
    */

    public int SmallestMultiple(){
        int lcm = 0;
        for(var i = 1; i <= 20; i++)
        {
            lcm = LCM(lcm, i);
        }
        return lcm;
    }

    public int LCM(int a, int b){
        return (a  * b) / GCD(a, b);
    }

    public int GCD(int a, int b){
        while(b != 0){
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}