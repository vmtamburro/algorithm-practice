public class RandoPractice_DoublyLinkedList
{
    public class DoublyListNode
    {
        public int Value;
        public DoublyListNode Next;
        public DoublyListNode Prev;

        public DoublyListNode(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }


    public class DoublyLinkedList
    {
        private DoublyListNode head;

        public void Insert(int value)
        {
            DoublyListNode newNode = new DoublyListNode(value);
            if (head != null)
            {
                head.Prev = newNode;
            }
            newNode.Next = head;
            head = newNode;
        }

        public void Delete(int value)
        {
            DoublyListNode current = head;
            while (current != null && current.Value != value)
            {
                current = current.Next;
            }

            if (current == null) return;

            if (current.Prev != null)
            {
                current.Prev.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Prev = current.Prev;
            }
        }

        public void Traverse()
        {
            DoublyListNode current = head;
            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public bool DetectCycle()
        {
            DoublyListNode slow = head;
            DoublyListNode fast = head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }
    }

}