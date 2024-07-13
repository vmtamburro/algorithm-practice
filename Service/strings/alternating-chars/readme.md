### Problem Statement

You are given a string containing only characters 'A' and 'B'. You need to count the minimum number of deletions required to make the string alternate. In an alternating string, no two adjacent characters should be the same.

### Example

For example, given the string:
```
AABAAB
```
You can delete the middle 'A' to get the alternating string:
```
ABAB
```
Thus, the minimum number of deletions required is 1.

### Approach

To solve this problem efficiently:

1. **Iterate Through the String**: 
   - Traverse through the string from the beginning to the end.

2. **Count Adjacent Duplicates**: 
   - Count consecutive characters that are the same.

3. **Calculate Deletions**: 
   - For each pair of consecutive characters that are the same, increment a deletion counter.

4. **Output**: 
   - Output the total count of deletions required to make the string alternating.

