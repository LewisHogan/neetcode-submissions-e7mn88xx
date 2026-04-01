public class Solution {
    public int NumDecodings(string s) {
        // DFS, if it starts with a 0 we don't need to explore the possibility of that one
        var cache = new Dictionary<int, int>();
        return DFS(s, 0, cache);
    }

    private int DFS(string s, int i, Dictionary<int, int> cache)
    {
        if (i == s.Length) return 1;
        if (s[i] == '0') return 0;
        if (cache.ContainsKey(i)) return cache[i];

        var combos = DFS(s, i + 1, cache);
        if (i < s.Length - 1)
        {
            if (s[i] == '1' || s[i] <= '2' && s[i + 1] <= '6')
            {
                combos += DFS(s, i + 2, cache);
            }
        }

        cache[i] = combos;
        return combos;
    }
}
