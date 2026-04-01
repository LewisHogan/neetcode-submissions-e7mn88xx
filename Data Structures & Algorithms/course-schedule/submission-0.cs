public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        if (prerequisites.Length == 0) return true;

        var graph = prerequisites
            .GroupBy(pre => pre[0])
            .ToDictionary(
                group => group.Key,
                group => group
                    .Select(pre => pre[1])
                    .ToList()
        );
        
        // We should start from every prerequisite and see
        // if we encounter a visited node
        foreach (var course in graph.Keys)
        {
            if (!DFS(graph, course, new HashSet<int>())) return false;
        }

        return true;
    }

    private bool DFS(Dictionary<int, List<int>> graph, int course, HashSet<int> visited)
    {
        if (!graph.ContainsKey(course)) return true;
        if (visited.Contains(course)) return false;

        visited.Add(course);
        foreach (var reqCourse in graph[course])
        {
            if (!DFS(graph, reqCourse, visited)) return false;
        }
        visited.Remove(course);

        return true;
    }
}
