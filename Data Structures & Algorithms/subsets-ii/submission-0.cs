public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        var res = new List<List<int>>();
        Backtrack(0, res, new List<int>(), nums);

        return res;
    }
    
    private void Backtrack(int i, List<List<int>> res, List<int> subset, int[] nums)
    {
        res.Add([..subset]);
        for (var j = i; j < nums.Length; j++)
        {
            // Skip over duplicates, unless this is part of the first backtrack
            if (j > i && nums[j - 1] == nums[j]) continue;
            subset.Add(nums[j]);
            Backtrack(j + 1, res, subset, nums);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}
