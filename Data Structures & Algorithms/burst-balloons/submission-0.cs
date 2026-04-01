public class Solution {
    public int MaxCoins(int[] nums) {
        var cache = new int?[(2 + nums.Length), (2 + nums.Length)];
        return DFS([1, ..nums, 1], 1, nums.Length, cache);
    }

    private int DFS(int[] nums, int l, int r, int?[,] cache)
    {
        if (l > r) return 0;
        if (cache[l, r].HasValue) return cache[l, r].Value;

        var best = 0;

        for (var i = l; i <= r; i++)
        {
            // Assuming that whatever coin are are picking right now
            // is the last coin means we can split the work
            // into two branching paths which we can memoize

            var score = nums[l - 1] * nums[i] * nums[r + 1];
            var total = DFS(nums, l, i - 1, cache) + DFS(nums, i + 1, r, cache) + score;
            best = Math.Max(best, total);
        }

        cache[l, r] = best;
        return best;
    }
}
