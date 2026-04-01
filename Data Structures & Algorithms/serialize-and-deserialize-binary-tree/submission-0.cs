/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        var output = new StringBuilder();
        var queue = new Queue<TreeNode>();

        if (root is null) return "null";

        output.Append(root.val.ToString());
        queue.Enqueue(root.left);
        queue.Enqueue(root.right);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node is null)
            {
                output.Append(",null");
            }
            else
            {
                output.Append("," + node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

        }

        Console.WriteLine(output.ToString());

        return output.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        if (data is null || data == ""|| data.StartsWith("null")) return null;
        var nodes = data.Split(',');

        var i = 0;
        TreeNode root = new TreeNode(int.Parse(nodes[i]));
        i++;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current != null)
            {
                current.left = nodes[i] == "null" ? null : new TreeNode(int.Parse(nodes[i]));
                i++;
                current.right = nodes[i] == "null" ? null : new TreeNode(int.Parse(nodes[i]));
                i++;
                queue.Enqueue(current.left);
                queue.Enqueue(current.right);
            }
        }

        return root;
    }
}
