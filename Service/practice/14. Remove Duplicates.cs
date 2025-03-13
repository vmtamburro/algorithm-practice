public class Solution {
    /* 
        numDuplicates = 2
        [1, 1, 1, 2, 2, 3]
        Dictionary<int, int>
        iter 1
            {<1, 1>}
            val > numDuplicates?
            no - leave and move on
        iter 2
            {<1, 2>}
            val > numDuplicates?
            no -leave and move on
        iter 3
            {<1, 3>}
            val > numDuplicates?
            yes - shift
        iter4
            {<1, 3>, <2, 1>}
            val > numDuplicates?
            no -leave and move on
         iter5
            {<1, 3>, <2, 2>}
            val > numDuplicates?
            no -leave and move on
        iter5
            {<1, 3>, <2, 1>}
            val > numDuplicates?
            no -leave and move on

        BREAK

        Don't like modifying array while looping - weird things happen. while loop is probably better
        How can we avoid shifting? moving pointer because after k doesn't matter. 
        
    
    */
    public int RemoveDuplicates(int[] nums) {
        var frequencyDict = new Dictionary<int, int>();
        var maxDupes = 2;
        var index = 0;
        var cleanedArrayLength = nums.Length; // keep track of the length while we are cleaning dupes
        Console.WriteLine($"Length: {nums.Length}");

        while(index < cleanedArrayLength){
            var num = nums[index];

            // add or increment dictionary value
            if(frequencyDict.ContainsKey(num)){
                frequencyDict[num]++;
            } else {
                frequencyDict.Add(num, 1);
            }
            Console.WriteLine($"Num: {num}, Frequency: {frequencyDict[num]}");

            // evaluate if we need to shift
            if(frequencyDict[num] > maxDupes){
                Console.WriteLine($"Shifting: {num}");
                Console.WriteLine(String.Join(", ", nums));


                var shiftIndex = index + 1;
                Console.WriteLine(shiftIndex);
                while(cleanedArrayLength > shiftIndex){
                    Console.WriteLine($"Shifting: {nums[shiftIndex]} to {nums[shiftIndex - 1]}");
                    nums[shiftIndex - 1] = nums[shiftIndex];
                    Console.WriteLine(String.Join(", ", nums));
                    shiftIndex++;
                }
                cleanedArrayLength--;
                Console.WriteLine("Cleaned Array Length: " + cleanedArrayLength);
                Console.WriteLine(String.Join(", ", nums));
            }
            else{
                index++;
            }
        }
        return cleanedArrayLength;
    }
}