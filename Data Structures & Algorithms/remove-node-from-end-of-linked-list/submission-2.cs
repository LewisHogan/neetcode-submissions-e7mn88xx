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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var dummy = new ListNode(-1, head);
        var remove = dummy;
        var current = head;
        while (n-- > 0) {
            current = current.next;
        }

        while (current != null) {
            current = current.next;
            remove = remove.next;
        }

        remove.next = remove.next.next;

        return dummy.next;
    }
}
