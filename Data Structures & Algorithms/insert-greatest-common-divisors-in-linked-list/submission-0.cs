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
    public ListNode InsertGreatestCommonDivisors(ListNode head) {
        var prev = head;
        var current = head.next;
        while (current != null)
        {
            // Look at the previous node and create the greatest common divider
            var min = Math.Min(prev.val, current.val);
            var max = Math.Max(prev.val, current.val);

            var gcd = GCD(max, min);
            prev.next = new ListNode(gcd, current);
            prev = current;
            current = current.next;
        }

        return head;
    }

    int GCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = a;
            a = b;
            b = temp % b;
        }

        return a;
    }
}