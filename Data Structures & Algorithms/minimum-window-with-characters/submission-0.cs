public class Solution {
    public string MinWindow(string s, string t) {
        string minStr = null;
        var charMap = new Dictionary<char, int>();

        foreach (var c in t) {
            if (charMap.ContainsKey(c)) {
                charMap[c]++;
            } else {
                charMap[c] = 1;
            }
        }

        var start = 0;
        for (var end = 0; end < s.Length; end++) {
            var c = s[end];
            if (charMap.ContainsKey(c)) {
                charMap[c]--;
            }

            while (charMap.Values.All(v => v <= 0)) {
                if (minStr is null) {
                    minStr = s.Substring(start, (1 + end - start));
                } else {
                    minStr = minStr.Length < (1 + end - start) ? minStr : s.Substring(start, (1 + end - start));
                }

                if (charMap.ContainsKey(s[start])) {
                    charMap[s[start]]++;
                }
                start++;
            }
        }

        return minStr ?? "";
    }
}
