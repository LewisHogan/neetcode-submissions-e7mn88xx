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
    public int GoodNodes(TreeNode root) {
        return DFS(root, root.val);
    }

    private int DFS(TreeNode node, int maxValue)
    {
        if (node is null) return 0;

        var result = node.val >= maxValue ? 1 : 0;
        var max = Math.Max(node.val, maxValue);

        result += DFS(node.left, max);
        result += DFS(node.right, max);
        
        return result;
    }
}
