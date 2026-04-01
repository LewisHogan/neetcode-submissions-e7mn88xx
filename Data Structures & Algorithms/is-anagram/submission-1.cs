public class Solution {
    public bool IsAnagram(string s, string t) {
        var letterCounts = new int[26];
        foreach (var c in s) {
            letterCounts[c - 'a']++;
        }

        foreach (var c2 in t) {
            letterCounts[c2 - 'a']--;
        }

        foreach (var count in letterCounts) {
            if (count != 0) return false;
        }

        return true;
    }
}
