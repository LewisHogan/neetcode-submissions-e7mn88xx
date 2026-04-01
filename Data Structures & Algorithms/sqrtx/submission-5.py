import math

class Solution:
    def mySqrt(self, x: int) -> int:
        l, r = 0, x
        res = 0
        while l <= r:
            mid = l + (r - l) // 2
            val = mid * mid
            if val == x:
                return mid
            else:
                if val > x:
                    r = mid - 1
                else:
                    l = mid + 1
                    res = mid
        return res