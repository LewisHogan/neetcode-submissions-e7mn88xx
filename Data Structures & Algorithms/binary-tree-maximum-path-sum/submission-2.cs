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

    private int bestSum = int.MinValue;

    public int MaxPathSum(TreeNode root) {
        DFS(root);
        return bestSum;
    }

    private int DFS(TreeNode root)
    {
        if (root == null) return 0;

        var leftMax = DFS(root.left);
        var rightMax = DFS(root.right);

        // Sum assumes the current node is not the parent
        // all non-parent nodes will only have one edge
        // connecting them as otherwise they would need
        // to be visited twice (up and down)
        var sum = Math.Max(0, root.val + Math.Max(leftMax, rightMax));

        // Best sum assumes the current node is the parent, which
        // means it can reach the left and right subtree (up through one, down through the other)
        bestSum = Math.Max(bestSum, root.val + leftMax + rightMax);
        return sum;
    }
}
