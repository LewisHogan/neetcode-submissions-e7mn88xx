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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if (subRoot is null) return true;
        if (root is null) return false;

        if (CheckEqual(root, subRoot)) return true;

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool CheckEqual(TreeNode root, TreeNode subRoot)
    {
        if (root is null && subRoot is null) return true;
        if (root is null || subRoot is null) return false;

        if (root.val != subRoot.val) return false;

        return 
            CheckEqual(root.left, subRoot.left)
            && CheckEqual(root.right, subRoot.right);
    }
}
