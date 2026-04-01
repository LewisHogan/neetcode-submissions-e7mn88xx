public class Solution {
    public int Trap(int[] height) {
        var prefix = new int[height.Length];
        var suffix = new int[height.Length];

        var maxHeight = 0;
        for (var i = 0; i < height.Length; i++) {
            maxHeight = Math.Max(maxHeight, height[i]);
            prefix[i] = maxHeight;
        }

        maxHeight = 0;
        for (var i = height.Length - 1; i >= 0; i--) {
            maxHeight = Math.Max(maxHeight, height[i]);
            suffix[i] = maxHeight;
        }

        var maxAmountOfWater = 0;
        for (var i = 0; i < height.Length; i++) {
            // Water can only go as tall as the smallest column on each side
            // and we need to take away the height of any existing wall at the same
            // location
            var amountOfWater = Math.Min(prefix[i], suffix[i]) - height[i];
            maxAmountOfWater += amountOfWater;
        }

        return maxAmountOfWater;
    }
}
