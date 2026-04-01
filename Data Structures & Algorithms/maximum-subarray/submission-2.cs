public class Solution {
    public int MaxSubArray(int[] nums) {
        var bestTotal = nums[0];
        // Keep a running total of each element so far
        // If we go below 0, reset the window
        // Also keep the best total so far
        var total = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            total += nums[i];
            if (total < 0)
            {
                bestTotal = Math.Max(bestTotal, nums[i]);
                total = 0;
            }
            else
            {
                bestTotal = Math.Max(bestTotal, total);
            }
        }

        return bestTotal;
    }
}
