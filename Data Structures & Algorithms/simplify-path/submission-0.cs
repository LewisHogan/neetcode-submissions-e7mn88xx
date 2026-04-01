public class Solution {
    public string SimplifyPath(string path) {
        var parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<string>();

        foreach (var part in parts)
        {
            if (part == "..")
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else if (part != ".")
            {
                stack.Push(part);
            }
        }

        var result = new List<string>(stack);
        result.Reverse();
        return "/" + string.Join("/", result);
    }
}