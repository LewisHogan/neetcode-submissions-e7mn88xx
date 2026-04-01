public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        var res = new List<List<int>>();
        Array.Sort(nums);
        // At this point nums is [lowest..highest] which means
        // we can always tell if we can sum to 0 by if we start with
        // a negative number or not, if it's not negative the sum
        // will be positive and so we can't find a valid solution anymore
        for (var i = 0; i < nums.Length; i++) {
            if (nums[i] > 0) break;
            // Skip duplicate numbers
            if (i > 0 && nums[i] == nums[i-1]) continue;

            // At this point we do a regular 2 pointers sum
            // with the rest of the numbers
            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right) {
                var sum = nums[i] + nums[left] + nums[right];
                if (sum == 0) {
                    // We have our triplet so we need to move the left and right pointers
                    // then we need to ensure the left pointer isn't pointing at an identical
                    // value
                    res.Add(new List<int>() { nums[i], nums[left], nums[right] });
                    left++;
                    right--;
                    while (left < right && nums[left] == nums[left - 1]) {
                        left++;
                    }
                } else if (sum < 0) {
                    left++;
                } else if (sum > 0) {
                    right--;
                }
            }
        }

        return res;
    }
}
