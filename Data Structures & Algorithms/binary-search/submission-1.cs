public class Solution {
    public int Search(int[] nums, int target) {
        var low = 0;
        var high = nums.Length -1;

        while (low <= high) {
            var mid = low + (high - low) / 2;
            if (nums[mid] == target) return mid;

            if (nums[mid] < target) {
                low = mid + 1;
            } else {
                high = mid - 1;
            }
        }

        return -1;
    }
}
