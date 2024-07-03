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


### Simple Insertion Example

1. **Insert 10:** Insert the first node. Since it's the only node it automatically becomes the root.
```markdown
     10 (Black)
```

2. **Insert 20:** Insert the next node, which is greater than the root (10).

```mathematica
     10 (Black)
        \
        20 (Red)
```


3. **Insert 30:** Insert the next node, which is greater than the root and its right child
```mathematica
     10 (Black)
        \
        20 (Red)
           \
           30 (Red)

```
The tree now violates the red-black property that red nodes cannot have red children, so we perform rotations and color flips.

* Perform a Left Rotation on node 10:
```mathematica
      20 (Black)
     /   \
10 (Red)  30 (Red)
```

* Flip colors of nodes 10 and 30
```mathematica
      20 (Black)
     /   \
10 (Black)  30 (Black)

```

4. **Insert 15**:  
Insert a node between existing nodes (10 and 20).

```mathematica
       20 (Black)
      /   \
 10 (Black)  30 (Black)
   \
   15 (Red)
```

The tree now has a red violation with node 15 and its parent, node 10 being red. Perform rotations and color flips to fix this.

- Perform a **Right Rotation** on node 20:
```mathematica
     10 (Black)
    /   \
15(Red)   20 (Black)
            \
            30 (Black)
```

- **Flip Colors** of nodes 10 and 20:

```mathematica
    10 (Black)
    /   \
15(Red)   20 (Red)
          \
           30 (Black)
```

#### Final Red-Black Tree Structure

After inserting nodes 10, 20, 30, and 15, the red-black tree structure looks like this:


```mathematica
       10 (Black)
      /   \
(Red)15   20 (Red)
           \
           30 (Black)
```

#### Time and Space Complexity

The time complexity of a Red-Black insertion is O(log n), and the space complexity is O(1)