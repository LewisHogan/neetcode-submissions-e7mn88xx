public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        // Bottom up approach
        // we only depend on the previous row and the previous cols
        var rows = obstacleGrid.Length;
        var cols = obstacleGrid[0].Length;
        
        // Bottom row of the grid, starts with 1 possible route as long
        // as there isn't an obstacle in the way
        var dp = new int[cols];
        dp[^1] = obstacleGrid[rows-1][cols-1] == 0 ? 1 : 0;
        for (var i = cols - 2; i >= 0; i--)
        {
            dp[i] = obstacleGrid[rows-1][i] == 0 ? dp[i + 1] : 0;
        }

        // For each row above the bottom row, we add the combos of the row
        // beneath us (if it's possible) and the column on the right
        for (var i = rows - 2; i >= 0; i--)
        {
            for (var j = cols - 1; j >= 0; j--)
            {
                if (j == cols - 1) // We can only go down here
                {
                    dp[j] = obstacleGrid[i][j] == 0 ? dp[j] : 0;
                }
                else
                {
                    dp[j] = obstacleGrid[i][j] == 0 ? dp[j] + dp[j + 1] : 0;
                }
            }
        }

        return dp[0];
    }
}