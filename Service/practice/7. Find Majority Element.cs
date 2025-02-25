/* 
    Description: Given an array of size n, find the majority element. 
    The majority element is the element that appears more than n / 2 times. 
    You may assume that the array is non-empty and that there is always a majority element.

    Input: [3, 2, 3]

    Output: 3
*/


public int FindMajorityElement(int[] nums){
    var countValues = new Dictionary<int, int>();
    var majorityElement = 0;
    for(var i = 0; i < nums.Length; i++){
        if(countValues.ContainsKey(nums[i])){
            countValues[nums[i]]++;
        }
        else{
            countValues[nums[i]] = 1;
        }
        if(countValues[nums[i]] > nums.Length / 2){
            majorityElement = nums[i];
            break;
        }
    }

    return majorityElement;
}