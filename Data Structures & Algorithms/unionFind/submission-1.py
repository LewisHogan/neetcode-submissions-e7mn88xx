class UnionFind:
    
    def __init__(self, n: int):
        self.parents = { i:i for i in range(n) }
        self.components = n

    def find(self, x: int) -> int:
        rootX = self.parents[x]
        while rootX != self.parents[rootX]:
            rootX = self.parents[rootX]

        next = self.parents[x]
        while next != rootX:
            next, self.parents[next] = self.parents[next], rootX
        
        return rootX

    def isSameComponent(self, x: int, y: int) -> bool:
        return self.find(x) == self.find(y)

    def union(self, x: int, y: int) -> bool:
        if self.isSameComponent(x, y):
            return False
        
        rootX = self.find(x)
        
        while y != rootX:
            next = self.parents[y]
            self.parents[y] = rootX
            y = next
        
        self.components -= 1
        return True

    def getNumComponents(self) -> int:
        return self.components
