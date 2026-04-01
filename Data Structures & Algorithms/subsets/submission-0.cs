public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> results = new();
        results.Add([]);
        DFS(nums, 0, [], results);
        return results;
    }

    void DFS(int[] nums, int i, List<int> path, List<List<int>> results)
    {
        if (i >= nums.Length) return;

        for (var j = i; j < nums.Length; j++)
        {
            path.Add(nums[j]);
            results.Add(new(path));
            DFS(nums, j + 1, path, results);
            path.RemoveAt(path.Count - 1);
        }
    }
}
