/* 
    * Given an unsorted array of integers, find the length of the longest consecutive numbers
    * Consecutive but not contiguous
    * Must be O(N)

*/

public int LongestConsecutive(int[] nums){
    var set = new HashSet<int>(nums);
    var longestStreak = 0;

    foreach(var num in nums){
        if(!set.Contains(num - 1)){
            var currentNum = num;
            var currentStreak = 1;

            while(set.Contains(currentNum + 1)){
                currentNum++;
                currentStreak++;
            }

            longestStreak = Math.Max(longestStreak, currentStreak);
        }
    }

    return longestStreak;
}


public int FindMissingInteger(int[] nums){
    var set = new HashSet<int>(nums);
    int n = nums.Length;
    
    // The expected sum of the first N+1 integers
    int expectedSum = (n + 1) * (n + 2) / 2; 
    
    // The actual sum of the elements in the array
    int actualSum = 0;
    
    foreach(var num in nums){
        actualSum += num;
    }
    
    // The missing number is the difference between the expected sum and the actual sum
    return expectedSum - actualSum;
}
