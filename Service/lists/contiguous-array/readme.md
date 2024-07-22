_Given a list of integers, how would you find the largest sum of any contiguous array?_

**Contiguous Array** - sequence of elements within a larger array, where all the elements are consecutive and in the same order as they appear in the original array.


## Brute Force Approach
1. Iterate over all the SubArrays
    - Use nested loops to generate all possible contiguous arrays
    - For each subarray, calculate the sum.
2. Track the Maximum Sum
    - Keep a variable to store the max sum encountered

**TimeComplexity:** O(n^3)


## Kadene's Algorithm
_Iterates through the subarray while keeping track of two variables `maxEndingHere` and `maxSoFar`_

Steps:
- Set `maxEndingHere` to first element of the array
- Set `maxSoFar` to the first element of the array
- For each element, update `maxEndingHere` to obe the max of the current element itself or current elment plus `maxEndingHere` which extends the prev subarray
- Update `maxSoFar` to be the maximum itself or the `maxEndingHere`



### **Example Array**

Consider the array: `[3, -2, 5, -1, 2, -4, 6, -3]`.

### **Step-by-Step Process**

1. **Initialization**:
   - `maxSoFar` = `3` (first element)
   - `maxEndingHere` = `3` (first element)

2. **Iterate Through the Array**:

   - **Index 1** (Value: `-2`):
     - `maxEndingHere` = max(-2, 3 + (-2)) = max(-2, 1) = 1
     - `maxSoFar` = max(3, 1) = 3

   - **Index 2** (Value: `5`):
     - `maxEndingHere` = max(5, 1 + 5) = max(5, 6) = 6
     - `maxSoFar` = max(3, 6) = 6

   - **Index 3** (Value: `-1`):
     - `maxEndingHere` = max(-1, 6 + (-1)) = max(-1, 5) = 5
     - `maxSoFar` = max(6, 5) = 6

   - **Index 4** (Value: `2`):
     - `maxEndingHere` = max(2, 5 + 2) = max(2, 7) = 7
     - `maxSoFar` = max(6, 7) = 7

   - **Index 5** (Value: `-4`):
     - `maxEndingHere` = max(-4, 7 + (-4)) = max(-4, 3) = 3
     - `maxSoFar` = max(7, 3) = 7

   - **Index 6** (Value: `6`):
     - `maxEndingHere` = max(6, 3 + 6) = max(6, 9) = 9
     - `maxSoFar` = max(7, 9) = 9

   - **Index 7** (Value: `-3`):
     - `maxEndingHere` = max(-3, 9 + (-3)) = max(-3, 6) = 6
     - `maxSoFar` = max(9, 6) = 9

3. **Final Result**:
   - The maximum sum of any contiguous subarray is `9`.

### **Illustration**

Here’s how the algorithm processes the array:

- **Initial State**: `[3]` (max sum so far is `3`)
- **After Index 1**: Subarray `[3, -2]`, max sum is `3` (because `1 < 3`)
- **After Index 2**: Subarray `[3, -2, 5]`, max sum is `6` (because `6 > 3`)
- **After Index 3**: Subarray `[3, -2, 5, -1]`, max sum remains `6` (because `5 < 6`)
- **After Index 4**: Subarray `[3, -2, 5, -1, 2]`, max sum is `7` (because `7 > 6`)
- **After Index 5**: Subarray `[3, -2, 5, -1, 2, -4]`, max sum remains `7` (because `3 < 7`)
- **After Index 6**: Subarray `[3, -2, 5, -1, 2, -4, 6]`, max sum is `9` (because `9 > 7`)
- **After Index 7**: Subarray `[3, -2, 5, -1, 2, -4, 6, -3]`, max sum remains `9` (because `6 < 9`)

### **Summary**

Kadane’s Algorithm efficiently identifies that the maximum sum of any contiguous subarray in `[3, -2, 5, -1, 2, -4, 6, -3]` is `9`. This result is achieved in linear time, making it ideal for large arrays.