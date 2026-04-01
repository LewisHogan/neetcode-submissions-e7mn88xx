public class Solution {
    public bool CheckValidString(string s) {
        var cache = new int[s.Length][];
        for (var i = 0; i < s.Length; i++)
        {
            cache[i] = new int[s.Length];
            Array.Fill(cache[i], -1);
        }
        return DFS(s, 0, 0, cache);
    }

    private bool DFS(string s, int i, int p, int[][] cache)
    {
        if (i >= s.Length) return p == 0;
        if (p < 0)
        {
            return false;
        }
        if (cache[i][p] != -1) return cache[i][p] == 1;

        var solution = false;

        switch (s[i])
        {
            case '(':
                solution = solution || DFS(s, i + 1, p + 1, cache);
                break;
            case ')':
                solution = solution || DFS(s, i + 1, p - 1, cache);
                break;
            default:
                solution = solution 
                    || DFS(s, i + 1, p + 1, cache)
                    || DFS(s, i + 1, p - 1, cache)
                    || DFS(s, i + 1, p, cache);
                break;
        }

        cache[i][p] = solution ? 1 : 0;
        return solution;
    }
}
