public class MyCircularQueue {

    int[] Data;

    int Head {get; set;}
    int Tail {get; set;}

    public MyCircularQueue(int k) {
        Data = new int[k+1];
    }
    
    public bool EnQueue(int value) {
        if (IsFull()) return false;
        Tail = (Tail + 1) % Data.Length;
        Data[Tail] = value;
        return true;
    }
    
    public bool DeQueue() {
        if (IsEmpty()) return false;
        Head = (Head + 1) % Data.Length;
        return true;
    }
    
    public int Front() {
        if (IsEmpty()) return -1;
        return Data[(Head + 1) % Data.Length];
    }
    
    public int Rear() {
        if (IsEmpty()) return -1;
        return Data[Tail];
    }
    
    public bool IsEmpty() {
        return Head == Tail;
    }
    
    public bool IsFull() {
        return (Tail + 1) % Data.Length == Head;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */