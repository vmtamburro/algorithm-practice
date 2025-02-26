/* 
    Description: Given an array of size n, find the majority element. 
    The majority element is the element that appears more than n / 2 times. 
    You may assume that the array is non-empty and that there is always a majority element.

    Input: [3, 2, 3]

    Output: 3
*/



// O(N) Time Complexity, O(N) Space Complexity
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


// O(N) Time Complexity, O(1) Space Complexity
public int FindMajorityElement(int[] nums){
    int candidate = nums[0];
    int count =1;
    for(int i = 1; i < nums.Length; i++){
        if(count == 0){
            candidate = nums[i];
            count = 1;
        }
        else if(candidate == nums[i]){
            count++;
        }
        else{
            count--;
        }
    }

}