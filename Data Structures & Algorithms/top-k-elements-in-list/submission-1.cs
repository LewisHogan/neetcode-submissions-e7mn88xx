public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var count = new Dictionary<int, int>();
        foreach (var num in nums) {
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;
            }
        }

        return count
            .OrderByDescending(kvp => kvp.Value)
            .Select(kvp => kvp.Key)
            .Take(k)
            .ToArray();
    }
}
