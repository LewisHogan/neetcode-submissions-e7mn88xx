public class Solution {
    public int MaxProfit(int[] prices) {
        var cache = new Dictionary<(int, bool), int>();
        return DFS(0, false, prices, cache);
    }

    private int DFS(int i, bool hasCoin, int[] prices, Dictionary<(int, bool), int> cache)
    {
        if (i >= prices.Length) return 0;
        if (cache.ContainsKey((i, hasCoin))) return cache[(i, hasCoin)];
        
        var maxProfit = 0;

        if (hasCoin)
        {
            // Can't buy a coin the next day if we sell today, so increment by 2
            var maxProfitIfSell = prices[i] + DFS(i + 2, !hasCoin, prices, cache);
            maxProfit = Math.Max(maxProfitIfSell, DFS(i + 1, hasCoin, prices, cache));
        }
        else
        {
            var maxProfitIfNoBuy = DFS(i + 1, hasCoin, prices, cache);
            maxProfit = Math.Max(maxProfitIfNoBuy, DFS(i + 1, !hasCoin, prices, cache) - prices[i]);
        }

        cache[(i, hasCoin)] = maxProfit;
        return maxProfit;
    }
}
