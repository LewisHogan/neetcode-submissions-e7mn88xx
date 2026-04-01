public class Solution {
    public int LongestIncreasingPath(int[][] matrix) {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        var longestPath = 0;
        var cache = new Dictionary<(int, int), int>();

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                longestPath = Math.Max(longestPath, DFS(matrix, (row, col), cache));
            }
        }

        return longestPath;
    }

    private int DFS(int[][] matrix, (int Row, int Col) pos, Dictionary<(int, int), int> cache)
    {
        if (cache.ContainsKey(pos)) return cache[pos];

        var rows = matrix.Length;
        var cols = matrix[0].Length;

        var (row, col) = pos;
        var neighbors = new (int, int)[] {
            (row, col - 1),
            (row, col + 1),
            (row - 1, col),
            (row + 1, col)
        };

        var longestPath = 1;
        foreach (var (nr, nc) in neighbors)
        {
            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;
            if (matrix[nr][nc] <= matrix[row][col]) continue;

            longestPath = Math.Max(1 + DFS(matrix, (nr, nc), cache), longestPath);
        }

        cache[pos] = longestPath;
        return longestPath;
    }
}
