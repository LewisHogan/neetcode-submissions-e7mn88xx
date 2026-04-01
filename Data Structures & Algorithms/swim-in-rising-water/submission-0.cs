public class Solution {
    public int SwimInWater(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;

        var queue = new PriorityQueue<(int, int), int>();
        queue.Enqueue((0, 0), grid[0][0]);

        var maximumWaterLevel = grid[0][0];

        var visited = new HashSet<(int, int)>();

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
            maximumWaterLevel = Math.Max(maximumWaterLevel, grid[r][c]);

            if (r == rows -1 && c == cols -1) return maximumWaterLevel;

            var otherTiles = new (int, int)[]
            {
                (r-1, c),
                (r, c+1),
                (r+1, c),
                (r, c-1)
            };

            visited.Add((r, c));
            foreach (var other in otherTiles)
            {
                if (visited.Contains(other)) continue;
                var (oR, oC) = other;
                if (oR < 0 || oR >= rows || oC < 0 || oC >= cols) continue;
                
                queue.Enqueue(other, grid[oR][oC]);
            }
        }

        return maximumWaterLevel;
    }
}
