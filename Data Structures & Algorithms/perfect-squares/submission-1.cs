public class Solution {
    public int NumSquares(int n) {
        var dp = new int[n + 1];
        Array.Fill(dp, n);
        dp[0] = 0;

        for (var i = 1; i <= n; i++)
        {
            for (var s = 1; s * s <= i; s++)
            {
                var square = s * s;
                dp[i] = Math.Min(dp[i], dp[i - square] + 1);
            }
        }

        return dp[n];
    }
}