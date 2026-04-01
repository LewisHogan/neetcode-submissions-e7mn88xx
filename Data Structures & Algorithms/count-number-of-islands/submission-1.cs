public class Solution {
    public int NumIslands(char[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var islands = 0;
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (grid[row][col] == '1')
                {
                    islands++;
                    BFS(grid, (row, col));
                }
            }
        }

        return islands;
    }

    private void BFS(char[][] grid, (int, int) startPos)
    {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var queue = new Queue<(int, int)>();

        queue.Enqueue(startPos);

        while (queue.Count > 0)
        {
            var (row, col) = queue.Dequeue();

            grid[row][col] = '0';

            (int, int)[] offsets = [
                (row, col-1),
                (row, col+1),
                (row-1, col),
                (row+1, col)
            ];

            foreach (var (oRow, oCol) in offsets)
            {
                if (oRow < 0 || oRow >= rows || oCol < 0 || oCol >= cols) continue;
                if (grid[oRow][oCol] == '1')
                {
                    queue.Enqueue((oRow, oCol));
                }
            }
        }
    }
}
