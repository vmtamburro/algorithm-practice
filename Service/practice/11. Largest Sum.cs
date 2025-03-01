/* 
    Given an array A, find the contiguous subarray with the largest sum.
    Kadane's algorithm
*/

public int MaxSubArray(int[] nums) {
    int maxSum = nums[0];
    int currentSum = nums[0];

    for (int i = 1; i < nums.Length; i++) {
        currentSum = Math.Max(nums[i], currentSum + nums[i]);
        maxSum = Math.Max(maxSum, currentSum);
    }

    return maxSum;
}


public int MaxXubArrayBruteForce(int[] nums){
    int maxSum = int.MinValue;
    for(int i = 0; i < nums.Length; i++){
        int currentSum = 0;
        for(int j = i; j < nums.Length; j++){
            currentSum += nums[j];
            maxSum = Math.Max(maxSum, currentSum);
        }
    }

    return maxSum;
}
