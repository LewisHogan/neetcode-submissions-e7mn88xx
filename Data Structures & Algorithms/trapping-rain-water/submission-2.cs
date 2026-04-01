public class Solution {
    public int Trap(int[] height) {
        if (height.Length == 0) return 0;

        var left = 0;
        var right = height.Length - 1;

        var leftMax = height[left];
        var rightMax = height[right];

        var totalAmountOfWater = 0;
        while (left < right) {
            if (leftMax < rightMax) {
                totalAmountOfWater += leftMax - height[left];
                left++;
                leftMax = Math.Max(leftMax, height[left]);
            } else {
                totalAmountOfWater += rightMax - height[right];
                right--;
                rightMax = Math.Max(rightMax, height[right]);
            }
        }

        return totalAmountOfWater;
    }
}
