import math

class Solution:
    def mySqrt(self, x: int) -> int:
        if x == 0: return 0
        if x == 1: return 1

        for left in range(1, x):
            y = left * left
            if y == x:
                return left
            elif y >= x:
                return left-1