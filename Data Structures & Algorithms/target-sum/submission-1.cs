public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        var cache = new Dictionary<(int, int), int>();
        return DFS(nums, target, 0, cache);
    }

    private int DFS(int[] nums, int target, int index, Dictionary<(int, int), int> cache)
    {
        if (target == 0 && index == nums.Length) return 1;
        if (index >= nums.Length) return 0;
        if (cache.ContainsKey((index, target))) return cache[(index, target)];

        var total = 0;

        total += DFS(nums, target + nums[index], index + 1, cache);
        total += DFS(nums, target - nums[index], index + 1, cache);

        cache[(index, target)] = total;
        return total;
    }
}
