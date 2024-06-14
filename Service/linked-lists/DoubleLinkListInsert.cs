using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

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

public class DoublyLinkedList
{
    public DoublyLinkedListNode head;
    public DoublyLinkedListNode tail;

    public DoublyLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    public void InsertNode(int nodeData)
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
}


public class DoublyLinkedListExample
{

    /*
     * Complete the 'sortedInsert' function below.
     *
     * The function is expected to return an INTEGER_DOUBLY_LINKED_LIST.
     * The function accepts following parameters:
     *  1. INTEGER_DOUBLY_LINKED_LIST llist
     *  2. INTEGER data
     */

    /*
     * For your reference:
     *
     * DoublyLinkedListNode
     * {
     *     int data;
     *     DoublyLinkedListNode next;
     *     DoublyLinkedListNode prev;
     * }
     *
     */

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


}





