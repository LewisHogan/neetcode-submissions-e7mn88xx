# Definition for singly-linked list.
# class ListNode:
#     def __init__(self, val=0, next=None):
#         self.val = val
#         self.next = next

class Solution:

    def get_smallest(self, lists: List[Optional[ListNode]]) -> (int, Optional[ListNode]):
        smallest = None
        list_index = None

        for i, head_node in enumerate(lists):
            if smallest is None or (head_node and head_node.val < smallest.val):
                smallest = head_node
                list_index = i
        
        return (list_index, smallest)

    def mergeKLists(self, lists: List[Optional[ListNode]]) -> Optional[ListNode]:
        # Whenever we choose the smallest node, we want to update the head in lists[i]
        # where i is the index of that node
        (smallest_list_index, first_node) = self.get_smallest(lists)
        if smallest_list_index is None:
            return

        if lists[smallest_list_index]:
            lists[smallest_list_index] = lists[smallest_list_index].next

        current_node = first_node
        while current_node:
            smallest_list_index, next_node = self.get_smallest(lists)
            current_node.next = next_node
            
            if lists[smallest_list_index]:
                lists[smallest_list_index] = lists[smallest_list_index].next
            
            current_node = next_node
            
        return first_node