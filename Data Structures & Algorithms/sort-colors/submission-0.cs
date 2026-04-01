public class Solution {
    public void SortColors(int[] nums) {
        int[] count = [0, 0, 0];
        foreach (var n in nums)
        {
            count[n]++;
        }

        var index = 0;
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < count[i]; j++)
            {
                nums[index++] = i;
            }
        }
    }
}