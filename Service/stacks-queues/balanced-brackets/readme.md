You are given a string containing just the characters `'(', ')', '{', '}', '[' and ']'`. Determine if the input string is valid.

An input string is valid if:
1. Open brackets must be closed by the same type of brackets.
2. Open brackets must be closed in the correct order.

Note that an empty string is also considered valid.

### Example

**Input:**
```
{[()]}
```

**Output:**
```
YES
```

**Input:**
```
{[(])}
```

**Output:**
```
NO
```

**Input:**
```
{{[[(())]]}}
```

**Output:**
```
YES
```

---

### Constraints

- The input string will have a length between 1 and \(10^3\).

