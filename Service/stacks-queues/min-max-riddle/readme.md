### Min-Max Riddle Problem Statement

You are given an array of integers, and you need to determine the maximum of the minimum values for every window size in the array. Specifically, for every possible window size \(k\) (where \(1 \leq k \leq n\), and \(n\) is the length of the array), you need to find the maximum value of the minimum values of all subarrays of size \(k\).

### Input

- An integer array \( \text{arr} \) of size \( n \).

### Output

- An array of integers, where the \( i \)-th element (1-based index) is the maximum of the minimum values of all subarrays of size \( i \).

### Example

#### Example 1:

**Input:**
```plaintext
arr = [6, 3, 5, 1, 12]
```

**Output:**
```plaintext
[12, 5, 3, 3, 1]
```

**Explanation:**

- For window size 1: The subarrays are [6], [3], [5], [1], [12]. The minimum values are 6, 3, 5, 1, 12. The maximum of these is 12.
- For window size 2: The subarrays are [6, 3], [3, 5], [5, 1], [1, 12]. The minimum values are 3, 3, 1, 1. The maximum of these is 3.
- For window size 3: The subarrays are [6, 3, 5], [3, 5, 1], [5, 1, 12]. The minimum values are 3, 1, 1. The maximum of these is 3.
- For window size 4: The subarrays are [6, 3, 5, 1], [3, 5, 1, 12]. The minimum values are 1, 1. The maximum of these is 1.
- For window size 5: The subarray is [6, 3, 5, 1, 12]. The minimum value is 1. The maximum of these is 1.

Thus, the result is [12, 5, 3, 3, 1].

### Constraints

- \( 1 \leq n \leq 10^5 \)
- \( 0 \leq \text{arr}[i] \leq 10^9 \)

### Approach

To solve this problem efficiently, follow these steps:

1. **Find the Previous and Next Smaller Elements:**
   - For each element in the array, determine the previous and next smaller elements. This helps in identifying the span of subarrays where the current element is the minimum.
  
2. **Use the Span to Calculate the Minimums:**
   - For each element, calculate the length of the window in which it is the minimum.

3. **Populate the Result Array:**
   - Using the spans calculated, populate the result array by iterating over possible window sizes and determining the maximum minimum value for each window size.

The efficient solution to this problem typically involves the use of stacks to find the previous and next smaller elements in \(O(n)\) time, followed by a second pass to fill in the result array.