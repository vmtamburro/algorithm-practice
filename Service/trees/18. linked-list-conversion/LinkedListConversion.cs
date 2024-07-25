public class LinkedListConversion{
    public class TreeNode{
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int data) {
            this.val = data;
            this.left = null;
            this.right = null;
        }
    }

    public class ListNode{
        public int val;
        public ListNode next;
        public ListNode prev;
        public ListNode(int data){
            this.val = data;
            this.next = null;
            this.prev = null;
        }
    }

    public ListNode headNode = null;

    public void ConvertTreeToList(TreeNode root, ListNode prevNode = null){
        if(root == null){
            return;
        } 

        var current = new ListNode(root.val);

        // add the left node to the list
        ConvertTreeToList(root.left, current);


        // add the current node to the list (with link)
        if(prevNode != null){
            prevNode.next = current;
            current.prev = prevNode;
        } 
        else{ // we've traversed all the way to the bottom left node. This is the head of the list
            headNode = current;
        }

        // add the right node to the list
        ConvertTreeToList(root.right, current);
    }

    public ListNode GetHeadNode(){
        return this.headNode;
    }


}