public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var routing = times
            .GroupBy(route => route[0])
            .ToDictionary(
                g => g.Key,
                g => g.Select(r => (r[1], r[2])).ToList()
            );

        // Node, min time to reach the node
        var visitedNodes = new Dictionary<int, int>();

        var queue = new PriorityQueue<(int, int), int>();
        queue.Enqueue((k, 0), 0);

        while (queue.Count != 0)
        {
            var (node, time) = queue.Dequeue();
            if (visitedNodes.ContainsKey(node)) continue;
            visitedNodes[node] = time;

            if (!routing.ContainsKey(node)) continue;

            foreach (var (destination, travelTime) in routing[node])
            {
                var timeToDestination = time + travelTime;
                queue.Enqueue((destination, timeToDestination), timeToDestination);
            }
        }

        if (visitedNodes.Count == n)
        {
            var max = 0;
            foreach (var (_, time) in visitedNodes)
            {
                max = Math.Max(max, time);
            }
            return max;
        }

        return -1;
    }
}
