class Solution:
    def myPow(self, x: float, n: int) -> float:
        if n == 0:
            return 1
        
        if n == 1:
            return x

        res = 1
        for i in range(abs(n)):
            res = res * x
        
        return 1 / res if n < 0 else res