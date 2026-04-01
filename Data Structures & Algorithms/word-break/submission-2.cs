public class Solution {
    public bool WordBreak(string s, List<string> wordDict) {
        return DFS(s, 0, wordDict.OrderBy(w => w.Length).ToList(), new bool?[s.Length]);
    }

    private bool DFS(string s, int i, List<string> words, bool?[] cache)
    {
        if (i == s.Length) return true;
        if (cache[i].HasValue) return cache[i].Value;

        foreach (var word in words)
        {
            if (s.Substring(i).StartsWith(word))
            {
                if (DFS(s, i + word.Length, words, cache)) 
                {
                    cache[i] = true;
                    return true;
                }
            }
        }

        cache[i] = false;
        return false;
    }
}
