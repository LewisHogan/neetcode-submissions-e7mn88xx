public class Solution {
    public int FindMin(int[] nums) {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right) {
            var mid = left + (right - left) / 2;

            // The idea behind this is if we have a number on the right which is bigger
            // then the middle point then it means we're in a sorted section [...mid...right]
            // which means we don't need to check any of the values to the right of where mid currently is
            // if this wasn't the case we must be in a situation like this [left...mid] in which case we
            // don't need to check the left side
            if (nums[right] > nums[mid]) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }


        return nums[left];
    }
}
