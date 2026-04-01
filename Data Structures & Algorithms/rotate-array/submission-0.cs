public class Solution {
    public void Rotate(int[] nums, int k) {
        while (k-- > 0)
        {
            var extra = nums[^1];
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                var source = (i - 1) < 0 ? (i - 1) + nums.Length : i - 1;
                if (i == 0)
                {
                    nums[i] = extra;
                }
                else
                {
                    nums[i] = nums[source];
                }
            }
        }
    }
}