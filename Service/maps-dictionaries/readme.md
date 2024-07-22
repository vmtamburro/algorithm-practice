_How would you implement a dictionary structure from scratch? What are the tade-offs of using a hash table versus a binary search tree for this implementtion?_


## Hash Table Option
**Data Structure:**
* Array of Buckets: each bucket contains a linked-list of key-value pairs to handle collisions.


**Operations:**
* Insert (key, value)
    1. Compute the hash code for the key
    2. Use the hash code to determine the bucket index
    3. Insert the key-value pair into the corresponding bucket
* Get (key)
    1. Compute the hash code for the key
    2. Access the bucket using the hash code
    3. Search the bucket for the key and return the associated value
* Delete (key)
    1. Compute the hash code for the key.
    2. Access the bucket using the hash code
    3. Search the bucket for the key and remove the key-value pair if found.

**Pros:**

-  O(1) Operations as average time complexity for insertion, deletion, and lookup
- Efficeint - able to handle arge data sets well if the hash function and resizing are well managed.

**Cons:**
* Collision Handling - Performance can degrade if many collisions occur. Handling collisions with chaining (linked lists) or open addressing can impact performance
* Space Complexity - requires additional space for buckets and linked lists
* Hash Function Dependency - Efficeincy depends on the quality of the hash function.

## Binary Search Tree Implementation