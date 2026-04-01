public class Solution {
    public int CountComponents(int n, int[][] edges) {
        // Create sets for each of the nodes
        // Merge the sets whenever we encounter one which isn't in the current set.
        var nodes = Enumerable.Range(0, n).ToArray();

        foreach (var edge in edges)
        {
            var firstParent = FindParent(nodes, edge[0]);
            var secondParent = FindParent(nodes, edge[1]);
            if (firstParent != secondParent)
            {
                nodes[secondParent] = firstParent;
                n--;
            }
        }

        return n;
    }

    private int FindParent(int[] nodes, int i)
    {
        var res = nodes[i];
        while (res != nodes[res])
        {
            res = nodes[res];
        }

        nodes[i] = res;
        return res;
    }
}
