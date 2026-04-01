public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var set = new HashSet<char>();
        var startOfWindow = 0;
        var endOfWindow = 0;
        var maxSubstringLength = 0;
        while (endOfWindow < s.Length) {
            if (!set.Contains(s[endOfWindow])) {
                set.Add(s[endOfWindow]);
                maxSubstringLength = Math.Max(maxSubstringLength, 1 + endOfWindow - startOfWindow);
                endOfWindow++;
            } else {
                while (set.Contains(s[endOfWindow])) {
                    set.Remove(s[startOfWindow]);
                    startOfWindow++;
                }
            }
        }

        return maxSubstringLength;
    }
}
