public class Solution {
    public int MaxArea(int[] heights) {
        var left = 0;
        var right = heights.Length - 1;

        var maxWater = 0;

        while (left < right) {
            var containerWidth = right - left;
            var containerHeight = Math.Min(heights[right], heights[left]);
            var water = containerWidth * containerHeight;
            maxWater = Math.Max(water, maxWater);

            if (heights[left] <= heights[right]) {
                left++;
            } else {
                right--;
            }
        }

        return maxWater;
    }
}
