class Node:
    def __init__(self, val, prev=None, next=None):
        self.val = val
        self.prev = prev
        self.next = next

class Deque:
    
    def __init__(self):
        self.head = Node(0)
        self.tail = Node(0)
        self.head.next = self.tail
        self.tail.prev = self.head

    def isEmpty(self) -> bool:
        return self.head.next == self.tail

    def append(self, value: int) -> None:
        node = Node(value, prev=self.tail.prev, next=self.tail)
        node.prev.next = node
        self.tail.prev = node

    def appendleft(self, value: int) -> None:
        node = Node(value, prev=self.head, next=self.head.next)
        self.head.next = node
        node.next.prev = node

    def pop(self) -> int:
        if self.isEmpty():
            return -1
        
        node = self.tail.prev
        node.prev.next = self.tail
        self.tail.prev = node.prev
        return node.val

    def popleft(self) -> int:
        if self.isEmpty():
            return -1
        
        node = self.head.next
        node.next.prev = self.head
        self.head.next = node.next
        return node.val
