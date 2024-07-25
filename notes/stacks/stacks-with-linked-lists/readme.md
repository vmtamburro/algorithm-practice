_How would  you implement a stack using arrays and linked lists?_

## Overview
- Stack is a data structure that is Last in First Out (LIFO)
- Adding a new element adds to the top of the stack, and when you do a 'pop' or 'peek' it deals with the most recently added element.


## Array-Based Stack:

- Operations: Push, Pop, Peek are O(1) on average.
- Resizing: Needed when the array is full, which involves copying elements to a larger array.
- Advantages: Constant-time operations for stack operations if resizing is infrequent.
- Disadvantages: Resizing can be expensive and uses extra space.


## Linked List-Based Stack:

- Operations: Push, Pop, Peek are O(1).
- Advantages: No resizing needed, and the stack can grow as needed.
- Disadvantages: Uses more memory due to node overhead and involves pointer management.