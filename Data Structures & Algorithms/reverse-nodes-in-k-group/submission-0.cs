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
        ListNode pointerToFirstNode = null;

        var nodeBeforeSublist = new ListNode(-1, head);
        ListNode nodeAfterSublist = null;

        while (GetSublist(nodeBeforeSublist.next, k, out var sublistHead, out var sublistTail))
        {
            nodeAfterSublist = sublistTail.next;

            ReverseSublist(sublistHead, k);

            nodeBeforeSublist.next = sublistTail;
            sublistHead.next = nodeAfterSublist;
            nodeBeforeSublist = sublistHead;

            if (pointerToFirstNode is null)
            {
                pointerToFirstNode = sublistTail;
            }
        }

        return pointerToFirstNode;
    }

    private void ReverseSublist(ListNode head, int k) {
        ListNode prev = null;
        var current = head;
        while (k-- > 0) {
            var tmp = current.next;
            current.next = prev;
            prev = current;
            current = tmp;
        }
    }

    private bool GetSublist(ListNode head, int k, out ListNode sublistHead, out ListNode sublistTail)
    {
        sublistHead = head;
        sublistTail = head;
        var nodesInSublist = 1;

        while (nodesInSublist < k && sublistTail != null)
        {
            sublistTail = sublistTail.next;
            nodesInSublist++;
        }

        return nodesInSublist == k && sublistTail != null;
    }
}
