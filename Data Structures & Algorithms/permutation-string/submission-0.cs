public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        var chars = new int[26];
        foreach (var c in s1) {
            chars[c - 'a']++;
        }

        var left = 0;
        for (var right = 0; right < s2.Length; right++) {
            chars[s2[right] - 'a']--;
            if (chars.All(c => c == 0)) {
                return true;
            }

            while (chars[s2[right] - 'a'] < 0 && left <= right) {
                chars[s2[left] - 'a']++;
                left++;
            }
        }

        return false;
    }
}
