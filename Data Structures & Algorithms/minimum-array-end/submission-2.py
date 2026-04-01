class Solution:
    def minEnd(self, n: int, x: int) -> int:
        # if n is 3, then we have 0, 1, 10 in the bits of x
        # which are 0
        x_bitmask = 1
        n_bitmask = 1

        res = x
        while n_bitmask <= n - 1:
            if x_bitmask & x == 0:
                if n_bitmask & (n - 1):
                    res |= x_bitmask
                n_bitmask <<= 1
            x_bitmask <<= 1
        return res