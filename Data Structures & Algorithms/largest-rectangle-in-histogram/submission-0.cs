public class Solution {
    public int LargestRectangleArea(int[] heights) {
        // Brute force implementation
        var maxArea = 0;
        for (var left = 0; left < heights.Length; left++)
        {
            for (var right = left; right < heights.Length; right++)
            {
                maxArea = Math.Max(maxArea, (1 + right - left) * minHeight(heights, left, right));
            }
        }

        return maxArea;
    }

    private int minHeight(int[] heights, int left, int right)
    {
        var minHeight = heights[left];
        for (var i = left + 1; i <= right; i++)
        {
            minHeight = Math.Min(minHeight, heights[i]);
        }

        return minHeight;
    }
}
