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
    public List<int> PostorderTraversal(TreeNode root) {
        if (root is null) return [];
        
        var res = new List<int>();

        void Search(TreeNode current)
        {
            if (current.left is not null) Search(current.left);
            if (current.right is not null) Search(current.right);
            res.Add(current.val);
        }
        
        Search(root);

        return res;
    }
}