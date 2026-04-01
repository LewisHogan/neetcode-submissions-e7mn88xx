public class Solution {
    public uint ReverseBits(uint n) {
        uint res = 0;

        for (var i = 0; i < 32; i++)
        {
            var bit = (n >> i) & 1;
            res |= (bit << 31 - i);
        }

        return res;
    }
}
