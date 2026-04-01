public class Solution {
    public List<string> WordBreak(string s, List<string> wordDict) {
        var results = new List<string>();
        DFS(s, 0, new(wordDict), [], results);
        return results;
    }

    void DFS(string s, int start, HashSet<string> words, List<string> current, List<string> results)
    {
        if (start == s.Length)
        {
            results.Add(string.Join(" ", current));
        }

        for (var end = start + 1; end <= s.Length; end++)
        {
            if (words.Contains(s[start..end]))
            {
                DFS(s, end, words, [..current, s[start..end]], results);
            }
        }
    }
}