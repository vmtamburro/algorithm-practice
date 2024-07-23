public class DetectCycleHalshSet{
    public class Node{
        public int val;
        public Node next;
        public Node(int x){
            val = x;
            next = null;
        }
    }   

    public bool HasCycle(Node head){
        HashSet<Node> nodesSeen = new HashSet<Node>();
        while(head != null){
            if(nodesSeen.Contains(head)){
                return true;
            }
            else{
                nodesSeen.Add(head);
            }
            head = head.next;
        }
        return false;
    }
}