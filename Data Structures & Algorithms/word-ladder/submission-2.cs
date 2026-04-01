public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (beginWord == endWord) return 0;
        if (!wordList.Contains(endWord)) return 0;

        var visited = new HashSet<string>();
        var queue = new Queue<(string, int)>();
        queue.Enqueue((beginWord, 1));

        while (queue.Count > 0)
        {
            var (word, transformations) = queue.Dequeue();
            if (word == endWord) return transformations;

            foreach (var nextWord in CloseWords(word, wordList))
            {
                if (visited.Contains(nextWord)) continue;
                visited.Add(nextWord);

                queue.Enqueue((nextWord, transformations + 1));
            }
            transformations++;
        }

        return 0;
    }

    private IEnumerable<string> CloseWords(string word, IList<string> wordList)
        => wordList.Where(w => CountDistance(word, w) == 1);
    
    private int CountDistance(string word, string other)
    {
        var distance = 0;
        for (var i = 0; i < word.Length; i++)
        {
            if (word[i] != other[i]) distance++;
        }
        return distance;
    }
    
}
