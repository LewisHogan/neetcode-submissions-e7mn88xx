class Node:

    def __init__(self, key, value, left=None, right=None):
        self.key = key
        self.value = value
        self.left = left
        self.right = right

class LRUCache:

    def __init__(self, capacity: int):
        self.capacity = capacity
        self.cache = {}
        self.head = Node(0, 0)
        self.tail = Node(0, 0, self.head)
        self.head.right = self.tail

    def add_node(self, node: Node) -> None:
        # The tail is always a dummy node to simplify implementation
        self.tail.left.right = node
        node.left = self.tail.left
        self.tail.left = node
        node.right = self.tail

    def remove_node(self, node: Node) -> None:
        node.left.right = node.right
        node.right.left = node.left

    def get(self, key: int) -> int:
        if key in self.cache:
            node = self.cache[key]
            self.remove_node(node)
            self.add_node(node)
            return node.value
        else:
            return -1

    def put(self, key: int, value: int) -> None:
        if key in self.cache:
            self.remove_node(self.cache[key])
        self.cache[key] = Node(key, value)
        self.add_node(self.cache[key])

        if len(self.cache) > self.capacity:
            node_to_remove = self.head.right
            self.remove_node(self.head.right)
            del self.cache[node_to_remove.key]
