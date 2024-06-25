# Maps and Dictionaries

1. Introduction

- Maps or dictionaries are collections of key-value paris, where each key is unique.
- In C#, the `Dictionary<TKey, TValue>` class, defined in the `System.Collections.Generic` namespace, is used to represent a map.

Creating a Dictionary

- Declaration

```cs
Dictionary<int, string> dictionary = new Dictionary<int, string>();
```

- Initialization with Values:

```cs
Dictionary<int, string> dictionary = new Dictionary<int, string>
{
    {1, "one"},
    {2, "two"},
    {3, "three"}
};
```

AddingElements

- Using `Add` Method

```cs
dictionary.Add(4, "four");
```

- Using Indexer:

```cs
dictionary[5] = "five";
```

Accessing Elements

- Using Key:

```cs
string value = dictionary[2]; // "two"
```

- Using `TryGetValue` Method

```cs
if (dictionary.TryGetValue(3, out string result))
{
    Console.WriteLine(result); // "three"
}
```

Updating Elements

- Using Indexer

```cs
dictionary[1] = "ONE";
```

- Check and Update

```cs
if (dictionary.ContainsKey(2))
{
    dictionary[2] = "TWO";
}
```

Removing Elements

- Using Indexer

```cs
dictionary[1] = "ONE";

```


- Check and Update

```cs
if (dictionary.ContainsKey(2))
{
    dictionary[2] = "TWO";
}

```

Removing Elements

- Using `Remove` Method

```cs
dictionary.Remove(4);

```

- Clear All Elements

```cs
dictionary.Clear();

```

Iterating Over Dictionary

- Using `foreach` Loop

```cs
foreach (KeyValuePair<int, string> kvp in dictionary)
{
    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
}

```

- Using LINQ:

```cs
var keys = dictionary.Keys.Where(key => key > 2);
var values = dictionary.Values.Where(value => value.Contains("o"));

```


Dictionary Properties and Methods

- Count: Returns the number of key-value pairs

```cs
int count = dictionary.Count;

```


- ContainsKey: Checks if a key exists.

```cs
bool hasKey = dictionary.ContainsKey(1);

```

- ContainsValue: Checks if a value exists.

```cs
bool hasValue = dictionary.ContainsValue("one");

```

- Keys: Returns a collection of keys

```cs
ICollection<int> keys = dictionary.Keys;

```

- Values: Returns a collection of values

```cs
ICollection<string> values = dictionary.Values;

```

Performance Considerations

- Time Complexity
    - Average time complexity for operations is O(1)
    - In worst case, time complexity can degrade to O(n), where n is the number of elements

- Hash Collisions
    - Performance may be affected by hash collisions, which occur when multiple keys hash to the same index.
    - A good hash function helps minimize collisions.

- Use Cases
    - Fast Lookup
    - Key-Value Storage

    