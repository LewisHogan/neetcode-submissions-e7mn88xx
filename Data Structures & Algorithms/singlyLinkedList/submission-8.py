class Node:
    def __init__(self, val=None):
        self.val = val
        self.next = None

class LinkedList:
    
    def __init__(self):
        self.head = Node() # dummy node
        self.tail = self.head
    
    def get(self, index: int) -> int:
        node = self.head.next
        while index > 0:
            node = node.next if node else None
            index -= 1
        return node.val if node else -1

    def insertHead(self, val: int) -> None:
        node = Node(val)
        node.next = self.head.next
        self.head.next = node
        if not node.next:
            self.tail = node

    def insertTail(self, val: int) -> None:
        node = Node(val)
        self.tail.next = node
        self.tail = node

    def remove(self, index: int) -> bool:
        i = 0
        node = self.head
        while i < index and node:
            i += 1
            node = node.next
        
        if node and node.next:
            if node.next == self.tail:
                self.tail = node
            node.next = node.next.next
            return True
        return False
        

    def getValues(self) -> List[int]:
        vals = []
        node = self.head.next
        while node:
            vals.append(node.val)
            node = node.next
        return vals
