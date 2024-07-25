_Explain how a hash table handles collsions. What are some common collision resolution techniques?_

In hash tables **collisions** occur when two or more keys hash to the same index or bucket in the hash table. This is because the hash function maps a potentially large number of keys to a finite number of slots in the hash table. When two or more keys are mapped to the same slot, they are said to collide.

## Causes of Collisions

1. **Hash Function Limitations** 
    - Hash Function generates the same index for different keys
    - Inevitable in most functions due to the pigeonhole principle, there are more possible keys than slots in the hash table.
2. **Load Factor**
    - Load factor is the ratio of the number of elements to the number of slots. A higher load factor increases the probability of collisions

## Consequences of Collisions

1. Decreased performance
    - Longer Search Times
    - More elements examined to find a particular key

2. Complexity

## Collision Resolution Techniques

1. Chaining (Separate Chaining):
* Each slot in the hash table points to a linked list or another data structure that stores all of the elements hashed to that slot.
* Pros: simple, handles high load factors well
* Cons: Additional memory for linked lists; performance can degrade with higher load factors

```plaintext
Index: 0 -> [ ] 
       1 -> [21] -> [31] -> [41]
       2 -> [ ] 
       3 -> [ ] 
       4 -> [14] -> [24]

```

2. Open Addressing
* All elements are stored within the hash table itself. When a collision occurs, alternative locations are probed until an empty slot is found
    * Linear Probing
    * Quadratic Probing
    * Double Hashing
* Pros: No additional memory for linked lists
* Cons: Clustering can occur, affecting performance; requires careful handling of deleted slots

```plaintext
Index: 0 -> [ ]
       1 -> [21]
       2 -> [22]
       3 -> [23]
       4 -> [24]
```

3. Rehashing
    * When the load factor exceeds a certain threshold, the hash table is resized, and all elements are rehashed to the new table. Reduces the number of collisions
    * Pros: Maintains the performance as the table grows
    * Cons: Rehashing is computationally expensive, and requires resizing of the table.
