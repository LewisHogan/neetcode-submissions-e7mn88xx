public class Solution {
    public int Search(int[] nums, int target) {
        var pivot = FindPivot(nums);

        Console.WriteLine($"Pivot is {pivot}");

        // We can "rotate" the index by adding the pivot and modding it around
        // e.g. if [0, 1, 2] is [1, 2, 0], we can do [1, 2, 0, 1, 2] by using the mod
        // to loop around

        var left = 0;
        var right = nums.Length - 1;

        while (left <= right) {
            var mid = left + (right - left) / 2;
            var rotatedMid = (mid + pivot) % nums.Length;
            Console.WriteLine($"Checking l={left}, r={right}, mid= {mid}, rotatedmid= {rotatedMid} which is {nums[rotatedMid]}");
            if (nums[rotatedMid] == target) {
                return rotatedMid;
            } else if (nums[rotatedMid] < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return -1;
    }

    /// <summary>
    /// Find the index of the minimum value in the rotated array.
    /// </summary>
    private int FindPivot(int[] nums) {
        var left = 0;
        var right = nums.Length - 1;
        while (left < right) {
            var mid = left + (right - left) / 2;
            if (nums[mid] > nums[right]) {
                // We are still in the rotated section, search right half
                left = mid + 1;
            } else {
                // We are in the original array, search left half
                right = mid;
            }
        }

        return left;
    }
}
