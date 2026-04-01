public class MinStack {

    private (int Val, int Min)[] _elements;

    private int _top = 0;
    private const int DefaultCapacity = 5;

    public MinStack() {
        _elements = new (int Val, int Min)[DefaultCapacity];
    }
    
    public void Push(int val) {
        if (_top == _elements.Length)
        {
            var tmp = _elements;
            _elements = new (int, int)[_elements.Length * 2];
            Array.Copy(tmp, _elements, tmp.Length);
        }

        int currentMin = (_top == 0) ? val : Math.Min(_elements[_top - 1].Min, val);
        _elements[_top] = (val, currentMin);
        _top++;
    }
    
    public void Pop() {
        _top--;
    }
    
    public int Top() {
        return _elements[_top - 1].Val;
    }
    
    public int GetMin() {
        return _elements[_top - 1].Min;
    }
}
