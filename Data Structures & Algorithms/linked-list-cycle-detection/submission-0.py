# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next

class Solution:
    def hasCycle(self, head: Optional[ListNode]) -> bool:
        # Assuming each ListNode has a unique value
        visited_nodes = set()
        while head:
            if head.val in visited_nodes:
                return True
            if head.next is None:
                return False
            visited_nodes.add(head.val)
            head = head.next