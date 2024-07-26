public class RandoPractice_LinkedList{
    public class ListNode{
        public int val;
        public ListNode next;
        public ListNode(int value){
            this.val = value;
            this.next = null;
        }
    }

    public class SinglyLinkedList{
        private ListNode head;
        public void Insert(int value){
            ListNode newNode = new ListNode(value);
            newNode.next = head;
            head = newNode;
        }

        public void Delete(int value){
            if(head == null) return;

            if(head.val == value){
                head = head.next;
                return;
            }

            ListNode current = head;

            while(current.next != null && current.next.val != value){
                current = current.next;
            }

            if(current.next != null){
                current.next = current.next.next;
            }

        }

        public void Traverse(){
            ListNode current = head;
            while(current != null){
                Console.WriteLine(current.val);
                current = current.next;
            }

            Console.WriteLine();
        }

        public bool DetectCycle(){
            ListNode slow = head;
            ListNode fast = head;

            while(fast != null && fast.next != null){
                slow = slow.next;
                fast = fast.next.next;

                if(slow == fast){
                    return true;
                }
            }  

            return false; 
        }
    }
}