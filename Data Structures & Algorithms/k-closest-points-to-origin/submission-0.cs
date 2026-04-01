public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var minHeap = new PriorityQueue<int[], double>();

        foreach (var point in points)
        {
            // Since we are using a negative distance it means we will pop the larger results first
            // meaning we store the smallest k results
            minHeap.Enqueue(point, -CalculateDistance(point));
            if (minHeap.Count > k) minHeap.Dequeue();
        }

        var results = new int[k][];
        var i = 0;
        while (minHeap.Count > 0 && i < k)
        {
            results[i++] = minHeap.Dequeue();
        }

        return results;
    }

    // Calculate distance from the origin, 
    internal double CalculateDistance(int[] point)
        => (point[0] * point[0]) + (point[1] * point[1]);
}
