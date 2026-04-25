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
    public List<int> InorderTraversal(TreeNode root) {
        // Morris traversal approach
        var current = root;
        var res = new List<int>();

        while (current != null)
        {
            if (current.left is null)
            {
                res.Add(current.val);
                current = current.right;
            }
            else
            {
                var prev = GetPrev(current);

                if (prev.right is null)
                {
                    prev.right = current;
                    current = current.left;
                }
                else
                {
                    prev.right = null;
                    res.Add(current.val);
                    current = current.right;
                }
            }
        }

        return res;
    }

    private TreeNode GetPrev(TreeNode root)
    {
        var prev = root.left;
        while (prev.right is not null && prev.right != root)
        {
            prev = prev.right;
        }
        
        return prev;
    }
}