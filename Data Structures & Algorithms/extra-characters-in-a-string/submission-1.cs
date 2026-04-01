public class Solution {
    public int MinExtraChar(string s, string[] dictionary) {
        var cache = new Dictionary<int, int>() { [s.Length] = 0 };
        return DFS(s, 0, new(dictionary), cache);
    }

    int DFS(string s, int i, HashSet<string> dictionary, Dictionary<int, int> cache)
    {
        var key = i;
        if (cache.ContainsKey(key)) return cache[key];

        var smallest = 1 + DFS(s, i + 1, dictionary, cache);
        for (var j = i; j < s.Length; j++)
        {
            if (dictionary.Contains(s[i..(j+1)]))
            {
                smallest = Math.Min(smallest, DFS(s, j + 1, dictionary, cache));
            }
        }

        smallest = Math.Min(s.Length - i, smallest);

        cache[key] = smallest;
        return cache[key];
    }
}