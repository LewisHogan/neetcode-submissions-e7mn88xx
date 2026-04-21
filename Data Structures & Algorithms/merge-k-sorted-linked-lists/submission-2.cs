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
    public ListNode MergeKLists(ListNode[] lists) {
        var queue = new PriorityQueue<ListNode, int>();

        for (var i = 0; i < lists.Length; i++)
        {
            if (lists[i] is not null)
            {
                queue.Enqueue(lists[i], lists[i].val);
                lists[i] = lists[i].next;
            }
        }

        ListNode head = null;
        ListNode current = head;

        while (queue.Count != 0)
        {
            if (head is null)
            {
                head = queue.Dequeue();
                current = head;
            }
            else
            {
                current.next = queue.Dequeue();
                current = current.next;
            }

            if (current.next is not null)
            {
                queue.Enqueue(current.next, current.next.val);
            }
        }

        return head;
    }
}
