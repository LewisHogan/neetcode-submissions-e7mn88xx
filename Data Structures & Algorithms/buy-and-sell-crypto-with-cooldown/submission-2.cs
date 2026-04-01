public class Solution {
    public int MaxProfit(int[] prices) {
        // If we know the profit of the next few days,
        // we can work our way backwards by choosing the most profitable option
        var profitBuyingTomorrow = 0;
        var profitSellingTomorrow = 0;
        var profitBuyingTwoDays = 0;
        for (var i = prices.Length - 1; i >= 0; i--)
        {
            // On any day we can do one of the following:
            // Sell if we have a coin
            // Buy if we don't have a coin
            // If we sell on a day we can only buy in 2 days, not tomorrow
            var profitBuyingToday = Math.Max(profitSellingTomorrow - prices[i], profitBuyingTomorrow);
            var profitSellingToday = Math.Max(profitBuyingTwoDays + prices[i], profitSellingTomorrow);

            profitBuyingTwoDays = profitBuyingTomorrow;
            profitBuyingTomorrow = profitBuyingToday;
            profitSellingTomorrow = profitSellingToday;
        }

        return profitBuyingTomorrow;
    }
}
