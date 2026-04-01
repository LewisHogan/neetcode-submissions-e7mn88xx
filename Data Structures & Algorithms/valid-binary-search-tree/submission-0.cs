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
    public bool IsValidBST(TreeNode root) {
        if (root is null) return true;

        return IsValid(root.left, int.MinValue, root.val) && IsValid(root.right, root.val, int.MaxValue);
    }

    private bool IsValid(TreeNode root, int minVal, int maxVal)
    {
        if (root is null) return true;
        // Exclusionary
        if (root.val <= minVal || root.val >= maxVal) return false;

        var isLeftOk = IsValid(root.left, minVal, root.val);
        var isRightOk = IsValid(root.right, root.val, maxVal);

        return isLeftOk && isRightOk;
    }
}
