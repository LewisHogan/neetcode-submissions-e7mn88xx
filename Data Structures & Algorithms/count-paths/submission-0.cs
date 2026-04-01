public class Solution {

    public int UniquePaths(int m, int n) {
        return DFS(0, 0, m, n, new int?[m, n]);
    }

    private int DFS(int r, int c, int m, int n, int?[,] cache)
    {
        if (r == m - 1 && c == n - 1) return 1;
        if (cache[r, c].HasValue) return cache[r, c].Value;

        var total = 0;
        if (r < m -1)
        {
            total += DFS(r + 1, c, m, n, cache);
        }

        if (c < n - 1)
        {
            total += DFS(r, c + 1, m, n, cache);
        }

        cache[r, c] = total;
        return total;
    }
}
