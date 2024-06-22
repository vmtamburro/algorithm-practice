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


    public int FindMaxCollatzSequence(int num){
        num = 1000000;
        var max = 0;

        while(num > 0){
            var sequence = CollatzCounter(num);
            if(sequence > max){
                max = sequence;
            }
            num--;
        }

        return max;
    }

    public int CollatzCounter(int term){
        var sequenceCount = 1;
        while (term != 1){

            if(term %2 == 0){
                term /= 2;
            }
            else{
                term = (3 * term) + 1;
            }

            sequenceCount++;
        }

        return sequenceCount;

    } 
}