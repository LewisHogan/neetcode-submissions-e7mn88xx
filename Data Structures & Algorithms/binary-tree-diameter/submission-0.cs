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
    private int maxDiameter = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
        Diameter(root);
        return maxDiameter;
    }

    private int Diameter(TreeNode root)
    {
        // Calculate the max diameter assuming that we aren't the node connecting two branches together (e.g. we arent the route in the path)
        if (root is null) return 0;

        var leftDiameter = Diameter(root.left);
        var rightDiameter = Diameter(root.right);

        maxDiameter = Math.Max(maxDiameter, leftDiameter + rightDiameter);

        return 1 + Math.Max(leftDiameter, rightDiameter);
    }
}
