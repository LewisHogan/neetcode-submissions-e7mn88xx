public class Solution {
    public int AppendCharacters(string s, string t) {
        return GetMissingCharacters(t, s);
    }

    private int GetMissingCharacters(string s, string t) {
        int i = 0, j = 0;
        while (i < s.Length && j < t.Length) {
            if (s[i] == t[j]) {
                i++;
            }
            j++;
        }

        if (i != s.Length) {
            return s.Length - i;
        }

        return 0;
    }
}