_Describe how you would implement a binary search tree (BST) and perform insertion and deletion operations. What is the time complexity for these operations?_

## Data Structure
- Node class
  - int value
  - Node left
  - Node right
  - Constructor to set Node value

## Insertion
  - Traverse the tree starting at the root
  - Is the value greater than the node value?
    - If so, traverse to the right
        - Is the right node null?
          - Attach the node right there
    - If not, traverse to the left
      - Is the left node null?
        - Attach the root right htere
  - Tree Balancing Operations? Assuming for now that the tree remains balanced.
  - Also assuming no duplicates on the BST.

## Deletion
- Traverse until you find the value you are looking for 
  - Similar logic as above
    - If we hit a leaf, throw an exception
- If we find the node, check if it has any children
  - Assign it's parent the left and/or right child
  - Might be a bit of operational complexity, but it may help us to backtrack easier if we also kept track of the parent node.