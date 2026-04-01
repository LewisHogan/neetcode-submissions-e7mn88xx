from functools import cache

class Solution:
    def maximumProfit(self, profit: List[int], weight: List[int], capacity: int) -> int:
        ordering = sorted([i for i in range(len(weight))], key=lambda i: weight[i])

        @cache
        def backtrack(i, total_profit=0, weight_remaining=0):
            if i > len(ordering) - 1 or weight[ordering[i]] > weight_remaining:
                return total_profit
            
            return max(
                backtrack(i + 1, total_profit + profit[ordering[i]], weight_remaining - weight[ordering[i]]),
                backtrack(i + 1, total_profit, weight_remaining)
            )
        
        return backtrack(0, 0, capacity)