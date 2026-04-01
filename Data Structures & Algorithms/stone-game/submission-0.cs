public class Solution {
    public bool StoneGame(int[] piles) {
        // DFS
        // Optimal play does not always means taking the biggest pile
        // at the front, if it means you can force the other play to take
        // a subpar pile

        return DFS(piles, 0, piles.Length - 1, 0, true, new()) > 0;
    }

    int DFS(int[] piles, int i, int j, int score, bool isAliceTurn, Dictionary<(int, int, bool), int> cache)
    {
        if (i == j) return score;
        var key = (i, j, isAliceTurn);
        if (cache.ContainsKey(key)) return cache[key];

        // Alice plays to maximise, Bob plays to minimise
        if (isAliceTurn)
        {
            cache[key] = Math.Max(
                DFS(piles, i + 1, j, score + piles[i], !isAliceTurn, cache),
                DFS(piles, i, j - 1, score + piles[j], !isAliceTurn, cache)
            );
        }
        else
        {
            cache[key] = Math.Min(
                DFS(piles, i + 1, j, score + piles[i], !isAliceTurn, cache),
                DFS(piles, i, j - 1, score + piles[j], !isAliceTurn, cache)
            );
        }

        return cache[key];
    }
}