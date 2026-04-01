public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach (var token in tokens)
        {
            if ("+-/*".Contains(token))
            {
                    var ro = stack.Pop();
                    var lo = stack.Pop();
                    
                    switch (token)
                    {
                        case "+":
                            stack.Push(lo + ro);
                            break;
                        case "-":
                            stack.Push(lo - ro);
                            break;
                        case "*":
                            stack.Push(lo * ro);
                            break;
                        case "/":
                            stack.Push(lo / ro);
                            break;
                    }
            }
            else
            {
                stack.Push(int.Parse(token));
            }

        }

        return stack.Pop();
    }
}
