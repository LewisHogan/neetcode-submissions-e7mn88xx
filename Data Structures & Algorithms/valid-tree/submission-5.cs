public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length == 0 && n == 1) return true;
        if (edges.Length != n - 1) return false;
        // Do a DFS, if it's a cycle then it's not a valid tree
        var dict = new Dictionary<int, List<int>>();
        for (var i = 0; i < n; i++)
        {
            dict[i] = [];
        }

        foreach (var edge in edges)
        {
            dict[edge[0]].Add(edge[1]);
            dict[edge[1]].Add(edge[0]);
        }

        var visited = new HashSet<int>();
        DFS(dict, edges[0][0], -1, visited);
        return visited.Count == n;
    }

    private bool DFS(Dictionary<int, List<int>> map, int node, int parent, HashSet<int> visited)
    {
        if (visited.Contains(node)) return false;

        visited.Add(node);
        foreach (var neighbour in map[node])
        {
            if (neighbour == parent) continue;
            if (!DFS(map, neighbour, node, visited)) return false;
        }

        return true;
    }
}
