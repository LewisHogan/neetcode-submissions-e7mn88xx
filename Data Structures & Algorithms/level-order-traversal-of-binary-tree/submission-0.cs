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
 
public class Solution {
    public List<List<int>> LevelOrder(TreeNode root) {
        if (root is null) return [];

        var queue = new Queue<TreeNode>();
        var results = new List<List<int>>();
        
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var count = queue.Count;
            var nodes = new List<int>();

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                nodes.Add(node.val);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            results.Add(nodes);
        }

        return results;
    }
}
