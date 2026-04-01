public class Solution {
    public List<List<string>> Partition(string s) {
        var isPalindrome = BuildPalindromeCache(s);
        return DFS(s, 0, isPalindrome);
    }

    List<List<string>> DFS(string s, int i, bool[,] isPalindrome)
    {
        var results = new List<List<string>>();

        if (i == s.Length) return [[]];

        for (var j = i; j < s.Length; j++)
        {
            if (isPalindrome[i, j])
            {
                var palindrome = s.Substring(i, j - i + 1);
                foreach (var part in DFS(s, j + 1, isPalindrome))
                {
                    results.Add([palindrome, ..part]);
                }
            }
        }

        return results;
    }

    bool[,] BuildPalindromeCache(string s)
    {
        var isPalindrome = new bool[s.Length, s.Length];

        for (var length = 1; length <= s.Length; length++)
        {
            for (var start = 0; start < s.Length - length + 1; start++)
            {
                var end = start + length - 1;

                if (s[start] == s[end])
                {
                    if (length <= 2)
                    {
                        isPalindrome[start, end] = true;
                    }
                    else
                    {
                        isPalindrome[start, end] = isPalindrome[start + 1, end - 1];
                    }
                }
            }
        }

        return isPalindrome;
    }
}
