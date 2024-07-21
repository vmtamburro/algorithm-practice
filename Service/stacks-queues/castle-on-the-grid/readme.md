## Castle on the Grid Problem Statement

You are given a grid with `n` rows and `m` columns. Each cell in the grid is either empty (represented by `.`) or contains a barrier (represented by `X`). Your task is to find the minimum number of moves required for the castle to move from a given start position to a given end position. The castle can move horizontally or vertically in a straight line until it meets a barrier or the edge of the grid. The castle cannot move diagonally.

### Input Format

- The first line contains a single integer, `n`, denoting the number of rows in the grid.
- Each of the next `n` lines contains a string of length `m`, where each character is either `.` (an empty cell) or `X` (a barrier).
- The last two lines contain two space-separated integers each: 
  - The first pair denotes the starting coordinates `(startX, startY)`.
  - The second pair denotes the ending coordinates `(endX, endY)`.

### Output Format

- Print a single integer, the minimum number of moves required to get from the start position to the end position. If it is not possible to reach the end position, print `-1`.

### Constraints

- `1 ≤ n, m ≤ 1000`
- `0 ≤ startX, startY, endX, endY < n`
- The start and end positions are always empty cells.

### Example

**Input:**
```
4
.X..
.X..
....
....
0 0
3 3
```

**Output:**
```
3
```

**Explanation:**
1. The castle starts at position (0, 0).
2. It can move to (2, 0) in one move.
3. It can then move to (2, 3) in another move.
4. Finally, it can move to (3, 3) in one more move.
So, the minimum number of moves is 3.

