public class Solution {
    public int LengthOfLIS(int[] nums) {
        var cache = new int[nums.Length + 1][];
        for (var i = 0; i < cache.Length; i++)
        {
            cache[i] = new int[nums.Length + 1];
            Array.Fill(cache[i], -1);
        }

        return DFS(nums, 0, -1, cache);
    }

    private int DFS(int[] nums, int i, int j, int[][] cache)
    {
        if (i == nums.Length) return 0;
        if (cache[i][j + 1] != -1) return cache[i][j + 1];

        // What happens if we don't take this number
        // and just go to the next one
        var res = DFS(nums, i + 1, j, cache);

        if (j == -1 || nums[i] > nums[j])
        {
            // Check what happens if we take this number as the greatest
            res = Math.Max(
                res,
                1 + DFS(nums, i + 1, i, cache)
            );
        }

        cache[i][j + 1] = res;
        return res;
    }
}
