public class Solution {
    public int NumSquares(int n) {
        var dp = new int[n + 1];
        Array.Fill(dp, n);
        dp[0] = 0;

        for (var i = 1; i <= n; i++)
        {
            var squares = Enumerable
                .Range(1, i)
                .Select(i => i * i);
            
            foreach (var square in squares)
            {
                if (square > i) break;

                dp[i] = Math.Min(dp[i], dp[i - square] + 1);
            }
        }

        return dp[n];
    }
}