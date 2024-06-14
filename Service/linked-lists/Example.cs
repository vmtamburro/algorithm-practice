using System;

public class Node{
    public int data;
    public Node? next;
    public Node(int value){
        data = value;
        next = null;
    }
}

public class LinkedList{
    public Node? head;
    public LinkedList(){
        head = null;
    }


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


    // Deletion by Value
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


    // Traversal of the LinkedList
    public void PrintList(){
        Node current = head;
        while(current != null){
            Console.WriteLine(current.data + " ");
            current = current.next;
        }
        Console.WriteLine();
    }

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
}