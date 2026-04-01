public class MedianFinder {

    private PriorityQueue<int, int> minHeap;
    private PriorityQueue<int, int> maxHeap;

    public MedianFinder() {
        minHeap = new PriorityQueue<int, int>();
        maxHeap = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        // Always add to maxHeap first, then rebalance
        maxHeap.Enqueue(num, -num);
        minHeap.Enqueue(maxHeap.Peek(), maxHeap.Dequeue());

        if (minHeap.Count > maxHeap.Count)
        {
            var val = minHeap.Dequeue();
            maxHeap.Enqueue(val, -val);
        }
    }
    
    public double FindMedian() {
        if ((minHeap.Count + maxHeap.Count) % 2 == 0)
        {
            return (minHeap.Peek() + maxHeap.Peek()) / 2.0;
        }
        else
        {
            return maxHeap.Peek();
        }
    }
}
