## Linked Lists

### Definition

- Linear data structure where each element (node) is a separate obj
- Each node contains twp parts
  - Data
  - Reference (link) to the next node

![alt text](image.png)

### Types

- Singly Linked List
  - Each Node points to the next node in sequence
- Doubly Linked List
  - Each node has pointers to both the next and previous nodes, allowing traversal in both directions
    ![alt text](image-1.png)
- Circular Linked List
  - The last node points back to the first node, forming a circle

### Advantages

- Dynamic Size
  - Linked lists can grow or shrink in size dynamically since nodes are allocated dynamically
- Ease of Insertion/Deletion
  - Insertions and Deletions are efficient O(1) time complexity as they involve adjusting pointers unlike arrays, which require shifting elements

### Basic Operations

1. Traversal:
    - Iterating through the list from the head to the last node

    ```cs
    public void PrintList(){
        Node current = head;
        while(current != null){
            Console.WriteLine(current.data + " ");
            current = current.next;
        }
        Console.WriteLine();
    }
    ```

2. Insertion:
    - At the Beginning
    - At the End
    - In the Middle

    ```cs
        // Insert at the beginning of the linked list
    public void InsertAtBeginning(int value){
        Node newNode = new Node(value);
        newNode.next = head;
        head = newNode;
    }


    // Insert at the end of the linked list
    public void InsertAtEnd(int value){
        Node newNode = new Node(value);
        if(head == null){
            head = newNode;
            // Don't set the new node's next, because this should always be null at the end
            return;
        }

        Node current = head; // set to the beginning for traversal
        while(current.next != null){ // go to the last node
            current = current.next;
        }

        //attach node to the linked list at the end.
        current.next = newNode;
    }


    // Insertion after a specific node (middle)
    public void InsertAfterNode(Node prevNode, int value){
        if(prevNode == null)
        {
            Console.WriteLine("Previous node cannot be null");
            return;
        }

        // adjust the next and prev of this current node.
        Node newNode = new Node(value);
        newNode.next = prevNode.next;
        prevNode.next = newNode;
    }
    ```

3. Deletion:
    - Adjust pointers to skip over the node to be deleted and deallocate its memory

    ```cs
    public void DeleteNode(int value){
        Node? current = head;
        Node? prev = null;


        // if it's the first value - just make the new head the next one
        if(current != null && current.data == value){
            head = current.next;
        }


        while(current != null && current.data != value){
            prev = current;
            current = current.next;
        }

        if(current == null){
            Console.WriteLine("Value not found in the list");
        }
        // adjust the pointers of the prev to skip the current 
        prev.next = current.next;
    }
    ```

4. Search
    - Traverse the list to find a specific node based on its data value

    ```cs
        public bool Search(int value){
        Node current = head;
        while(current != null){
            if(current.data == value){
                return true;
            }
            current = current.next;
        }
        return false;
    }
    ```

### Key Considerations

- Null Pointer - last node in linked list points to `null` indicating the end of the list

- Head Pointer - A reference to the first node `head` allows access to the entire list

### Summary

- Linked Lists are fundamental data structures characterized by their dynamic size, efficient insertion/deletion operations, and various types catering to different needs (singly, doubly, circular)

## Problems

### Inserting a Node into a Doubly Linked List

First create the DoublyLinkedList data structure and utilities. Below is the DoublyLinkedList Node class, which has three properties: one for the value to be held on the node itself, and two recursive DoublyLinkedList representing the pointers to the next and previous nodes. The class also includes a constructor to set the nodeData for ease of insertion.

```cs
public class DoublyLinkedListNode
{
    public int data;
    public DoublyLinkedListNode next;
    public DoublyLinkedListNode prev;

    public DoublyLinkedListNode(int nodeData)
    {
        this.data = nodeData;
        this.next = null;
        this.prev = null;
    }
}
```

Next we have the DoublyLinkedList object which has  two DoublyLinkedList properties to track the head and tail of the LinkedList.

```cs
public class DoublyLinkedList
{
    public DoublyLinkedListNode head;
    public DoublyLinkedListNode tail;

    public DoublyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    ...
}
```

Inside of the `AppendNode` method we have several utility methods for ease of management. The first is the InsertNode method. This method declares and instantiates a new `DoublyLinkedList`. It then evaluates whether this is the first node in the list and sets it as the head. If so, it sets the head to the node. If there were pre-existing objects, we set the tail's `next` node property to our new node, and adjust the reference to the tail to the new node.

