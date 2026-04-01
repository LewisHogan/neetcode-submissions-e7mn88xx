class DSU
{
    int[] Parents { get; set;}

    public DSU(int n)
    {
        Parents = new int[n + 1];
        for (var i = 1; i <= n; i++)
        {
            Parents[i] = i;
        }
    }

    public int FindParent(int a)
    {
        var parent = Parents[a];
        while (parent != Parents[parent])
        {
            Parents[parent] = Parents[Parents[parent]];
            parent = Parents[parent];
        }
        return parent;
    }

    public bool Union(int a, int b)
    {
        var aParent = FindParent(a);
        var bParent = FindParent(b);

        if (aParent != bParent)
        {
            Parents[bParent] = aParent;
            return true;
        }

        return false;
    }
}

public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        DSU dsu = new(edges.Length);
        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            if (!dsu.Union(u, v))
            {
                return edge;
            }
        }

        return [];
    }
}
