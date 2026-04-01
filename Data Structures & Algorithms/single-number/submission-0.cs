public class Solution {
    public int SingleNumber(int[] nums) {
        var total = 0;
        foreach (var n in nums)
        {
            total = total ^ n;
        }

        return total;
    }
}
