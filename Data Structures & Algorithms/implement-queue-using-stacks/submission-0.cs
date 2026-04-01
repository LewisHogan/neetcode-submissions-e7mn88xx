public class MyQueue {

    Stack<int> first;
    Stack<int> second;

    public MyQueue() {
        first = new();
        second = new();
    }
    
    public void Push(int x) {
        first.Push(x);
    }
    
    public int Pop() {
        if (second.Count > 0) return second.Pop();
        while (first.Count > 0) second.Push(first.Pop());
        return second.Pop();
    }
    
    public int Peek() {
        if (second.Count > 0) return second.Peek();
        while (first.Count > 0) second.Push(first.Pop());
        return second.Peek();
    }
    
    public bool Empty() {
        return first.Count == 0 && second.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */