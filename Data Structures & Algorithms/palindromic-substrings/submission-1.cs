public class Solution {
    public int CountSubstrings(string s) {
        var total = 0;
        for (var i = 0; i < s.Length; i++)
        {
            total += CountFromCenter(i, i, s); // Odd
            total += CountFromCenter(i, i+1, s); // Even
        }

        return total;
    }

    private int CountFromCenter(int left, int right, string s)
    {
        var total = 0;
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            total++;
            left--;
            right++;
        }

        return total;
    }
}
