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
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        var dummy = new ListNode(-1, head);
        var beforeSublist = dummy;
        var current = head;

        // Stop at the node just before the start of the sublist
        // to reverse
        for (var i = 0; i < left - 1; i++)
        {
            beforeSublist = current;
            current = current.next;
        }
        
        ListNode prev = null;
        for (var i = 0; i < right - left + 1; i++)
        {
            var tmp = current.next;
            current.next = prev;
            prev = current;
            current = tmp;
        }
        
        // The last element in the sublist needs to point
        // at the element after the sublist, and since it's
        // reversed we can use .next.next
        beforeSublist.next.next = current;
        beforeSublist.next = prev;

        return dummy.next;
    }
}