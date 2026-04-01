public class Solution {
    public bool CanJump(int[] nums) {
        var maximumStepReachable = 0;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            maximumStepReachable = Math.Max(i + nums[i], maximumStepReachable);
            if (maximumStepReachable < (i + 1)) return false;
        }
        return true;
    }
}
