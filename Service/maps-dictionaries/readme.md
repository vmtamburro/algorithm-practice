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
- Efficient - able to handle large data sets well if the hash function and resizing are well managed.

**Cons:**
* Collision Handling - Performance can degrade if many collisions occur. Handling collisions with chaining (linked lists) or open addressing can impact performance
* Space Complexity - requires additional space for buckets and linked lists
* Hash Function Dependency - Efficiency depends on the quality of the hash function.

## Binary Search Tree Implementation
_Another way to implement a dictionary, where each node contains a key-value pair and the tree is ordered based on the keys_

**Data Structure**
* Node: Each node has a key, value, and pointers to left and right children.

**Operations:**
* Insert(key, value)
    1. Compare the key with the current node's key
    2. Insert the key-value pair to the left or right subtree based on comparison

* Get(key)
    1. Compare the key with the current node's key
    2. Traverse left or right subtrees based on the comparison until the key is found or a null reference is reached

* Delete(key)
    1. Find the node with the key
    2. Remove the node while maintaining the BST properties (handling where the node has zero, one, or two children)

**Pros**
    * Time Complexity: O(log n) average time complexity for a balanced BSTs but can degrade to O(n) if the tree is unbalanced
    * Flexible: Can handle dynamic key sets without requiring resizing

**Cons**
    * Time Complexity can degrade
    * Complex Operations (more so than compared to hash tables)


## Trade-offs
* Hash Table - best for scenarios where fast lookups and insertions are critical, and when ordering is not required. Generally preferred for avg-case constant time complexity
* Binary Search Tree - Useful when ordered data or range queries are needed. BSTs can be inefficient if not balanced. PRovide a structured way to manage data.