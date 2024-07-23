public class BruteForce(){
    public int FindKthLargest(int[] nums, int k){
        Array.Sort(nums);
        return nums[nums.Length - k];
    }
}