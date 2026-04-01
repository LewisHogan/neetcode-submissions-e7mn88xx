public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        IEnumerable<(int Row, int Col)> GetNeighbours((int Row, int Col) pos)
        {
            var (row, col) = pos;
            (int, int)[] neighbours = [
                (row - 1, col),
                (row + 1, col),
                (row, col -1),
                (row, col + 1)
            ];

            foreach (var neighbour in neighbours)
            {
                var (nr, nc) = neighbour;
                if (0 <= nr && nr < heights.Length && 0 <= nc && nc < heights[0].Length)
                {
                    yield return neighbour;
                }
            }
        }

        int BFS()
        {
            var startPos = (0, 0);
            var queue = new PriorityQueue<((int Row, int Col), int HeightDiff), int>();
            
            var visited = new HashSet<(int Row, int Col)>();
            var maxDiff = 0;

            queue.Enqueue(((startPos), 0), 0);
            while (queue.Count > 0)
            {
                var (pos, heightDiff) = queue.Dequeue();
                maxDiff = Math.Max(maxDiff, heightDiff);
                visited.Add(pos);
                if (pos == (heights.Length - 1, heights[0].Length - 1))
                {
                    return maxDiff;
                }

                foreach (var neighbour in GetNeighbours(pos))
                {
                    if (visited.Contains(neighbour)) continue;

                    var heightDistance = Math.Abs(heights[pos.Row][pos.Col] - heights[neighbour.Row][neighbour.Col]);
                    queue.Enqueue((neighbour, heightDistance), heightDistance);
                }
            }

            return maxDiff;
        }

        return BFS();
    }
}