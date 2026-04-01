public class StockSpanner {

    private Stack<int> stack;

    public StockSpanner() {
        stack = new();
    }
    
    public int Next(int price) {
        if (stack.Count == 0)
        {
            stack.Push(price);
            return 1;
        }
        else
        {
            var tmp = new Stack<int>();
            while (stack.Count > 0 && stack.Peek() <= price)
            {
                tmp.Push(stack.Pop());
            }

            var res = tmp.Count + 1;
            while (tmp.Count > 0)
            {
                stack.Push(tmp.Pop());
            }
            stack.Push(price);
            return res;
        }
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */