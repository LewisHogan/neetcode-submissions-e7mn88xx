public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        // BFS from each treasure chest to get to all
        var rows = grid.Length;
        var cols = grid[0].Length;

        var queue = new Queue<(int, int)>();
        
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                if (grid[r][c] == 0)
                {
                    queue.Enqueue((r, c));
                }
            }
        }

        while (queue.Any())
        {
            var (r, c) = queue.Dequeue();
            foreach (var (nr, nc) in GetNeighbours(r, c, rows, cols))
            {
                if (grid[nr][nc] == int.MaxValue)
                {
                    var distance = grid[r][c];
                    grid[nr][nc] = distance + 1;
                    queue.Enqueue((nr, nc));
                }
            }
        }
    }

    private IEnumerable<(int, int)> GetNeighbours(int r, int c, int rows, int cols)
    {
        (int, int)[] neighbourPositions = [
            (r -1, c),
            (r + 1, c),
            (r, c - 1),
            (r, c + 1)
        ];

        var neighbours = new List<(int, int)>();

        foreach (var neighbour in neighbourPositions)
        {
            var (nR, nC) = neighbour;
            if (nR < 0 || nR >= rows || nC < 0 || nC >= cols) continue;
            neighbours.Add(neighbour);
        }

        return neighbours;
    }
}
