public class Solution {
    public bool IsValid(string s) {
        var characterMap = new Dictionary<char, char>()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        var stack = new Stack<char>();
        foreach (var c in s) {
            if ("([{".Contains(c)) {
                stack.Push(c);
            } else if (characterMap.ContainsKey(c)) {
                if (stack.Any() && characterMap[c] == stack.Peek()) {
                    stack.Pop();
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        return stack.Count == 0;
    }
}
