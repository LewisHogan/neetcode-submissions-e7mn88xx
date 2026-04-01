public class Solution {
    public int MaxProfit(int[] prices) {
        var maxProfit = 0;
        var lowestBuy = prices[0];
        for (var i = 1; i < prices.Length; i++) {
            var profit = prices[i] - lowestBuy;
            maxProfit = Math.Max(profit, maxProfit);
            lowestBuy = Math.Min(lowestBuy, prices[i]);
        }

        return maxProfit;
    }
}
