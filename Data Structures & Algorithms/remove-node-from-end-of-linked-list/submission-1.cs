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
        var current = head;

        var listLength = 0;
        while (current != null) {
            listLength++;
            current = current.next;
        }

        if (listLength == 1) return null;

        ListNode prev = null;
        current = head;
        var currentIndex = 0;
        while (current != null) {

            if (currentIndex == listLength - n) {
                if (prev == null) {
                    head = head.next;
                } else {
                    prev.next = current.next;
                }
                
                return head;
            }

            currentIndex++;
            prev = current;
            current = current.next;
        }

        return head;
    }
}
