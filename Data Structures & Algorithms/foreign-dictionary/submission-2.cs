public class Solution {
    public string foreignDictionary(string[] words) {
        var map = new Dictionary<char, HashSet<char>>();
        foreach (var word in words)
        {
            foreach (var c in word)
            {
                map[c] = new();
            }
        }

        for (var i = 0; i < words.Length - 1; i++)
        {
            var word = words[i];
            var nextWord = words[i + 1];

            if (word.StartsWith(nextWord) && word.Length > nextWord.Length)
            {
                return string.Empty;
            }

            var minLength = Math.Min(word.Length, nextWord.Length);

            for (var j = 0; j < minLength; j++)
            {
                if (word[j] != nextWord[j])
                {
                    map[word[j]].Add(nextWord[j]);
                    break;
                }
            }
        }

        var visited = new HashSet<char>();
        var cycle = new HashSet<char>();

        foreach (var (key, value) in map)
        {
            if (!DFS(map, key, visited, cycle))
            {
                return string.Empty;
            }
        }

        return string.Join(string.Empty, visited.Reverse());
    }

    bool DFS(Dictionary<char, HashSet<char>> map, char c, HashSet<char> visited, HashSet<char> cycle)
    {
        cycle.Add(c);
        foreach (var nc in map[c])
        {
            if (cycle.Contains(nc)) return false;
            if (visited.Contains(nc)) continue;
            if (!DFS(map, nc, visited, cycle)) return false;
        }
        cycle.Remove(c);
        visited.Add(c);

        return true;
    }
}
