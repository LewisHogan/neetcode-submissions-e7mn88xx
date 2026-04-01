public class Solution {
    public int CoinChange(int[] coins, int amount) {
        return BFS(coins, amount);
    }

    private int BFS(int[] coins, int amount)
    {
        if (amount == 0) return 0;
        var visitedAmounts = new HashSet<int>();

        // (amount, coins)
        var queue = new Queue<(int, int)>();
        queue.Enqueue((amount, 0));

        var minCoins = int.MaxValue;

        while (queue.Any())
        {
            (int currentAmount, int currentCoins) = queue.Dequeue();

            foreach (var coin in coins)
            {
                var nextAmount = currentAmount - coin;
                if (nextAmount < 0) continue;

                if (nextAmount == 0)
                {
                    return currentCoins + 1;
                }
                else
                {
                    if (visitedAmounts.Contains(nextAmount)) continue;

                    queue.Enqueue((nextAmount, currentCoins + 1));
                    visitedAmounts.Add(nextAmount);
                }
            }
        }

        return minCoins != int.MaxValue ? minCoins : -1;
    }
}
