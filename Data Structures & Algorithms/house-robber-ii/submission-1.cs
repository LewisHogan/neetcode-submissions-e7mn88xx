public class Solution {
    public int Rob(int[] nums) {
        var cache = new Dictionary<(int, bool), int>();
        return DFS(nums, 0, false, cache);
    }

    int DFS(int[] nums, int i, bool robFirstHouse, Dictionary<(int, bool), int> cache)
    {
        if (i >= nums.Length) return 0;
        if (cache.ContainsKey((i, robFirstHouse))) return cache[(i, robFirstHouse)];

        // Options are: rob current house, skip current house
        // If we rob current house we can't go to the next one

        if (i == 0)
        {
            cache[(i, robFirstHouse)] = Math.Max(
                DFS(nums, i + 1, false, cache),
                nums[i] + DFS(nums, i + 2, true, cache)
            );
            return cache[(i, robFirstHouse)];
        }

        if (i == nums.Length - 1)
        {
            cache[(i, robFirstHouse)] = robFirstHouse ? 0 : nums[i];
            return cache[(i, robFirstHouse)];
        }

        cache[(i, robFirstHouse)] = Math.Max(
            DFS(nums, i + 1, robFirstHouse, cache),
            nums[i] + DFS(nums, i + 2, robFirstHouse, cache)
        );

        return cache[(i, robFirstHouse)];
    }
}
