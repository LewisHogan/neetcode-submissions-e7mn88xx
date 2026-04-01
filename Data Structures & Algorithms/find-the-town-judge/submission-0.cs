public class Solution {
    public int FindJudge(int n, int[][] trust) {
        var candidates = new int[n + 1];
        var candidatesWhoDontTrust = new HashSet<int>(Enumerable.Range(1, n));

        foreach (var relationship in trust)
        {
            candidatesWhoDontTrust.Remove(relationship[0]);
            candidates[relationship[1]]++;
        }

        if (candidates.Count(c => c == n - 1) > 1) return -1;

        foreach (var candidate in Enumerable.Range(1, n))
        {
            if (candidatesWhoDontTrust.Contains(candidate) && candidates[candidate] == n - 1)
            {
                return candidate;
            }
        }

        return -1;
    }
}