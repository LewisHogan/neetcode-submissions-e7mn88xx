public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        var cache = new int?[text1.Length, text2.Length];
        return DFS(text1, text2, 0, 0, cache);
    }

    private int DFS(string text1, string text2, int i, int j, int?[,] cache)
    {
        if (i > text1.Length - 1 || j > text2.Length - 1) return 0;
        if (cache[i, j].HasValue) return cache[i, j].Value;

        var res = 0;
        if (text1[i] == text2[j])
        {
            res = 1 + DFS(text1, text2, i + 1, j + 1, cache);
        }
        else
        {
            res = Math.Max(
                DFS(text1, text2, i + 1, j, cache),
                DFS(text1, text2, i, j + 1, cache)
            );
        }

        cache[i, j] = res;
        return res;
    }
}
