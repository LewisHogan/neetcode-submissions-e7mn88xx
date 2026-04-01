public class Solution {
    public int MaxProfit(int[] prices) {
        var maxProfit = 0;
        var buyPrice = prices[0];
        
        for (var i = 0; i < prices.Length; i++) {
            buyPrice = Math.Min(prices[i], buyPrice);
            var profit = prices[i] - buyPrice;
            maxProfit = Math.Max(profit, maxProfit);
        }

        return maxProfit;
    }
}
