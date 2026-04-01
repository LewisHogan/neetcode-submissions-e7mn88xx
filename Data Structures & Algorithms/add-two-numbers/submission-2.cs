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
        var carry = 0;
        ListNode prev = null;

        var (largerNumber, smallerNumber) = GetNumbersBySize(l1, l2);
        var head = largerNumber;

        while (largerNumber != null) {
            if (smallerNumber != null) {
                var total = largerNumber.val + smallerNumber.val + carry;
                carry = total >= 10 ? 1 : 0;
                largerNumber.val = total % 10;
                
                smallerNumber = smallerNumber.next;
            } else {
                var total = largerNumber.val + carry;
                carry = total >= 10 ? 1 : 0;
                largerNumber.val = total % 10;
            }

            prev = largerNumber;
            largerNumber = largerNumber.next;
        }

        if (carry > 0) {
            prev.next = new ListNode(1);
        }

        return head;
    }

    public (ListNode largerNumber, ListNode smallerNumber) GetNumbersBySize(ListNode first, ListNode second) {
        if (Count(first) >= Count(second)) {
            return (first, second);
        }

        return (second, first);
    }

    private int Count(ListNode node) {
        var count = 0;
        while (node != null) {
            count++;
            node = node.next;
        }

        return count;
    }
}
