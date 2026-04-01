public class Solution {
    public List<List<int>> PacificAtlantic(int[][] heights) {
        var rows = heights.Length;
        var cols = heights[0].Length;

        var pacific = new int[rows][];
        var atlantic = new int[rows][];

        for (var i = 0; i < rows; i++)
        {
            pacific[i] = new int[cols];
            atlantic[i] = new int[cols];
        }

        var pacificSources = new List<(int, int)>();
        var atlanticSources = new List<(int, int)>();

        for (var row = 0; row < rows; row++)
        {
            pacificSources.Add((row, 0));
            atlanticSources.Add((row, cols - 1));
        }

        for (var col = 0; col < cols; col++)
        {
            pacificSources.Add((0, col));
            atlanticSources.Add((rows - 1, col));
        }
        
        BFS(heights, pacific, pacificSources);
        BFS(heights, atlantic, atlanticSources);

        var results = new List<List<int>>();

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (pacific[row][col] == 1 && atlantic[row][col] == 1)
                {
                    results.Add([row, col]);
                }
            }
        }

        return results;
    }

    private void BFS(int[][] heights, int[][] ocean, List<(int, int)> sources)
    {
        var rows = heights.Length;
        var cols = heights[0].Length;

        var queue = new Queue<(int, int)>();
        foreach (var source in sources) 
        {
            queue.Enqueue(source);
        }
        
        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
            ocean[r][c] = 1;

            var neighbours = new (int, int)[]
            {
                (r+1, c),
                (r-1, c),
                (r, c+1),
                (r, c-1)
            };

            foreach (var neighbour in neighbours)
            {
                var (nr, nc) = neighbour;
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols) continue;

                if (heights[nr][nc] >= heights[r][c] && ocean[nr][nc] != 1)
                {
                    ocean[nr][nc] = Math.Max(ocean[nr][nc], ocean[r][c]);
                    queue.Enqueue(neighbour);
                }
            }
        }
    }
}
