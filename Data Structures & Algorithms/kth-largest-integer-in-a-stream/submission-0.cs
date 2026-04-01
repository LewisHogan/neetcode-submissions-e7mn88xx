public class KthLargest {

    private int maxSize;
    private PriorityQueue<int, int> minHeap;

    public KthLargest(int k, int[] nums) {
        maxSize = k;
        minHeap = new PriorityQueue<int, int>();
        foreach (var num in nums) {
            Add(num);
        }
    }
    
    public int Add(int val) {
        minHeap.Enqueue(val, val);
        while (minHeap.Count > maxSize) {
            minHeap.Dequeue();
        }

        return minHeap.Peek();
    }
}
