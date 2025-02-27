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

//Input: nums = [1, -1, 5, -2, 3], k = 3  

public int LogestArraySumOptimized(int[] arr, int k){
    var sumIndexMap = new Dictionary<int, int>();
    int maxLength = 0;
    int cumulativeSum = 0;


    for(int i = 0; i < arr.Length; i++){
        cumulativeSum += arr[i];

        if(cumulativeSum == k){
            maxLength = i + 1;
        }

        if(!sumIndexMap.ContainsKey(cumulativeSum)){
            sumIndexMap.Add(cumulativeSum, i);
        }

        if(sumIndexMap.ContainsKey(cumulativeSum - k)){
            maxLength = Math.Max(maxLength, i - sumIndexMap[cumulativeSum - k]);
        }
    }
}