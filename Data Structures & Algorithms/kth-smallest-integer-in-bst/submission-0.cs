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
    int visited = 0;
    int result = 0;
    public int KthSmallest(TreeNode root, int k) {
        visited = 0;
        result = 0;
        DFS(root, k - 1);
        return result;
    }

    private void DFS(TreeNode node, int k)
    {
        if (node == null) return;
        DFS(node.left, k);
        if (visited++ == k) {
            result = node.val;
            return;
        }

        DFS(node.right, k);
    }
}
