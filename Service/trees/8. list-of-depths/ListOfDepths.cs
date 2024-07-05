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


    // BFS Alternative
    public List<List<Node>> AlternateCreate(Node root){
        var lists = new List<List<Node>>();
        var current = new List<Node>();
        if(root != null){
            current.Add(root);
        }
        while(current.Count() > 0){
            lists.Add(current); // add previous level
            List<Node> parents = current; // reset current to next level
            current = new List<Node>();
            foreach(var parent in parents){ // loop through this new level, find all left and right nodes
                if(parent.Left != null){
                    current.Add(parent.Left);
                }

                if(parent.Right != null){
                    current.Add(parent.Right);
                }
            }
        }

        return lists;
    }
}

/* 
    Both algorithms require O(N) where N is the number of nodes in the Binary Tree.
    It is only processed once

    Space complexity for the first solution is O(logN) due to recursive calls on the call stack.
    The second has a space complexity of O(N) where all nodes are stored.
*/