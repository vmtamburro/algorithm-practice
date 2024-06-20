public class Euler9
{
    /*
        A pythagorean triplet is a set of three natural numbers, a  < b < c, fo which a^2 + b^2 = c^2. There exists exactly one pythagorean triplet for which a + b + c = 1000.
        Find the product a * b * c
    */

    public int FindPythagoreanTripletProduct(int sum)
    {

        sum = 1000;
        for (int a = 1; a < sum / 3; a++) // since a < b < c and a + b + c = sum, a goes to sum / 3, because b and c must be greater than a.
        {
            for (int b = a + 1; b < sum / 2; b++)
            {
                int c = sum - a - b;
                if (a * a + b * b == c * c)
                {
                    // Found the triplet where a < b < c and a^2 + b^2 = c^2
                    return a * b * c;
                }
            }
        }

        return -1; // No triplet found satisfying the condition
    }
}