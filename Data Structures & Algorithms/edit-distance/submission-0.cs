public class Solution {
    public int MinDistance(string word1, string word2) {
        var cache = new Dictionary<(int, int), int>();
        return DFS(0, 0, word1, word2, cache);
    }

    private int DFS(int i, int j, string word1, string word2, Dictionary<(int, int), int> cache)
    {
        if (cache.ContainsKey((i, j))) return cache[(i, j)];

        if (i == word1.Length) return word2.Length - j;
        if (j == word2.Length) return word1.Length - i;

        if (word1[i] == word2[j])
        {
            cache[(i, j)] = DFS(i + 1, j + 1, word1, word2, cache);
            return cache[(i, j)];
        }
        else
        {
            // We need to replace, remove or insert

            // Assume we replace the current char in word1 with the matching one from word2
            var replaceTotal = DFS(i + 1, j + 1, word1, word2, cache);
            // Assume we delete a char to make them match, shrinking word1 by one
            var removeTotal = DFS(i + 1, j, word1, word2, cache);
            var insertTotal = DFS(i, j + 1, word1, word2, cache);

            cache[(i, j)] = 1 + Math.Min(replaceTotal, Math.Min(removeTotal, insertTotal));
            return cache[(i, j)];
        }
    }
}
