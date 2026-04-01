public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        var queue = new PriorityQueue<(int Index, int Cost), int>();
        var visited = new HashSet<int>();

        var totalCost = 0;

        queue.Enqueue((0, 0), 0);

        while (queue.Count > 0 && visited.Count < points.Length)
        {
            var (index, cost) = queue.Dequeue();
            if (visited.Contains(index)) continue;

            visited.Add(index);
            totalCost += cost;

            for (var i = 0; i < points.Length; i++)
            {
                if (visited.Contains(i)) continue;
                queue.Enqueue((i, Distance(points[index], points[i])), Distance(points[index], points[i]));
            }
        }

        return totalCost;
    }

    private int Distance(int[] a, int[] b)
        => Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
}
