public class Solution {
    public int OrangesRotting(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var freshFruit = 0;

        var queue = new Queue<(int, int, int)>();
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                switch (grid[row][col])
                {
                    case 1:
                        freshFruit++;
                        break;
                    case 2:
                        queue.Enqueue((row, col, 0));
                        break;
                }
            }
        }

        var maxSteps = 0;
        
        while (queue.Any() && freshFruit != 0)
        {
            var (r, c, steps) = queue.Dequeue();

            foreach (var (nr, nc) in GetNeighbours(r, c, rows, cols))
            {
                if (grid[nr][nc] == 1)
                {
                    grid[nr][nc] = 2;
                    freshFruit--;
                    maxSteps = Math.Max(maxSteps, 1 + steps);
                    queue.Enqueue((nr, nc, 1 + steps));
                }
            }
        }

        return freshFruit == 0 ? maxSteps : -1;
    }

    private IEnumerable<(int, int)> GetNeighbours(int r, int c, int rows, int cols)
    {
        (int, int)[] offsets = [
            (-1, 0),
            (1, 0),
            (0, -1),
            (0, 1)
        ];

        var neighbours = new List<(int, int)>();

        foreach(var offset in offsets)
        {
            var nr = r + offset.Item1;
            var nc = c + offset.Item2;

            if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;

            neighbours.Add((nr, nc));
        }

        return neighbours;
    }
}
