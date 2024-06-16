public class ListOfDepths{
    public class Node{
        public Node Left;
        public Node Right;
        public int Value;
        public Node(int value){
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }

    /*
        Given a binary tree, design an algorithm which creates
        a list of a list of all the nodes at each depth.
    */
    public void CreateLevelLinkedList(Node root, List<List<Node>> lists, int level){
        if(root == null) return;
        
        List<Node> list = null;
        if(lists.Count() == level){ // level is not yet on the list
            list = new List<Node>();
            lists.Add(list);
        }
        else{
            list = lists[level];
        }

        list.Add(root);
        CreateLevelLinkedList(root.Left, lists, level + 1);
        CreateLevelLinkedList(root.Right, lists, level + 1);
    }

    public List<List<Node>> Create(Node root){
        var lists = new List<List<Node>>();
        CreateLevelLinkedList(root, lists, 0);
        return lists;
    }
}