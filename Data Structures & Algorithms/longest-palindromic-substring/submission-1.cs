public class Solution {
    public string LongestPalindrome(string s) {
        var longest = string.Empty;
        var cache = new Dictionary<(int, int), bool>();
        for (var l = 0; l < s.Length; l++)
        {
            for (var r = l; r < s.Length; r++)
            {
                if (IsPalindrome(s, l, r, cache))
                {
                    var length = r - l + 1;
                    if (length > longest.Length)
                    {
                        longest = s.Substring(l, length);
                    }
                }
            }
        }

        return longest;
    }

    bool IsPalindrome(string s, int l, int r, Dictionary<(int, int), bool> cache)
    {
        if (cache.ContainsKey((l, r))) return cache[(l, r)];

        if (l < r)
        {
            if (s[l] != s[r])
            {
                cache[(l,r)] = false;
                return false;
            }
            else
            {
                cache[(l,r)] = (s[l] == s[r]) && IsPalindrome(s, l + 1, r - 1, cache);
                return cache[(l,r)];
            }
        }

        cache[(l, r)] = true;
        return true;
    }
}
