public class Euler16{
    /*
        2^15 = 32768 and the sum of its digits is 
        3 + 2 + 7 + 8 = 26

        What is the sum of the digits of the number 2^100? 
    */

    public int PowerDigitSum(int bs = 2, int pow = 10000){
        int sum = 0;
        var powerCharArray = Math.Pow(bs, pow).ToString().ToCharArray();
        foreach(var c in powerCharArray){
            sum += (int)Char.GetNumericValue(c); 
        }

        return sum;
    }
}