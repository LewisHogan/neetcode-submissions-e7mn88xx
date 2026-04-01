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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var dummy = new ListNode();
        
        var current = dummy;
        var carry = 0;
        while (l1 != null || l2 != null || carry != 0) {
            var l1Val = l1?.val ?? 0;
            var l2Val = l2?.val ?? 0;

            var total = l1Val + l2Val + carry;
            carry = total >= 10 ? 1 : 0;
            current.next = new ListNode(total % 10);

            current = current.next;
            l1 = l1?.next;
            l2 = l2?.next;
        }

        return dummy.next;
    }
}
