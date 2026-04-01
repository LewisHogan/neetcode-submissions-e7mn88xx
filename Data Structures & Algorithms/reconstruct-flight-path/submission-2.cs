public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        // Backtrack
        var routes = new Dictionary<string, List<string>>();
        foreach (var ticket in tickets)
        {
            routes[ticket[0]] = [];
        }

        foreach (var ticket in tickets)
        {
            routes[ticket[0]].Add(ticket[1]);
        }

        foreach (var (key, value) in routes)
        {
            value.Sort((a, b) => a.CompareTo(b));
        }

        List<string> result = [ "JFK" ];
        DFS(routes, "JFK", tickets.Count, result);
        return result;
    }

    private bool DFS(Dictionary<string, List<string>> routes, string airport, int flightsRemaining, List<string> result)
    {
        if (flightsRemaining == 0) return true;
        if (!routes.ContainsKey(airport)) return false;

        var flights = routes[airport];
        for (var i = 0; i < flights.Count; i++)
        {
            var flight = flights[i];
            result.Add(flight);
            routes[airport].RemoveAt(i);
            if (DFS(routes, flight, flightsRemaining - 1, result))
            {
                return true;
            }
            routes[airport].Insert(i, flight);
            result.RemoveAt(result.Count - 1);
        }

        return false;
    }
}
