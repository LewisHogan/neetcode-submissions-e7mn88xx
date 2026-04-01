public class Solution {
    public int ScoreOfString(string s) {
        var total = 0;

        for (var i = 0; i < s.Length - 1; i++) {
            var j = i + 1;
            total += Math.Abs(s[j] - s[i]);
        }

        return total;
    }
}