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