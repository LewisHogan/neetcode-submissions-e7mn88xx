public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        var dict = new Dictionary<int, List<int>>();
        foreach (var req in prerequisites)
        {
            if (dict.ContainsKey(req[0]))
            {
                dict[req[0]].Add(req[1]);
            }
            else
            {
                dict[req[0]] = [req[1]];
            }
        }

        var cycle = new HashSet<int>();
        var visited = new HashSet<int>();
        var result = new List<int>();

        for (var i = 0; i < numCourses; i++)
        {
            if (!DFS(dict, cycle, visited, i, result))
            {
                return [];
            }
        }

        return result.ToArray();
    }

    private bool DFS(Dictionary<int, List<int>> reqs, HashSet<int> cycle, HashSet<int> visited, int course, List<int> result)
    {
        if (cycle.Contains(course)) return false;
        if (visited.Contains(course)) return true;

        visited.Add(course);
        cycle.Add(course);
        if (reqs.ContainsKey(course))
        {
            foreach (var req in reqs[course])
            {
                if (!DFS(reqs, cycle, visited, req, result)) return false;
            }
        }
        cycle.Remove(course);

        result.Add(course);
        return true;
    }
}
