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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if (preorder.Length == 0 || inorder.Length == 0) return null;

        var root = new TreeNode(preorder[0]);

        // The first element in preorder is always the root of our tree
        // The next element is the root of the left subtree
        // And assuming it has a value and is not a null, the next is the root of the left subtree of that subtree and so on
        // This means that the root of the right subtree is actually 1 element after the mid point of the preorder array

        // Once we've found the index in the inorder array (mid)
        // it means that the entire left half 0..mid will be on the left half of the tree from the root and mid+1..length will be the right half
        // and if we take that first half and pass it recursively, we can keep narrowing down the leftmost half until we have the leftmost child 

        // Console.WriteLine("P: " + string.Join(",", preorder));
        // Console.WriteLine("I: " + string.Join(",", inorder));
        // Console.WriteLine();
        
        var mid = Array.IndexOf(inorder, root.val);
        root.left = BuildTree(preorder.Skip(1).Take(mid).ToArray(), inorder.Take(mid).ToArray());
        root.right = BuildTree(preorder.Skip(mid + 1).ToArray(), inorder.Skip(mid + 1).ToArray());

        return root;
    }
}
