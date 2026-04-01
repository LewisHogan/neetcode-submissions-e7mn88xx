public class Solution {
    public bool IsSubsequence(string s, string t) {
        var tIndex = 0;
        var foundMatchingChar = false;
        foreach (var charToFind in s) {
            while (tIndex < t.Length) {
                if (t[tIndex] == charToFind) {
                    foundMatchingChar = true;
                    tIndex++;
                    break;
                }
                tIndex++;
            }

            if (!foundMatchingChar) {
                return false;
            }

            foundMatchingChar = false;
        }

        return true;
    }
}