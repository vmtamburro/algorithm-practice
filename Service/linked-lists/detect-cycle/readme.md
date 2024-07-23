_How would you detect a cycle in a linked list?_

## Using a Hash Set
- Keep track of the visited nodes with a Hash Set
- Traverse the Linked List
- If we come across one we've already visited, then we've reached a cycle
- O(n) where n is the number of nodes in the list, and O(n) for the additional space required for the hash set.

## Using Floyd's Cycle Detection and Algorithm 
_aka the Tortoise and Hare algorithm_

- Use two pointers `slow` and `fast`
- `slow` moves one step at a time
- `fast` moves two steps at a time
- If there is no cycle, the `fast` pointer will reach the end of the list
- If there is a cycle, the `slow` and `fast` pointers will meet at some point
- O(n) where n is the number of nodes in the linked list
- O(1) since no additional space is required