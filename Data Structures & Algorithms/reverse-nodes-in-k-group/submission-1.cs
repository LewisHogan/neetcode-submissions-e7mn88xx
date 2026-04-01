/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        var dummy = new ListNode(-1, head);
        var nodeBeforeSub = dummy;

        while (true)
        {
            var kthNode = GetKthNode(nodeBeforeSub, k);
            if (kthNode is null) {
                break;
            }

            var nodeAfterSub = kthNode.next;

            // Reverse all nodes within the sublist
            // We set prev here to ensure we continue on with
            // the start of the next sublist
            var prev = nodeAfterSub;
            var current = nodeBeforeSub.next;
            while (current != nodeAfterSub)
            {
                var tmp = current.next;
                current.next = prev;
                prev = current;
                current = tmp;
            }
            
            // We need to make sure that the start of the list is pointing
            // at the correct node now (since the kth node is the start of each sublist)
            var tmpNode = nodeBeforeSub.next;
            nodeBeforeSub.next = kthNode;
            nodeBeforeSub = tmpNode;
        }

        return dummy.next;
    }

    private ListNode GetKthNode(ListNode current, int k)
    {
        while (current != null && k-- > 0) {
            current = current.next;
        }

        return current;
    }
}
