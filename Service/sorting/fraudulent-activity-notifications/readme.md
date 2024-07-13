# Fraudulent Activity Notifications

HackerLand National Bank has a simple policy for warning clients about possible fraudulent account activity. If the amount spent by a client on a particular day is greater than or equal to 2 times the client's median spending for a trailing number of days, they send the client a notification about potential fraud.

### Function Description

Complete the function `activityNotifications` in the editor below. It must return an integer representing the number of client notifications sent.

`activityNotifications` has the following parameter(s):

- `expenditure`: an array of integers representing daily expenditures
- `d`: an integer, the number of trailing days used to calculate median spending

### Input Format

- The first line contains two space-separated integers `n` and `d`, the number of days of transaction data, and the number of trailing days' data used to calculate median spending.
- The second line contains `n` space-separated non-negative integers where each integer `expenditure[i]` denotes expenditure for day `i`.

### Constraints

- \(1 \leq n \leq 2 \times 10^5\)
- \(1 \leq d \leq n\)
- \(0 \leq expenditure[i] \leq 200\)

### Output Format

- Print an integer denoting the total number of times the client receives a notification over all `n` days.

### Sample Input

```
9 5
2 3 4 2 3 6 8 4 5
```

### Sample Output

```
2
```

### Explanation

On the first day, you calculate the median of the expenditures so far. Any expenditure greater than or equal to 2 times the median is a notification:
- Median spending for the first 5 days: [2, 3, 4, 2, 3] → median is 3
- Expenditure for day 6 is 6. 6 >= 2 * 3 → notification sent.

Similarly, on day 7, the median is [3, 4, 2, 3, 6] → median is 3. Therefore, there are 2 notifications sent over the 9 days.
