public class Solution {
    public bool CanReach(string s, int minJump, int maxJump) {
        return DFS(s, s.Length - 1, minJump, maxJump, new());
    }

    bool DFS(string s, int i, int minJump, int maxJump, Dictionary<int, bool> cache)
    {
        if (s[i] == '1') return false;
        // Working backwards from the last index, if we can reach index 0 we can do
        // the entire route
        if (cache.ContainsKey(i)) return cache[i];
        if (i == 0) return true;

        for (var j = minJump; j <= maxJump; j++)
        {
            if (i - j < 0) break;

            if (s[i - j] == '0')
            {
                if (DFS(s, i - j, minJump, maxJump, cache))
                {
                    cache[i - j] = true;
                    return true;
                }
            }
            cache[i - j] = false;
        }

        cache[i] = false;
        return false;
    }
}