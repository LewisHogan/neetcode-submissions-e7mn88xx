from functools import cache

class DSU:
    def __init__(self, nums: List[int]):
        self.parents = [i for i in range(len(nums))]
        self.components = len(self.parents)
    
    def find(self, x):
        while x != self.parents[x]:
            temp = x
            x = self.parents[x]
            self.parents[temp] = self.parents[x]
        return self.parents[x]
    
    def union(self, u, v) -> bool:
        if self.find(u) == self.find(v):
            return False
        
        rootU = self.find(u)
        rootV = self.find(v)
        self.parents[rootV] = rootU
        self.components -= 1
        return True

class Solution:
    def canTraverseAllPairs(self, nums: List[int]) -> bool:
        @cache
        def gcd(a, b):
            if a % b == 0:
                return b
            return gcd(b, a % b)

        dsu = DSU(nums)
        for i in range(len(nums)):
            for j in range(i + 1, len(nums)):
                a = max(nums[i], nums[j])
                b = min(nums[i], nums[j])
                if gcd(a, b) > 1:
                    dsu.union(i, j)

        return dsu.components == 1