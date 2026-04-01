class Node:
    def __init__(self, val=None):
        self.val = val
        self.next = None
        self.prev = None

    def __str__(self):
        return f"{self.val} -> {self.next}"

class Deque:
    
    def __init__(self):
        self.head = Node()
        self.tail = Node()
        self.head.next = self.tail
        self.tail.prev = self.head

    def isEmpty(self) -> bool:
        return self.head.next == self.tail

    def append(self, value: int) -> None:
        node = Node(value)
        node.prev = self.tail.prev
        node.next = self.tail
        self.tail.prev.next = node
        self.tail.prev = node

    def appendleft(self, value: int) -> None:
        node = Node(value)
        node.prev = self.head
        node.next = self.head.next
        self.head.next.prev = node
        self.head.next = node

    def pop(self) -> int:
        if self.isEmpty():
            return -1
        
        node = self.tail.prev
        node.prev.next = node.next
        node.next.prev = node.prev

        return node.val
        

    def popleft(self) -> int:
        if self.isEmpty():
            return -1
        
        node = self.head.next
        node.next.prev = node.prev
        node.prev.next = node.next
        
        return node.val
