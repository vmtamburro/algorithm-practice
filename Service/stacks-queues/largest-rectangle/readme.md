Given an array of integers representing the heights of bars in a histogram, find the area of the largest rectangle that can be formed within the bounds of the histogram.

### Example

Consider the following histogram with 6 bars of heights `[2, 1, 5, 6, 2, 3]`:

```
|     |
|     |        |
|  |  |        |
|  |  |     |  |
|  |  |  |  |  |
|  |  |  |  |  |
```

The largest rectangle that can be formed in this histogram has an area of 10 (formed by the bars of heights `[5, 6]`).

**Input:**

An array of integers representing the heights of the histogram's bars.

```
[2, 1, 5, 6, 2, 3]
```

**Output:**

The area of the largest rectangle that can be formed in the histogram.

```
10
```

### Constraints

- \(1 \leq \text{n} \leq 10^5\)
- \(0 \leq \text{height}[i] \leq 10^4\)

### Function Signature

```python
def largestRectangleArea(heights: List[int]) -> int:
```

### Objective

Implement a function that takes an array of integers representing the heights of the bars in a histogram and returns the area of the largest rectangle that can be formed within the bounds of the histogram.
