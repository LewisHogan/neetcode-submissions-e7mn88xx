public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        // Key is the num, index is the index
        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++) {
            var num = nums[i];
            if (map.ContainsKey(target - num)) {
                // If it's already in the map, it will have a lower
                // index then i
                return new int[] { map[target - num], i };
            }

            map[num] = i;
        }

        // We should never hit this assuming a valid solution
        return new int[] { -1, -1 };
    }
}
