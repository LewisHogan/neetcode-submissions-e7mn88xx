class DSU:

    def __init__(self, equations: List[List[str]], values: List[float]):
        self.parent = {}
        self.weight = {}
        
        for (a, b), value in zip(equations, values):
            self.add(a)
            self.add(b)
            self.union(a, b, value)        
    
    def add(self, a):
        if a not in self.parent:
            self.parent[a] = a
            self.weight[a] = 1
    
    def find(self, a):
        if a not in self.parent:
            return None
        
        if a != self.parent[a]:
            parent = self.parent[a]
            self.parent[a] = self.find(parent)
            self.weight[a] *= self.weight[parent]
        return self.parent[a]

    def union(self, a, b, value):
        root_a = self.find(a)
        root_b = self.find(b)

        if root_a != root_b:
            self.parent[root_a] = root_b
            self.weight[root_a] = value * (self.weight[b] / self.weight[a])
    
    def query(self, a, b):
        if (
            a not in self.parent or b not in self.parent 
            or self.find(a) != self.find(b)
        ):
            return -1
        
        return self.weight[a] / self.weight[b]
        

class Solution:
    def calcEquation(self, equations: List[List[str]], values: List[float], queries: List[List[str]]) -> List[float]:
        dsu = DSU(equations, values)
        return [dsu.query(q1, q2) for [q1, q2] in queries]