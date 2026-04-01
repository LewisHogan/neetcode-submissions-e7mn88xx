public class Solution {
    public int RomanToInt(string s) {
        var dict = new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        var modifiers = new Dictionary<char, string>()
        {
            { 'I', "VX" },
            { 'X', "LC" },
            { 'C', "DM" }
        };

        var total = 0;
        var lastModifierEncountered = int.MinValue;
        for (var i = 0; i < s.Length - 1; i++)
        {
            if (modifiers.ContainsKey(s[i]) && modifiers[s[i]].Contains(s[i+1]))
            {
                total += dict[s[i+1]] - dict[s[i]];
                lastModifierEncountered = i;
                i++;
            }
            else
            {
                total += dict[s[i]];
            }
        }

        // This means we have not processed the last digit yet
        if (lastModifierEncountered == int.MinValue)
        {
            total += dict[s[^1]];
        }

        return total;
    }
}