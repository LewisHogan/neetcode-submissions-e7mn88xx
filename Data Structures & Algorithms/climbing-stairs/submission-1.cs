public class Solution {
    public int ClimbStairs(int n) {     
        var cache = new int?[n];
        return DFS(0, n, cache);
    }

    private int DFS(int step, int n, int?[] cache)
    {
        if (step > n) return 0;
        if (step == n) return 1;

        if (cache[step].HasValue) return cache[step].Value;

        var total = DFS(step + 1, n, cache);
        total += DFS(step + 2, n, cache);

        cache[step] = total;
        return total;
    }
}
