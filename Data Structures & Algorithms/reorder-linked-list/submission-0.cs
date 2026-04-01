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
    public void ReorderList(ListNode head) {
        // Reversing a list and interleaving it with the other list
        // O(1) space so we can't make a copy of the list in reverse order
        if (head == null || head.next == null) return;
        
        // We could just use the reference to head but it's more clear this way
        var (firstList, secondList) = PartitionAtMiddle(head);
        secondList = ReverseList(secondList);

        // Iterate through the first list, inserting the head of the
        // second list as we go along
        var current = firstList;
        while (current != null && secondList != null) {
            var next = current.next;
            var secondListNext = secondList.next;
            current.next = secondList;
            secondList.next = next;
            secondList = secondListNext;
            current = next;
        }
    }

    private ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        var current = head;
        while (current != null) {
            var next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }

    // Find the middle of the linked list and partition it into two lists,
    // with the original list at head ending before at middle node.
    // the returned node is the start of the second list.
    private (ListNode firstList, ListNode secondList) PartitionAtMiddle(ListNode head) {
        var slow = head;
        var fast = head;
        while (fast != null && fast.next != null && fast.next.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        var startOfNextList = slow.next;
        // Disconnect the lists
        slow.next = null;

        return (head, startOfNextList);
    }
}
