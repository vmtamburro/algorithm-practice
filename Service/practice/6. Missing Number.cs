/* 
    * Given an unsorted array of integers, find the missing number in the array
    * Must be O(N)


    Input: [3, 7, 1, 2, 8, 4, 5]
    Output: 6
*/

public int FindMissingInteger(int[] nums){
    var set = new HashSet<int>(nums);  // Create a set to store the unique values in nums
    int n = nums.Length;

    // Loop through the range of numbers from 1 to n + 1 (since we are finding the missing number in this range)
    for(int i = 1; i <= n + 1; i++){
        if(!set.Contains(i)){
            return i;  // Return the first missing number
        }
    }

    return -1; // Default return, though logically this shouldn't happen.
}
