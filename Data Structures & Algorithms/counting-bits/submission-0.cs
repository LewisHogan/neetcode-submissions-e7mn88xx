public class Solution {
    public int[] CountBits(int n) {
        var results = new int[n + 1];
        for (var i = 0; i <= n; i++)
        {
            var value = i;
            var count = 0;
            while (value != 0)
            {
                if ((value & 1) != 0) count++;
                value = value >> 1;
            }
            results[i] = count;
        }

        return results;
    }
}
