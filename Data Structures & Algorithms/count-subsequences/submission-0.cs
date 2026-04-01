public class Solution {
    private int[][] cache;

    public int NumDistinct(string s, string t) {
        cache = new int[s.Length][];
        for (var i = 0; i < s.Length; i++)
        {
            cache[i] = new int[t.Length];
            Array.Fill(cache[i], -1);
        }

        return DFS(s, t, 0, 0);
    }

    private int DFS(string s, string t, int sIndex, int tIndex)
    {
        if (tIndex >= t.Length) return 1;
        if (sIndex >= s.Length) return 0;

        if (cache[sIndex][tIndex] != -1) return cache[sIndex][tIndex];

        var total = 0;

        // If we currently have a potential character, add the possibilities from that path to the total
        if (s[sIndex] == t[tIndex])
        {
            total += DFS(s, t, sIndex + 1, tIndex + 1);
        }

        // Add the possibilities from the total if we don't take the current character
        total += DFS(s, t, sIndex + 1, tIndex);

        cache[sIndex][tIndex] = total;

        return total;
    }
}
