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
        return DFS(root).Item1;
    }

    (bool, int) DFS(TreeNode root) {
        if (root == null) return (true, 0);

        var (leftBalanced, leftHeight) = DFS(root.left);
        var (rightBalanced, rightHeight) = DFS(root.right);

        var balanced = leftBalanced && rightBalanced && (Math.Abs(leftHeight - rightHeight) <= 1);
        var height = 1 + Math.Max(leftHeight, rightHeight);

        return (balanced, height);
    }
}