```cs
    public void AppendNode(int nodeData)
    {
        DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

        if (this.head == null)
        {
            this.head = node;
        }
        else
        {
            this.tail.next = node;
            node.prev = this.tail;
        }

        this.tail = node;
    }
```

To traverse the node from a specific node point (For example to print each value), we can use a while loop. On each insertion iteration, we update the iterating to be the `next` node. Our break condition is that the `next` node is not null, as it would be on the reference from the tail node.

```cs
public void PrintDoublyLinkedList(DoublyLinkedListNode node, string sep)
{
    while (node != null)
    {
        Console.WriteLine(node.data);

        node = node.next;

        if (node != null)
        {
            Console.WriteLine(sep);
        }
    }
}

```

To reverse the linked list, we can use the following utility method. First do a validation check to ensure the list is not empty and return early. Inside the loop, we swap the next and prev pointers, and iterate to the "prev" (which was our original "next" node), and continue for all the operations.

```cs

public static DoublyLinkedListNode reverse(DoublyLinkedListNode llist) {
    // Initialize the current node to the head of the list
    var current = llist;
    // If the list is empty, return null
    if (current == null) return null;

    // Traverse through the list
    while (current != null) {
        // Swap the next and prev pointers
        var temp = current.next;
        current.next = current.prev;
        current.prev = temp;

        // Check if we are at the new head of the list
        if (current.prev == null) {
            // current is now the new head of the reversed list
            return current;
        }

        // Move to the next node (which is the previous node before swapping)
        current = current.prev;
    }

    // Return null if the list is empty
    return null;
}


```

To create a sorted list via insertion we can perform the following operations. First check if the list is empty, or if the first node value is greater than our insertion value, and we insert at the front. (1) adjust the `next` property to be the head of our linked list, (2) if the list is not empty, set the prev pointer to our current node. We then return the head of the list which is our new node.

If we are inserting into the middle or end, we will need to traverse the list to find our insertion point, and insert the new node. (1) find the first node that's `next` node has a greater value than the current node, (2) set the next value of our new node to the greater node, (3) if the traversed `next` node isn't the end of the list, set the prev value to our current node. (4) set the current node's `next` property to our new node. (5) set the new node's `prev` property to the current node.

```cs
 public static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode llist, int data)
    {
        var newNode = new DoublyLinkedListNode(data);

        // Handle insertion at the beginning or if the list is empty
        if (llist == null || llist.data >= newNode.data)
        {
            newNode.next = llist;
            if (llist != null)
            {
                llist.prev = newNode;
            }
            return newNode;
        }

        // Traverse the list to find the insertion point
        DoublyLinkedListNode current = llist;
        while (current.next != null && current.data < newNode.data)
        {
            current = current.next;
        }

        // Insert the new node
        newNode.next = current.next;
        if (current.next != null)
        {
            current.next.prev = newNode;
        }
        current.next = newNode;
        newNode.prev = current;

        return llist;
    }
```

### Finding a Merge Point of a Node

Two linked lists will eventually point to a reference to the same node.  The blow method shows how we can determine at what point the two nodes reference each the same node. 

First, we have to check if the two linked lists are the same length. If not, we will need to fast forward the root of the longer list.

```
Example: 

1-2-3*-4-5 
1*-4-5
```

The `GetLength` method is a simple helper function that increments the count for each node we traverse.
```cs
// Helper function to get the length of a linked list
    private static int GetLength(SinglyLinkedListNode head)
    {
        int length = 0;
        while (head != null)
        {
            length++;
            head = head.next;
        }
        return length;
    }

```

We then continue to the fast-forward operation. First we must determine which node is longer than the other, and fast-forward that linked list. We then decrement the count, which is the difference in length of the two lists, and traverse one node per each count.


Finally, we traverse the list to find the merge node, by doing a direct object comparison of `if(head1 == head2)`. If no node is found, we return 0;

```cs

static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
    {
        // determine the length of each linked list
        var len1 = GetLength(head1);
        var len2 = GetLength(head2);

        // advance the longer list to the start index of the second array
        // ex: [*1 2 3] and [1 *3 2 1]
        if (len1 > len2)
        {
            var count = len1 - len2;
            while (count > 0 && head1 != null)
            {
                head1 = head1.next;
                count--;
            }
        }
        else
        {
            var count = len2 - len1;
            while (count > 0 && head2 != null)
            {
                head2 = head2.next;
                count--;
            }

        }

        // traverse to find the merge node
        while (head1 != null && head2 != null)
        {
            if (head1 == head2)
            {
                return head1.data;
            }
            head1 = head1.next;
            head2 = head2.next;
        }

        return 0;
    }
```