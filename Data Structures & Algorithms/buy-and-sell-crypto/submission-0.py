class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        max_profit = 0
        buy_day_index = 0

        for i in range(1, len(prices)):
            if prices[i] < prices[buy_day_index]:
                buy_day_index = i

            profit = prices[i] - prices[buy_day_index]
            max_profit = max(max_profit, profit)
        
        return max_profit