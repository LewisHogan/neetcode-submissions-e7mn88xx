public class FreqStack {

    Dictionary<int, int> frequencies;
    List<List<int>> stacks;

    public FreqStack() {
        frequencies = new();
        stacks = new() { new() };
    }
    
    public void Push(int val) {
        var freq = frequencies.ContainsKey(val) ? frequencies[val] + 1 : 1;
        frequencies[val] = freq;
        if (stacks.Count == freq)
        {
            stacks.Add(new());
        }
        stacks[freq].Add(val);
    }
    
    public int Pop() {
        var last = stacks[^1];
        var val = last[^1];
        frequencies[val] -= 1;
        stacks[^1].RemoveAt(last.Count - 1);

        if (frequencies[val] == 0)
        {
            frequencies.Remove(val);
        }
        if (last.Count == 0)
        {
            stacks.RemoveAt(stacks.Count - 1);
        }

        return val;
    }
}

/**
 * Your FreqStack object will be instantiated and called as such:
 * FreqStack obj = new FreqStack();
 * obj.Push(val);
 * int param_2 = obj.Pop();
 */