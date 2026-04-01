public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int[] p = Enumerable.Range(0, edges.Length + 1).ToArray();
        int Find(int i) => p[i] == i ? i : p[i] = Find(p[i]);

        foreach (var edge in edges)
        {
            var u = Find(edge[0]);
            var v = Find(edge[1]);

            if (u == v) return edge;
            p[u] = p[v];
        }

        return [];
    }
}
