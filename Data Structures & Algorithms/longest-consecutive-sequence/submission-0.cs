public class Solution {
    public int LongestConsecutive(int[] nums) {
        var set = new HashSet<int>(nums);
        var maxSequence = 0;
        for (var i = 0; i < nums.Length; i++) {
            var num = nums[i];
            if (set.Contains(num - 1)) continue;
            var sequence = 1;
            while (set.Contains(num + 1)) {
                sequence++;
                num++;
            }
            maxSequence = Math.Max(sequence, maxSequence);
        }
        return maxSequence;
    }
}
