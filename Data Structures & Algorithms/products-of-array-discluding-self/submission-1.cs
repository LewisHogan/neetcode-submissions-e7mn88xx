public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var prefix = new int[nums.Length];
        var suffix = new int[nums.Length];

        // Calculate prefix and store it in the output array
        var result = new int[nums.Length];
        result[0] = 1;
        for (var i = 1; i < nums.Length; i++) {
            result[i] = result[i - 1] * nums[i - 1];
        }

        // We can calculate postfix as we go since we have the
        // prefix in the output array all we need to do is hold
        // the specific relevant value
        var postfix = 1;
        for (var i = nums.Length - 1; i >= 0; i--) {
            result[i] *= postfix;
            postfix *= nums[i];
        }

        return result;
    }
}
