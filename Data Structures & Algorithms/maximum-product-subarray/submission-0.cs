public class Solution {

    private int bestResult = int.MinValue;

    public int MaxProduct(int[] nums) {
        // We can calculate the products of nums[l..r]
        // and then reuse those for bigger ranges
        // e.g. nums[l-1..r+1] = nums[l-1] + nums[l..r] + nums[r+1]
        var cache = new int?[nums.Length + 1, nums.Length + 1];
        DFS(nums, 0, nums.Length - 1, cache);
        return bestResult;
    }

    int DFS(int[] nums, int l, int r, int?[,] cache)
    {
        if (cache[l, r].HasValue) return cache[l, r].Value;

        var res = 0;
        if (l == r)
        {
            res = nums[l];
        }
        else
        {
            res = Math.Max(
                nums[l] * DFS(nums, l + 1, r, cache),
                nums[r] * DFS(nums, l, r - 1, cache)
            );
        }

        bestResult = Math.Max(bestResult, res);

        cache[l, r] = res;
        return res; 
    }
}
