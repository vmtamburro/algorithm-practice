using System.Reflection.Metadata.Ecma335;

public class Euler14{

    /*
    The following iterative sequence is defined for the set of positive integers:

        n -> n/2 is even
        n => 3n + 1 (n is odd)

    Using the rule above and starting with 13, we generate the following sequence:
        13 -> 40 -> 20 -> 10 -> 5 -> 16 -> 8 -> 4 -> 2 -> 1

    It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

    Which starting number, under one million, produces the longest chain?

    NOTE: Once the chain starts the terms are allowed to go above one million.
    */


    public int FindLongestCollatzSequence(int limit = 1000000)
    {
        int maxLength = 0;
        int startingNumber = 0;
        var memo = new Dictionary<long, int>();

        for (int i = 1; i < limit; i++)
        {
            int length = CollatzCounter(i, memo);
            if (length > maxLength)
            {
                maxLength = length;
                startingNumber = i;
            }
        }

        return startingNumber;
    }

     private int CollatzCounter(long term, Dictionary<long, int> cache)
    {
        if (term == 1)
        {
            return 1;
        }

        if (cache.ContainsKey(term))
        {
            return cache[term];
        }

        int nextTermCount;
        if (term % 2 == 0)
        {
            nextTermCount = CollatzCounter(term / 2, cache);
        }
        else
        {
            nextTermCount = CollatzCounter(3 * term + 1, cache);
        }

        int sequenceCount = 1 + nextTermCount;
        cache[term] = sequenceCount;
        return sequenceCount;
    }
}