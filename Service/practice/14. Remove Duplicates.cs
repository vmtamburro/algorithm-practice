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
    if (nums.Length == 0) return 0;

    int maxDupes = 2;
    int writeIndex = 1;
    int count = 1;

    for (int i = 1; i < nums.Length; i++) {
        if (nums[i] == nums[i - 1]) {
            count++;
        } else {
            count = 1;
        }

        if (count <= maxDupes) {
            nums[writeIndex] = nums[i];
            writeIndex++;
        }
    }

    return writeIndex;
}
}