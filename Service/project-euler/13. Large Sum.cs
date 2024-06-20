using System.Numerics;

public class Euler13
{

    /*
        We use BigInteger in C# to handle large integers, as the sum of one-hundred 50-digit numbers can result in a number larger than what int or long can store.
    */
    public string FindFirstTenDigitsOfSum(string[] numbers)
    {
        // Initialize sum as BigInteger to handle large numbers
        BigInteger sum = 0;

        foreach (string number in numbers)
        {
            // Convert each number from string to BigInteger
            BigInteger num = BigInteger.Parse(number);
            sum += num;
        }

        // Convert sum to string and take the first 10 characters
        string sumString = sum.ToString();
        string firstTenDigits = sumString.Substring(0, 10);

        return firstTenDigits;
    }
}
