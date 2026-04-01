public class Solution {
    public int ClimbStairs(int n) {     
        if (n <= 0) return 0;
        if (n == 1) return 1;
        if (n == 2) return 2;

        var cache = new Dictionary<int, int>()
        {
            {0, 0},
            {1, 1},
            {2, 2}
        };

        return ClimbStairs(cache, n-1) + ClimbStairs(cache, n-2);
    }

    private int ClimbStairs(Dictionary<int, int> cache, int n) {
        if (cache.ContainsKey(n)) return cache[n];

        var result = ClimbStairs(cache, n-2) + ClimbStairs(cache, n-1);
        cache[n] = result;
        return result;
    }
}
