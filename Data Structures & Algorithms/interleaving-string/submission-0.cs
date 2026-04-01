public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        if (s3.Length != (s1.Length + s2.Length)) return false;

        var cache = new bool?[s1.Length + 1, s2.Length + 1];

        return DFS(s1, s2, s3, 0, 0, cache);
    }

    private bool DFS(string s1, string s2, string s3, int i, int j, bool?[,] cache)
    {
        if (cache[i, j].HasValue) return cache[i, j].Value;

        var k = i + j;
        if (k == s3.Length) return i == s1.Length && j == s2.Length;

        if (i < s1.Length && s1[i] == s3[k] && DFS(s1, s2, s3, i + 1, j, cache))
        {
            cache[i, j] = true;
            return true;
        }

        if (j < s2.Length && s2[j] == s3[k] && DFS(s1, s2, s3, i, j + 1, cache))
        {
            cache[i, j] = true;
            return true;
        }

        cache[i, j] = false;
        return false;
    }
}
