/* 

Find the longest subarray in n that sums to k and return that sum.

Input: nums = [1, -1, 5, -2, 3], k = 3  
Output: 4  
Explanation: The subarray [1, -1, 5, -2] sums to 3.

*/


public int LongestSubarraySum(int[] arr, int k){
    var startIndex = -1;
    var endIndex = -1;
    maxCount =  0;
    for(int i = 1; i < arr.Length; i++){
        var sum = 0;
        for(int j = i; j < arr.Length; j++){
            sum += arr[j];
            if(sum == k){
                startIndex = i;
                endIndex = j;
                maxCount = Math.Max(maxCount, endIndex - startIndex + 1);
            }
        }
    }

    return maxCount;
} 