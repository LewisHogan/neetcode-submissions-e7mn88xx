public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
        return DFS(nums, target, 0);
    }

    private int DFS(int[] nums, int target, int index)
    {
        if (target == 0 && index == nums.Length) return 1;
        if (index >= nums.Length) return 0;

        var total = 0;

        total += DFS(nums, target + nums[index], index + 1);
        total += DFS(nums, target - nums[index], index + 1);
        return total;
    }
}
