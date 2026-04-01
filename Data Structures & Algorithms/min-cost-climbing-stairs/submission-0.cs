public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        var cache = new int[cost.Length];
        Array.Fill(cache, -1);
        var minCostAtZero = DFS(0, cost, cache);
        var minCostAtOne = DFS(1, cost, cache);

        return Math.Min(minCostAtZero, minCostAtOne);
    }

    private int DFS(int currentStep, int[] cost, int[] cache)
    {
        if (currentStep >= cost.Length) return 0;
        if (cache[currentStep] != -1) return cache[currentStep];

        var result = Math.Min(
            cost[currentStep] + DFS(currentStep + 2, cost, cache),
            cost[currentStep] + DFS(currentStep + 1, cost, cache)
        );

        cache[currentStep] = result;

        return result;
    }
}
