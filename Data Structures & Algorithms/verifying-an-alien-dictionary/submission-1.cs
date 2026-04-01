public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        var letterPriority = new Dictionary<char, int>();
        for (var i = 0; i < order.Length; i++)
        {
            letterPriority[order[i]] = order.Length - i;
        }

        for (var i = 1; i < words.Length; i++)
        {
            if (!IsSorted(words[i-1], words[i], letterPriority)) return false;
        }

        return true;
    }

    bool IsSorted(string word, string word2, Dictionary<char, int> priority)
    {
        for (var i = 0; i < Math.Min(word.Length, word2.Length); i++)
        {
            if (priority[word[i]] > priority[word2[i]]) return true;
            if (priority[word[i]] < priority[word2[i]]) return false;
        }

        return word.Length <= word2.Length;
    }
}