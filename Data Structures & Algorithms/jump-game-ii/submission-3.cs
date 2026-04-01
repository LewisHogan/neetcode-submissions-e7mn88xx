public class Solution {
    public int Jump(int[] nums) {
        var steps = 0;
        var max = 0;
        var nextMax = 0;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            nextMax = Math.Max(nextMax, i + nums[i]);
            if (i == max)
            {
                steps++;
                max = nextMax;
            }
        }

        return steps;
    }
}
