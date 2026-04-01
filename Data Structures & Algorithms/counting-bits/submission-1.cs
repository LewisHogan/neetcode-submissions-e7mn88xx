public class Solution {
    public int[] CountBits(int n) {
        var results = new int[n + 1];
        for (var i = 1; i <= n; i++)
        {
            results[i] = results[i >> 1] + (i & 1);
        }

        return results;
    }
}
