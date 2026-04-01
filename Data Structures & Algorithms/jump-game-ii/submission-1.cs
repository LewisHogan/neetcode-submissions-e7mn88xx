public class Solution {
    public int Jump(int[] nums) {
        var cache = new int[nums.Length];
        Array.Fill(cache,  int.MaxValue);
        return DFS(nums, 0, cache);
    }

    private int DFS(int[] nums, int index, int[] cache)
    {
        if (index >= nums.Length - 1) return 0;
        if (nums[index] == 0) return int.MaxValue - 1;
        if (cache[index] != int.MaxValue) return cache[index];

        var minJumps = int.MaxValue;
        for (var j = 1; j <= nums[index]; j++)
        {
            Console.WriteLine($"Index {index}, minJumps {minJumps}");
            minJumps = Math.Min(minJumps, 1 + DFS(nums, index + j, cache));
        }

        cache[index] = minJumps;
        return minJumps;
    }
}
