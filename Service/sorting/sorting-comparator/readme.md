# Sorting Comparator

Comparators are used to compare two objects. In this problem, you'll create a comparator and use it to sort an array of objects.

### Problem Statement

Given an array of `n` Player objects, write a comparator that sorts them in order of decreasing score. If two players have the same score, sort them alphabetically by name. To do this, you must create a Checker class that implements the Comparator interface, then write an int compare(Player a, Player b) method.

### Input Format

Input is handled for you by the given code snippets. You are not responsible for reading any input from stdin.

### Constraints

- `0 <= score <= 1000`
- Two or more players can have the same name.
- Player names consist of lowercase English letters.

### Output Format

You are not responsible for printing any output to stdout. The locked stub code in your editor will create a Checker object, use it to sort the Player array, and print each sorted element.

### Sample Input

```
5
amy 100
david 100
heraldo 50
aakansha 75
aleksa 150
```

### Sample Output

```
aleksa 150
amy 100
david 100
aakansha 75
heraldo 50
```

### Explanation

The players are first sorted by decreasing score. When two players have the same score, they are sorted alphabetically by name.
