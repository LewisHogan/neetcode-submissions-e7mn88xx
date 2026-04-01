class DynamicArray:
    
    def __init__(self, capacity: int):
        self.capacity = capacity
        self.size = 0
        self.items = {}

    def get(self, i: int) -> int:
        return self.items[i]

    def insert(self, i: int, n: int) -> None:
        self.items[i] = n

    def set(self, i: int, n: int) -> None:
        self.insert(i, n)

    def pushback(self, n: int) -> None:
        if self.size == self.capacity:
            self.resize()
        self.insert(self.size, n)
        self.size += 1

    def popback(self) -> int:
        n = self.items[self.size-1]
        self.size -= 1
        return n

    def resize(self) -> None:
        self.capacity *= 2

    def getSize(self) -> int:
        return self.size
    
    def getCapacity(self) -> int:
        return self.capacity
