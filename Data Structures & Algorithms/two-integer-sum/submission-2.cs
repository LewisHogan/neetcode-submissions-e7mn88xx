public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++) {
            var number = nums[i];
            var diff = target - number;
            if (map.ContainsKey(diff)) {
                return new int[] {
                    Math.Min(i, map[diff]),
                    Math.Max(i, map[diff])
                };
            } else {
                map[number] = i;
            }
        }

        return new int[] {};
    }
}
