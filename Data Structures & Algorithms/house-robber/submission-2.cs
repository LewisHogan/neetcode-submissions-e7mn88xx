public class Solution {
    public int Rob(int[] nums) {
        Dictionary<int, int> cache = new Dictionary<int, int>();
        return Math.Max(nums[0] + DFS(nums, 2, cache), DFS(nums, 1, cache));
    }

    private int DFS(int[] nums, int houseToRob, Dictionary<int, int> cache)
    {
        if (cache.ContainsKey(houseToRob)) return cache[houseToRob];
        if (houseToRob >= nums.Length) return 0;

        var res = Math.Max(nums[houseToRob] + DFS(nums, houseToRob + 2, cache), DFS(nums, houseToRob + 1, cache));
        cache[houseToRob] = res;
        return res;
    }
}
