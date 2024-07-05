### Notes on Sets in C#

#### Introduction

- **Sets** are collections of unique elements.
- In C#, the `HashSet<T>` class, defined in the `System.Collections.Generic` namespace, is commonly used to represent a set.


- **Hash Tables**:
    -  Data structure that maps key-value pairs where each key is unique
    - Hash Function maps the keys to indices in an array called a has table
    - Implementation
        - Array: Hash table is typically implemented using an array of linked lists.
        - Hash Function: Converts keys into indices in the array.
    - Operations
        - Insertion: Insert a key-value pair into the hash table
        - Lookup: Find the value associated with a given key.
        - Deletion: Remove a key-value pair from the hash table.

#### Creating a Set

- **Declaration**:
  ```csharp
  HashSet<int> set = new HashSet<int>();
  ```

- **Initialization with Values**

```cs
HashSet<int> set = new HashSet<int> { 1, 2, 3, 4, 5 };

```

- **Adding Elements**

```cs
set.Add(6);
set.UnionWith(new int[] { 7, 8, 9 });
```


- **Removing Elements**

```cs
set.Remove(3);
set.Clear();

```

- **Checking for Elements**

```cs
bool containsThree = set.Contains(3);

```

Set Operations

- Union

```cs
HashSet<int> setA = new HashSet<int> { 1, 2, 3 };
HashSet<int> setB = new HashSet<int> { 3, 4, 5 };
setA.UnionWith(setB); // setA now contains { 1, 2, 3, 4, 5 }

```

- Intersection

```cs
HashSet<int> setA = new HashSet<int> { 1, 2, 3 };
HashSet<int> setB = new HashSet<int> { 3, 4, 5 };
setA.IntersectWith(setB); // setA now contains { 3 }

```

- Difference

```cs
HashSet<int> setA = new HashSet<int> { 1, 2, 3 };
HashSet<int> setB = new HashSet<int> { 3, 4, 5 };
setA.ExceptWith(setB); // setA now contains { 1, 2 }

```

- Symmetric Difference

```cs
HashSet<int> setA = new HashSet<int> { 1, 2, 3 };
HashSet<int> setB = new HashSet<int> { 3, 4, 5 };
setA.SymmetricExceptWith(setB); // setA now contains { 1, 2, 4, 5 }

```

**Iterating over a Set**

- Using a `foreach` Loop

```cs
foreach (var item in set)
{
    Console.WriteLine(item);
}

```

**Additional Methods**

- Count

```cs
int count = set.Count; // Number of elements in the set

```

- IsSubsetOf

```cs
bool isSubset = setA.IsSubsetOf(setB);

```

- IsSupersetOf

```cs
bool isSubset = setA.IsSubsetOf(setB);

```

- Set Equality

```cs
bool areEqual = setA.SetEquals(setB);

```

- Overlaps

```cs
bool overlaps = setA.Overlaps(setB);

```
