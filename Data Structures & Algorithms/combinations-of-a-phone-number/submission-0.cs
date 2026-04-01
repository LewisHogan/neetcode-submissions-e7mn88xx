public class Solution {
    public List<string> LetterCombinations(string digits) {
        if (digits.Length == 0) return new();

        var map = new Dictionary<char, string>
        {
            {'2', "abc"},
            {'3', "def"},
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };

        var results = new List<string>();
        DFS(digits, 0, map, results);
        return results;
    }

    private void DFS(string digits, int i, Dictionary<char, string> map, List<string> results, string str = "")
    {
        if (i == digits.Length)
        {
            results.Add(str);
            return;
        }

        foreach (var letter in map[digits[i]])
        {
            DFS(digits, i + 1, map, results, str + letter);
        }
    }
}
