public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        var anagramGroups = new Dictionary<string, List<string>>();
        foreach (var str in strs) {
            var hash = CreateAnagramHash(str);
            if (anagramGroups.ContainsKey(hash)) {
                anagramGroups[hash].Add(str);
            } else {
                anagramGroups[hash] = new List<string>() { str };
            }
        }

        return anagramGroups.Values.ToList();
    }

    private string CreateAnagramHash(string str) {
        var count = new int[26];
        foreach (var c in str) {
            count[c - 'a']++;
        }

        return string.Join('-', count);
    }
}
