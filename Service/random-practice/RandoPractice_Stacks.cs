public class RandoPractice_Stacks
{
    public class ArrayStack
    {
        private int[] items;
        private int top;
        private int maxSize;

        public ArrayStack(int size)
        {
            maxSize = size;
            items = new int[maxSize];
            top = -1;
        }

        public void Push(int value)
        {
            if (top == maxSize - 1)
            {
                throw new InvalidOperationException("Stack overflow");
            }
            items[++top] = value;
        }

        public int Pop()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Stack underflow");
            }
            return items[top--];
        }

        public int Peek()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return items[top];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }
    }

    public class ListNode
    {
        public int Value;
        public ListNode Next;

        public ListNode(int value)
        {
            Value = value;
            Next = null;
        }
    }

    public class LinkedListStack
    {
        private ListNode top;

        public void Push(int value)
        {
            ListNode newNode = new ListNode(value);
            newNode.Next = top;
            top = newNode;
        }

        public int Pop()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack underflow");
            }
            int value = top.Value;
            top = top.Next;
            return value;
        }

        public int Peek()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return top.Value;
        }

        public bool IsEmpty()
        {
            return top == null;
        }
    }





}