using Example;

public class LCA{
    /*
        -  Take a root of BST and two nodes `p` and `q`
        - Return the LCA of the two nodes.
        - Example below Root, 7, and 9

        6
       / \
      2   8
     / \ / \
    0  4 7  9
      / \
     3   5

        - Get the max of the two nodes (9)
        - Traverse to that Value (9) - keep previous node handy ** Stack for visited nodes?
        - Reverse Traversal one step (8)
            - Is it the lower node?
                - No
            - Is it greater than the other node? 
                - Yes - Make LCA for now
                - Traverse Left
                    - Is it the Lower Node?
                        - Yes -> prev node is LCA


        - Another input 5, 0.
        - Get the max of the two (5)
        - Traverse to that Value (5) 
        - Reverse Traversal one step (4)
            - Is it the lower node?
                - No
            - Is it greater than the other node?
                - Yes - Make LCA for now
                - Traverse Left
                    - Is it the lower node?
                    - This is getting messy... re-approach


        - Start at the root
        - Are both values greater than the root?
            - Traverse right
        - Are both values less than the rot?
            - Traverse Left
        - Else
            - Return this node. We've had a divergence.


        ** Handle edge case where one or the other value doesn't exist.
    */
}