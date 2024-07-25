_Explain how a queue can be implemented using two stacks. What are the time complexities for the enqueue and dequeue operations_

## Queue properties
* First In First Out
* Adds to the end, and pulls from the front

## Stack Properties
* Last In First Out
* Adds to the end, pulls from the end.

### Implementation with Two Stacks
- Enqueue
    - Add Elements to Stack 1 O(1)
- Dequeue
    - Pop All Elements to Stack 2 (in reverse) O(n)
    - Pop Stack 2 O(1)


- Enqueue A, B, C
    - Stack 1: A -> B -> C
    - Stack 2: empty
- Dequeue A
    - Stack 1:
    - Stack 2: C -> B -> A
    - Pop Operation. Left with B->C

- Enqueue D
    - Stack 1: D
    - Stack 2: C -> B 
- Dequeue B
    - Stack 1: D
    - Stack 2: C 
- Dequeue C
    - Stack 1: D
    - Stack 2: 

- Enqueue E
    - Stack 1: D -> E
    - Stack 2: 
- Dequeue D
    - Stack 1:
    - Stack 2: E -> D
    - Pop Operation. Left with E

