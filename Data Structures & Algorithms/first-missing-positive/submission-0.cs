public class Solution {
    public int FirstMissingPositive(int[] nums) {
        // Our number is going to be somewhere in the range of 1-n
        // So we can use the index as a flag to say if we've encountered it
        // if the value stored in the array is negative
        // to do this we need to zero out any negative numbers so we don't
        // have an incorrect flag

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= 0 || nums[i] > nums.Length) nums[i] = nums.Length + 1;
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var index = Math.Abs(nums[i]) - 1;
            if (index >= nums.Length) continue;

            if (nums[index] > 0) nums[index] = -nums[index];
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) return (i+1);
        }

        return nums.Length + 1;
    }
}