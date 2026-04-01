public class Solution {
    public bool IsMatch(string s, string p) {
        return DFS(s, p, 0, 0, new bool?[s.Length + 1, p.Length + 1]);
    }

    bool DFS(string s, string p, int i, int j, bool?[,] cache)
    {
        if (cache[i, j].HasValue) return cache[i, j].Value;
        if (j == p.Length) return i == s.Length;

        bool firstMatch = i < s.Length && (s[i] == p[j] || p[j] == '.');

        if (j + 1 < p.Length && p[j + 1] == '*')
        {
            cache[i, j] = DFS(s, p, i, j + 2, cache) || (firstMatch && DFS(s, p, i + 1, j, cache));
        }
        else
        {
            cache[i, j] = firstMatch && DFS(s, p, i + 1, j + 1, cache);
        }

        return cache[i, j].Value;
    }
}