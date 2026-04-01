public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var islandIndex = 2;

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                if (IsIslandTile(grid, r, c, rows, cols, islandIndex)) {
                    islandIndex++;
                }
            }
        }

        var islandFreq = new int[islandIndex + 2];

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                if (grid[r][c] > 1)
                {
                    islandFreq[grid[r][c]]++;
                }
            }
        }

        var biggestIsland = 0;
        foreach (var area in islandFreq) {
            biggestIsland = Math.Max(area, biggestIsland);
        }

        return biggestIsland;
    }

    private bool IsIslandTile(int[][] grid, int r, int c, int rows, int cols, int islandIndex)
    {
        if (r < 0 || r >= rows || c < 0 || c >= cols) return false;
        if (grid[r][c] != 1) return false;

        Queue<(int, int)> tiles = new Queue<(int, int)>();

        tiles.Enqueue((r, c));

        (int, int)[] offsets = [
            (-1, 0),
            (+1, 0),
            (0, -1),
            (0, +1)
        ];

        var foundNewIsland = false;

        while (tiles.Any())
        {
            (int nr, int nc) = tiles.Dequeue();
            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;

            if (grid[nr][nc] == 1)
            {
                foundNewIsland = true;
                grid[nr][nc] = islandIndex;
                foreach (var offset in offsets)
                {
                    tiles.Enqueue((nr + offset.Item1, nc + offset.Item2));
                }
            }
        }

        return foundNewIsland;
    }
}
