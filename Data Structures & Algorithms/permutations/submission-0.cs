public class Solution {
    public List<List<int>> Permute(int[] nums) {
        // We have all indicies 0..nums remaining
        // Pick any of them, we then have 0..nums except i
        // Keep repeating that
        var results = new List<List<int>>();
        Backtrack(results, new Stack<int>(), new bool[nums.Length], nums);
        return results;
    }

    private void Backtrack(List<List<int>> results, Stack<int> pathSoFar, bool[] chosen, int[] nums) {
        for (var i = 0; i < chosen.Length; i++) {

            // All numbers are chosen, add to results
            if (chosen.All(b => b is true)) {
                results.Add(pathSoFar.ToList());
                return;
            }

            if (chosen[i]) continue;

            pathSoFar.Push(nums[i]);

            chosen[i] = true;
            Backtrack(results, pathSoFar, chosen, nums);
            chosen[i] = false;
            
            pathSoFar.Pop();
        }
    }
}
