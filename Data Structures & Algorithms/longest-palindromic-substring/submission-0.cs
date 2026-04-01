public class Solution {
    public string LongestPalindrome(string s) {
        var longest = string.Empty;
        for (var l = 0; l < s.Length; l++)
        {
            for (var r = l; r < s.Length; r++)
            {
                if (IsPalindrome(s, l, r))
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

    bool IsPalindrome(string s, int l, int r)
    {
        while (l < r)
        {
            if (s[l] != s[r]) return false;
            l++;
            r--;
        }

        return true;
    }
}
