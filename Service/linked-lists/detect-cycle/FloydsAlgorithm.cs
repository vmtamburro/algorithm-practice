public class CycleDetectionFloyd{
    public class Node{
        public int val;
        public Node next;
        public Node(int x){
            val = x;
            next = null;
        }
    }

    public bool HasCycle(Node head){
        if(head == null || head.next == null){
            return false;
        }

        Node slow = head;
        Node fast = head.next;

        while(slow != fast){
            if(fast == null || fast.next == null){
                return false; // no cycle detected
            }
            slow = slow.next;
            fast = fast.next.next;
        }
        return true;
    }
}