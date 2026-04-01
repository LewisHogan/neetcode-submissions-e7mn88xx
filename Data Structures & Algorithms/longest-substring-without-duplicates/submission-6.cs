public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var set = new HashSet<char>();
        var startOfWindow = 0;
        var maxSubstringLength = 0;
        for (var i = 0; i < s.Length; i++) {
            while (set.Contains(s[i])) {
                set.Remove(s[startOfWindow]);
                startOfWindow++;
            }

            set.Add(s[i]);
            maxSubstringLength = Math.Max(1 + i - startOfWindow, maxSubstringLength);
        }

        return maxSubstringLength;
    }
}
