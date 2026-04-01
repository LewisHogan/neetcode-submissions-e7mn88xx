public class Solution {

    private List<List<int>> results;

    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        results = new List<List<int>>();
        Array.Sort(candidates);
        DFS(0, new List<int>(), 0, candidates, target);
        return results;
    }

    private void DFS(int index, List<int> path, int sum, int[] candidates, int target)
    {
        if (sum == target)
        {
            results.Add(new List<int>(path));
            return;
        }

        for (var i = index; i < candidates.Length; i++)
        {
            // Skip duplicates, assumes candidates is sorted
            if (i > index && candidates[i] == candidates[i-1]) continue;

            var candidate = candidates[i];
            if (candidate + sum > target) break; // If this is true all remaining candidates would be too big

            path.Add(candidate);
            DFS(i + 1, path, sum + candidate, candidates, target);
            path.Remove(candidate);
        }
    }
}
