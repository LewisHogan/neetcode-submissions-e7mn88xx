public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {

        var rows = obstacleGrid.Length;
        var cols = obstacleGrid[0].Length;

        if (obstacleGrid[0][0] == 1) return 0;

        int DFS((int Row, int Col) pos, Dictionary<(int, int), int> cache)
        {
            if (cache.ContainsKey(pos)) return cache[pos];
            if (pos.Row == (rows - 1) && pos.Col == (cols - 1)) return 1;

            var canMoveDown = (pos.Row + 1) < rows && obstacleGrid[pos.Row + 1][pos.Col] == 0;
            var canMoveRight = (pos.Col + 1) < cols && obstacleGrid[pos.Row][pos.Col + 1] == 0;

            var combinations = 0;

            if (canMoveDown)
            {
                var searchDown = DFS((pos.Row + 1, pos.Col), cache);
                if(searchDown != 0) combinations += searchDown;
            }

            if (canMoveRight)
            {
                var searchRight = DFS((pos.Row, pos.Col + 1), cache);
                if(searchRight != 0) combinations += searchRight;
            }

            cache[pos] = combinations;
            return cache[pos];
        }

        return DFS((0, 0), new());
    }
}