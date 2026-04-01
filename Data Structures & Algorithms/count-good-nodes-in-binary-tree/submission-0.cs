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
    private int goodNodes = 0;

    public int GoodNodes(TreeNode root) {
        if (root is null) return 0;

        CountGoodNodes(root, root.val);
        return goodNodes;
    }

    private void CountGoodNodes(TreeNode node, int maxValue)
    {
        if (node is null) return;
        if (maxValue <= node.val)
        {
            goodNodes++;
        }

        CountGoodNodes(node.left, Math.Max(maxValue, node.val));
        CountGoodNodes(node.right, Math.Max(maxValue, node.val));
    }
}
