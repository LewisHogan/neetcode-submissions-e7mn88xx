public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var area = 0;

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                area = Math.Max(area, BFS(grid, (r, c), rows, cols));
            }
        }

        return area;
    }

    public int BFS(int[][] grid, (int, int) pos, int rows, int cols)
    {
        var queue = new Queue<(int, int)>();
        queue.Enqueue(pos);

        (int, int)[] offsets = [
            (-1, 0),
            (1, 0),
            (0, -1),
            (0, 1)
        ];

        var area = 0;

        while (queue.Any())
        {
            (int r, int c) = queue.Dequeue();
            if (grid[r][c] == 1)
            {
                grid[r][c] = 0;
                area++;
                foreach (var offset in offsets)
                {
                    var y = offset.Item1 + r;
                    var x = offset.Item2 + c;

                    if (x < 0 || x >= cols || y < 0 || y >= rows) continue;
                    queue.Enqueue((y, x));
                }
            }
        }

        return area;
    }
}
