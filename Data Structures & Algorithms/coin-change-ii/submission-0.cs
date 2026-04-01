public class Solution {
    public int Change(int amount, int[] coins) {
        Array.Sort(coins);
        var cache = new Dictionary<(int, int), int>();
        return DFS(0, amount, coins, cache);
    }

    int DFS(int i, int amount, int[] coins, Dictionary<(int,int), int> cache)
    {
        if (amount == 0) return 1;
        if (amount < 0) return 0;
        if (cache.ContainsKey((i, amount))) return cache[(i, amount)];

        var combos = 0;
        for (var j = i; j < coins.Length; j++)
        {
            var coin = coins[j];
            combos += DFS(j, amount - coin, coins, cache);
        }

        cache[(i, amount)] = combos;
        return combos;
    }
}
