class Solution {
    public boolean isAnagram(String s, String t) {
        if (s.length() != t.length()) return false;

        var charCounts = new int[26];

        for (var i = 0; i < s.length(); i++) {
            charCounts[s.charAt(i) - 'a']++;
            charCounts[t.charAt(i) - 'a']--;
        }

        return Arrays.stream(charCounts).allMatch(c -> c == 0);
    }
}
