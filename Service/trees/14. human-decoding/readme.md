### Problem Statement

You are given a number of seconds, and you need to convert this number into a more human-readable format consisting of days, hours, minutes, and seconds.

### Input
- A single integer `n` where `0 <= n <= 2^31 - 1`, representing the number of seconds.

### Output
- A string representing the time in days, hours, minutes, and seconds, formatted as follows:
  - "X days, Y hours, Z minutes, and W seconds"
  - If any of the values (X, Y, Z, or W) are zero, they should be omitted, except when all values are zero.

### Examples
1. For `n = 3662`:
   - Output: "1 hour, 1 minute, and 2 seconds"
   
2. For `n = 3600`:
   - Output: "1 hour"
   
3. For `n = 59`:
   - Output: "59 seconds"
   
4. For `n = 86461`:
   - Output: "1 day, 1 second"
   
5. For `n = 0`:
   - Output: "0 seconds"

### Constraints
- `0 <= n <= 2^31 - 1`

### Implementation

The key to solving this problem is to carefully handle the conversion of seconds to days, hours, minutes, and seconds, and format the output string according to the given rules.


