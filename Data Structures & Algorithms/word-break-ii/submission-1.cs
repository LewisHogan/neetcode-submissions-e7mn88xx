public class Solution {
    public List<string> WordBreak(string s, List<string> wordDict) {
        var wordLengths = wordDict.Select(w => w.Length);

        return DFS(s, 0, new(wordDict), wordLengths.Min(), wordLengths.Max(), new() { [s.Length] = [""] });
    }

    List<string> DFS(string s, int start, HashSet<string> words, int minWordLength, int maxWordLength, Dictionary<int, List<string>> cache)
    {
        if (cache.ContainsKey(start)) return cache[start];

        var res = new List<string>();
        for (var end = start + minWordLength; end <= s.Length; end++)
        {
            if (end - start > maxWordLength) break;
            
            if (words.Contains(s[start..end]))
            {
                var nextWords = DFS(s, end, words, minWordLength, maxWordLength, cache);
                foreach (var nextWord in nextWords)
                {
                    if (string.IsNullOrEmpty(nextWord))
                    {
                        res.Add(s[start..end]);
                    }
                    else
                    {
                        res.Add(s[start..end] + " " + nextWord);
                    }
                }
            }
        }

        cache[start] = res;
        return res;
    }
}