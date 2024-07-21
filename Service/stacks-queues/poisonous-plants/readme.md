### Poisonous Plants Problem Statement

You have a collection of plants arranged in a row, and each plant has a certain amount of pesticide on it. If a plant has more pesticide than the plant to its left, it becomes poisoned and dies. You need to determine how many days it will take for no plants to die.

### Input

- The first line contains an integer `n` representing the number of plants.
- The second line contains `n` integers, where the `i-th` integer `pi` represents the amount of pesticide in the `i-th` plant.

### Output

- Output a single integer representing the number of days after which no plant dies.

### Constraints

- \(1 \leq n \leq 10^5\)
- \(0 \leq p_i \leq 10^9\)

### Example

#### Input
```
7
6 5 8 4 7 10 9
```

#### Output
```
2
```

#### Explanation

- On the first day, plants with pesticide amounts `8`, `7`, and `10` will die because they have more pesticide than the plants to their left (`5`, `4`, and `7` respectively). The remaining plants will be `[6, 5, 4, 9]`.
- On the second day, the plant with pesticide amount `9` will die because it has more pesticide than the plant to its left (`4`). The remaining plants will be `[6, 5, 4]`.
- No plants will die on the third day, so the process stops. The total number of days after which no plants die is `2`.

### Task

Write a program that reads the input, simulates the process, and outputs the number of days after which no plant dies.

### Notes

- Plants only die if they have more pesticide than the plant directly to their left.
- The goal is to determine the number of days until the process stabilizes and no more plants die.

This problem can be approached by using a stack to efficiently track the plants and their pesticide levels, simulating the process day by day until no plants die.