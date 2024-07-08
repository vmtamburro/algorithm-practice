### Minimum Steps to Reach Destination in a Maze

**Problem Statement**:
You are given a 2D matrix representing a maze where:
- `0` represents a path.
- `1` represents a wall or obstacle.
- You start from the top-left corner `(0, 0)`.
- The destination is at the bottom-right corner `(n-1, m-1)`.

Write a function to return the minimum number of steps required to reach the destination if movement is allowed only in four possible directions: up, down, left, and right.

**Example**:
```
Matrix:
[
 [0, 0, 1, 0],
 [0, 0, 0, 0],
 [0, 1, 0, 1],
 [0, 0, 0, 0]
]

Start: (0, 0)
Destination: (3, 3)

Expected Output: 7
```

### Follow-up Questions:
- How would you modify your solution if diagonal movement (`up-left`, `up-right`, `down-left`, `down-right`) is allowed?
- Discuss the time and space complexity of your solution. How would you optimize it further?

