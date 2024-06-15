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

class Solution
{

    public class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }

    static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
    {
        while (node != null)
        {
            textWriter.Write(node.data);

            node = node.next;

            if (node != null)
            {
                textWriter.Write(sep);
            }
        }
    }

    // Complete the findMergeNode function below.

    /*
     * For your reference:
     *
     * SinglyLinkedListNode {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */
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


    // Helper function to advance a list by a given number of nodes
    private static SinglyLinkedListNode AdvanceListBy(SinglyLinkedListNode head, int count)
    {
        while (count > 0 && head != null)
        {
            head = head.next;
            count--;
        }
        return head;
    }

    static void PrintToConsole(SinglyLinkedListNode node, string sep = " ")
    {
        while (node != null)
        {
            Console.WriteLine(node.data);

            node = node.next;

        }
    }



}
