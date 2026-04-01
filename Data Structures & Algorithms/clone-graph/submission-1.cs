/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node is null) return null;
        var nodeIntMap = BFS(node, out var nodeCount);

        var nodes = Enumerable
            .Range(0, nodeCount)
            .Select(i => new Node(i + 1))
            .ToArray();

        Array.ForEach(nodes, n => {
            n.neighbors = nodeIntMap[n.val].Select(i => nodes[i-1]).ToList();
        });

        return nodes[node.val - 1];

    }

    private Dictionary<int, List<int>> BFS(Node node, out int nodeCount)
    {
        var nodes = new Dictionary<int, List<int>>();

        var queue = new Queue<Node>();
        queue.Enqueue(node);

        nodeCount = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            
            if (!nodes.ContainsKey(current.val))
            {
                nodes[current.val] = new List<int>();
                nodeCount++;
                foreach (var neighbor in current.neighbors)
                {
                    nodes[current.val].Add(neighbor.val);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return nodes;
    }
}
