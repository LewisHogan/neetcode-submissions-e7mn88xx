public class Solution {
    public string StoneGameIII(int[] stoneValue) {
        var result = DFS(stoneValue, 0, true, new());
        return result switch {
            > 0 => "Alice",
            < 0 => "Bob",
            _ => "Tie"
        };
    }

    int DFS(int[] stoneValue, int firstIndex, bool isAliceTurn, Dictionary<(int, bool), int> cache)
    {
        if (firstIndex >= stoneValue.Length) return 0;
        
        var key = (firstIndex, isAliceTurn);
        if (cache.ContainsKey(key)) return cache[key];

        var score = isAliceTurn ? int.MinValue : int.MaxValue;

        for (var i = 1; i <= 3; i++)
        {
            var lastIndex = firstIndex + i;
            if (lastIndex > stoneValue.Length) break;

            var stones = stoneValue[firstIndex..lastIndex];

            if (isAliceTurn)
            {
                score = Math.Max(score, stones.Sum() + DFS(stoneValue, lastIndex, !isAliceTurn, cache));
            }
            else
            {
                score = Math.Min(score, DFS(stoneValue, lastIndex, !isAliceTurn, cache) - stones.Sum());
            }
        }

        cache[key] = score;
        return cache[key];
    }
}