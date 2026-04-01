class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        max_profit = 0
        buy_price = prices[0]
        for price in prices:
            profit = price - buy_price
            if price < buy_price:
                buy_price = price
            max_profit = max(max_profit, profit)

        return max_profit