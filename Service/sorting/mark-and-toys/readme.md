# Mark and Toys

Mark and Jane are very happy after having their first child. Their son loves toys, so Mark wants to buy some. There are a number of different toys lying in front of him, tagged with their prices. Mark has only a certain amount of money and wants to maximize the number of toys he buys with this money.

### Function Description

Complete the function `maximumToys` in the editor below. The function must return an integer representing the maximum number of toys Mark can buy.

`maximumToys` has the following parameter(s):

- `prices`: an array of integers representing toy prices
- `k`: an integer, Mark's budget

### Input Format

- The first line contains two integers, `n` and `k`, the number of toys and Mark's budget.
- The second line contains `n` space-separated integers, `prices[i]`, the price of each toy.

### Constraints

- \(1 \leq n \leq 10^5\)
- \(1 \leq k \leq 10^9\)
- \(1 \leq \text{prices}[i] \leq 10^9\)

### Output Format

- Print the maximum number of toys Mark can buy.

### Sample Input

```
7 50
1 12 5 111 200 1000 10
```

### Sample Output

```
4
```

### Explanation

Mark can buy only 4 toys at most. These toys have the following prices: 1, 12, 5, and 10. The sum of the prices is \(1 + 12 + 5 + 10 = 28 \leq 50\).
