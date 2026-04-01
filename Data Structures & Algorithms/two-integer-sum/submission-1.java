class Solution {
    public int[] twoSum(int[] nums, int target) {
        HashMap<Integer, Integer> previous = new HashMap<>();

        for (var i = 0; i < nums.length; i++) {
            var num = nums[i];
            var diff = target - num;
            if (previous.containsKey(diff)) {
                return new int[]{ previous.get(diff), i };
            }
            previous.put(num, i);
        }

        return new int[] {};
    }
}
