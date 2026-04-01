public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        // Backtracking through nums, updating a set with the combinations
        // when the search finishes return the set

        Array.Sort(nums);

        var results = new List<List<int>>();

        DFS(nums, target, 0, nums.ToDictionary(n => n, _ => 0), new(), results);
        return results;
    }

    void DFS(int[] nums, int target, int total, Dictionary<int, int> freqs, HashSet<int> combos, List<List<int>> results)
    {
        foreach (var num in nums)
        {
            var sum = num + total;
            if (sum > target) continue;

            freqs[num]++;
            if (sum == target)
            {
                AddToResults(freqs, combos, results);
                freqs[num]--;
                continue;
            }

            DFS(nums, target, sum, freqs, combos, results);
            freqs[num]--;
        }
    }

    void AddToResults(Dictionary<int, int> freqs, HashSet<int> combos, List<List<int>> results)
    {
        var hashcode = 0;
        var result = new List<int>();
        foreach (var (key, value) in freqs)
        {
            hashcode = HashCode.Combine(hashcode, value);
            for (var i = 0; i < value; i++) result.Add(key);
        }

        if (combos.Contains(hashcode)) return;
        combos.Add(hashcode);
        results.Add(result);
    }
}
