public class Solution {
    public int MaxSubArray(int[] nums) {
        var bestTotal = nums[0];
        // Keep a running total of each element so far
        // If we go below 0, reset the window
        // Also keep the best total so far
        var total = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            total += nums[i];
            bestTotal = Math.Max(bestTotal, total);
            if (total < 0)
            {
                total = 0;
            }
        }

        return bestTotal;
    }
}
