public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        Array.Sort(nums);

        var results = new List<List<int>>();
        DFS(nums, target, 0, [], results);
        return results;
    }

    void DFS(int[] nums, int target, int i, List<int> path, List<List<int>> results)
    {
        if (target < 0) return;

        if (target == 0)
        {
            results.Add([..path]);
            return;
        }

        for (var j = i; j < nums.Length; j++)
        {
            // Since nums is sorted, if we reach this state there's no point
            // exploring other branches
            if (target - nums[j] < 0) return;

            path.Add(nums[j]);
            DFS(nums, target - nums[j], j, path, results);
            path.RemoveAt(path.Count - 1);
        }
    }
}
