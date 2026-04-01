public class Solution {
    public bool IsPalindrome(string s) {
        var str = s.ToLowerInvariant().Where(c => char.IsLetterOrDigit(c)).ToArray();
        var left = 0;
        var right = str.Length - 1;

        while (left < right) {
            if (str[left] != str[right]) return false;
            left++;
            right--;
        }

        return true;
    }
}
