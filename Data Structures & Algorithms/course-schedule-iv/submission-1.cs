public class Solution {
    public List<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        // We need to build a dependency graph
        // and then for each query we need to check
        // for each query_j if u is a prerequisite of v

        // For each prereq, [0] is the course you need to take first
        // [1] is the course you can take only after you've done [0]

        // Our graph is going to store nodes and what they depend on
        var dependencyGraph = prerequisites
            .GroupBy(req => req[1])
            .ToDictionary(
                grp => grp.Key,
                grp => grp.Select(e => e[0])
            );

        var answers = new List<bool>();
        var cache = new Dictionary<(int, int), bool>();
        foreach (var query in queries)
        {
            answers.Add(DFS(dependencyGraph, query[1], query[0], new(), cache));
        }

        return answers;
    }

    bool DFS(Dictionary<int, IEnumerable<int>> graph, int source, int target, HashSet<int> visited, Dictionary<(int, int), bool> cache)
    {
        if (cache.ContainsKey((source, target))) return cache[(source, target)];

        if (!graph.ContainsKey(source))
        {
            cache[(source, target)] = false;
            return false;
        }

        foreach (var node in graph[source])
        {
            if (visited.Contains(node)) continue;
            if (node == target)
            {
                cache[(source, target)] = true;
                return true;
            }

            visited.Add(source);
            if (DFS(graph, node, target, visited, cache))
            {
                cache[(source, target)] = true;
                return true;
            }
        }

        cache[(source, target)] = false;
        return false;
    }
}