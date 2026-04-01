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
    public bool IsBalanced(TreeNode root) {
        if (root == null) return true;
        if (Math.Abs(GetDepth(root.left) - GetDepth(root.right)) > 1) return false;
        return IsBalanced(root.left) && IsBalanced(root.right);
    }

    private int GetDepth(TreeNode node) {
        if (node == null) return 0;
        return 1 + Math.Max(GetDepth(node.left), GetDepth(node.right));
    }
}
