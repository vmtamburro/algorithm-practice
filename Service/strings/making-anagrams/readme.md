### Problem: Making Anagrams

You are given two strings, **a** and **b**. Your task is to determine the minimum number of character deletions required to make **a** and **b** anagrams of each other.

An anagram of a string is another string that contains the same characters, only the order of characters can be different. For example, "abc" and "bca" are anagrams of each other.

#### Function Signature
```java
int makeAnagram(String a, String b)
```

#### Input Format
- The first line contains a single string, **a**.
- The second line contains a single string, **b**.

#### Output Format
- Print a single integer denoting the number of characters you must delete to make the two strings anagrams of each other.

#### Constraints
- \( 1 \leq \lvert a \rvert, \lvert b \rvert \leq 10^4 \)
- The strings \( a \) and \( b \) consist of lowercase English letters, \( a-z \).

#### Sample Input
```
cde
abc
```

#### Sample Output
```
4
```

#### Explanation
We need to delete the following characters from the strings to make them anagrams:
- From string **a**: 'd' and 'e'
- From string **b**: 'a' and 'b'

Total deletions = 2 (from **a**) + 2 (from **b**) = 4
