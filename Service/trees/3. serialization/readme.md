###  Serialize and Deserialize a Binary Tree

#### Problem Statement:

Design an algorithm to serialize and deserialize a binary tree. Serialization is the process of converting a tree into a string representation. Deserialization is the process of converting a string representation back into a tree.

You should implement the following methods:

1. `string Serialize(TreeNode root)`: Serializes a binary tree to a string.
2. `TreeNode Deserialize(string data)`: Deserializes a string back to a binary tree.

#### Example:

Given the following binary tree:

```
    1
   / \
  2   3
     / \
    4   5
```

- The serialized string representation might be: `"1,2,#,#,3,4,#,#,5,#,#"`
  - Here, `#` represents a null node, and commas separate the values.
  
- Deserializing the string `"1,2,#,#,3,4,#,#,5,#,#"` should reconstruct the original tree.

#### Constraints:

- You may use any valid string representation and decompose methods for the tree as long as you can serialize and deserialize consistently.
- Assume that the input string for deserialization is always valid.

#### Tips:

- Use pre-order traversal to serialize the tree.
- During deserialization, use a queue or iterator to reconstruct the tree efficiently.

---


### Explanation:

1. **TreeNode Class**: Represents a node in the binary tree.
2. **Serialize Method**:
   - Uses a `StringBuilder` to efficiently build the string representation of the tree.
   - Performs a pre-order traversal to serialize the tree, appending node values and `#` for null nodes.
3. **Deserialize Method**:
   - Splits the input string into a queue of node values.
   - Recursively reconstructs the tree using a helper method and the queue to keep track of the current position in the input string.
4. **Main Method**: Demonstrates the usage of the `Serialize` and `Deserialize` methods with example inputs and outputs.

### Complexity:

- **Time Complexity**: O(n), where n is the number of nodes in the tree, as each node is processed once during both serialization and deserialization.
- **Space Complexity**: O(n) for the recursive call stack and the storage of the serialized string and queue.

