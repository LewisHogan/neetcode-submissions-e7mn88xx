public class Solution {
    public int CharacterReplacement(string s, int k) {
        var left = 0;
        var maxFreq = 0;
        var chars = new Dictionary<char, int>();
        var maxLength = 0;

        for (var right = 0; right < s.Length; right++) {

            if (!chars.ContainsKey(s[right])) {
                chars[s[right]] = 1;
            } else {
                chars[s[right]]++;
            }

            maxFreq = Math.Max(maxFreq, chars[s[right]]);

            // As long as we have k or less unique characters (ignoring the most frequent)
            // we can transform into a substring of length most frequent + k
            while ((right - left + 1) - maxFreq > k) {
                chars[s[left]]--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
