public class Solution {
    public bool CanPartition(int[] nums) {
        if (nums.Sum() % 2 == 1) return false;

        return DFS(nums, nums.Sum() / 2, 0, 0);
    }

    bool DFS(int[] nums, int target, int i, int left)
    {
        if (i >= nums.Length) return false;
        if (left == target) return true;

        if (DFS(nums, target, i + 1, left + nums[i])) return true;
        if (DFS(nums, target, i + 1, left)) return true;

        return false;
    }
}
