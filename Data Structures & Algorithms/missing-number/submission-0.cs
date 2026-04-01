public class Solution {
    public int MissingNumber(int[] nums) {

        var res = nums.Length;
        for (var i = 0; i < nums.Length; i++)
        {
            res ^= i ^ nums[i];
        }

        return res;
    }
}
