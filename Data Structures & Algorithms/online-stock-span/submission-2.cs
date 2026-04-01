public class StockSpanner {

    private Stack<(int Price, int Span)> stack;

    public StockSpanner() {
        stack = new();
    }
    
    public int Next(int price) {
        if (stack.Count == 0)
        {
            stack.Push((price, 1));
            return 1;
        }
        else
        {
            var span = 1;
            while (stack.Count > 0 && stack.Peek().Price <= price)
            {
                span += stack.Pop().Span;
            }
            stack.Push((price, span));
            return span;
        }
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */