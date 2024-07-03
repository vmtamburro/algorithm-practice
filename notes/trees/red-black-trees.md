# Red-Black Trees

A red-black tree is a typpe of self-balancing binary search tree. Ensures that the tree remains approximately balanced, which guarantees that the operations (insert, delete, search) have logarithmic time complexity.

### Properties

1. **Nodes are Red or Black:** Each node is either red or black
2. **Root is Black:** The root of the tree is always black
3. **Red Nodes have Black Children:** Red nodes cannot have red children (i.e. no two red nodes can be adjacent)
4. **Black Height:** Every path from a node to its descendant NULL nodes must have the same number of black nodes
5. **New Nodes are Red:** When a new node is added to the tree, it is always reed initially.


### Operations

Red-black trees use a series of operations to maintain balance:

1. **Recoloring:** Changing the color of nodes to maintain the red-black properties
2. **Rotations:** Structural adjustments that change the arrangement of the tree. There are two types:
    * **Left Rotation:** Pivot a node and its right child
    * **Right Rotation:** Pivot a node and it's left child

### Insertion

When inserting a new node:

1. Insert it like a regular binary search tree node.
2. Color it red.
3. Fix any violations of the red-black properties by recoloring and performing rotations as necessary.


### Deletion

When deleting a node:

1. Perform the standard binary search tree deletion.
2. Fix any violations of the red-black properties by recoloring and performing rotations as necessary.

### Benefits
* Balanced Tree: The height of a red-black tree is O(log n), ensuring efficient operations.
* Predictable Performance: Operations like insertion, deletion, and search are all guaranteed to be O(log n).


### Example

Here's a simple example of a red-black tree:

```css
       B
     /   \
    R     R
   / \   / \
  B   B B   B

```

In this example, B stands for black nodes, and R stands for red nodes. Each path from the root to the leaves contains the same number of black nodes, and no red nodes are adjacent to each other.

### Use Cases

Red-black trees are used in various applications where balanced trees are needed, such as in the implementation of associative arrays (e.g., std::map in C++ and TreeMap in Java) and sets.
