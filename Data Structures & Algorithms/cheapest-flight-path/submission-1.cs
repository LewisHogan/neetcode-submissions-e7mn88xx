public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        // BFS from start to dest
        var routes = new Dictionary<int, List<(int, int)>>();
        foreach (var flight in flights)
        {
            var from = flight[0];
            var to = flight[1];
            var price = flight[2];

            if (!routes.ContainsKey(from)) routes[from] = [];
            routes[from].Add((to, price));
        }

        var cheapestRoute = BFS(routes, src, dst, k);
        if (cheapestRoute == int.MaxValue)
        {
            return -1;
        }

        return cheapestRoute;
    }

    int BFS(Dictionary<int, List<(int, int)>> routes, int src, int dst, int k)
    {
        var queue = new PriorityQueue<(int, int, int), int>();
        queue.Enqueue((src, 0, 0), 0);

        var lowestPrice = int.MaxValue;

        while (queue.Count > 0)
        {
            var (airport, price, flightsTaken) = queue.Dequeue();

            if (flightsTaken > k) continue;
            if (!routes.ContainsKey(airport)) continue;

            foreach (var (destination, cost) in routes[airport])
            {
                if (destination == dst)
                {
                    lowestPrice = Math.Min(lowestPrice, price + cost);
                    continue;
                }

                if (price + cost < lowestPrice)
                {
                    queue.Enqueue((destination, price + cost, flightsTaken + 1), price + cost);
                }
            }
        }

        return lowestPrice;
    }
}
