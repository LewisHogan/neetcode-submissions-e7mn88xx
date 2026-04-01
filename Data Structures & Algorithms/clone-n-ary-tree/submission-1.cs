/*
// Definition for a Node.
public class Node {
    public int val;
    public List<Node> children;

    public Node() {
        children = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new List<Node>();
    }

    public Node(int _val, List<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public Node CloneTree(Node root) {
        if (root is null) return null;

        var queue = new Queue<(Node, Node)>();

        var newRoot = new Node(root.val);

        queue.Enqueue((root, newRoot));

        while (queue.Count > 0)
        {
            var (originalNode, node) = queue.Dequeue();

            foreach (var child in originalNode.children)
            {
                var newChild = new Node(child.val);
                node.children.Add(newChild);
                queue.Enqueue((child, newChild));
            }
        }

        return newRoot;
    }
}
