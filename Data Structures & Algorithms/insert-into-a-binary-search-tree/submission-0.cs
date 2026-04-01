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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root is null) return new TreeNode(val);

        var nodeToInsert = new TreeNode(val);
        
        var node = FindParent(root, val);
        if (node.val < val) node.right = nodeToInsert;
        else node.left = nodeToInsert;

        return root;
    }

    TreeNode FindParent(TreeNode root, int target)
    {
        var current = root;
        if (current.val > target && current.left is not null)
        {
            return FindParent(current.left, target);
        }
        else if (current.val < target && current.right is not null)
        {
            return FindParent(current.right, target);
        }

        return current;
    }
}