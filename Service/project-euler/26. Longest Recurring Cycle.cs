public class Euler26
{
    public int FindLongestRecurringCycle(int limit = 1000)
    {
        int max = 0;
        int maxValue = 0;

        for (int i = 2; i < limit; i++)
        {
            int length = LongDivisionCycleLegth(i);
            // Calculate The Max Length and Value

            if (length > max)
            {
                max = length;
                maxValue = i;
            }

        }
        return maxValue;
    }

    /*
          123.4
    10 | 1234
        -10
          23
         -20
           34
          -30
            4
    */
    public int LongDivisionCycleLegth(int num)
    {
        int remainder = 1;
        int position = 0;
        Dictionary<int, int> remainders = new Dictionary<int, int>();

        while (remainder != 0)
        {
            remainder = (remainder * 10) % num;
            position++;
        }

        if (remainder == 0)
        {
            return 0;
        }

        return position - remainders[remainder];

    }
}