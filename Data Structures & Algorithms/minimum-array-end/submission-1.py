class Solution:
    def minEnd(self, n: int, x: int) -> int:
        # if n is 3, then we have 0, 1, 10 in the bits of x
        # which are 0

        def to_bit_array(i):
            bits = []
            while i != 0:
                bits.append(i & 1)
                i = i >> 1
            return bits

        n_bits = to_bit_array(n-1)
        x_bits = to_bit_array(x)

        j = 0
        for i in range(len(x_bits)):
            if x_bits[i] == 0:
                x_bits[i] = n_bits[j]
                j += 1
            
            if j == len(n_bits):
                break
        
        while j < len(n_bits):
            x_bits.append(n_bits[j])
            j += 1
        
        res = 0
        for i, bit in enumerate(x_bits):
            res += bit << i
        return res