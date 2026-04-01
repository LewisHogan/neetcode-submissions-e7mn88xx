public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        
        var sortedQueries = queries
            .OrderBy(q => q)
            .ToArray();
        
        // (interval end, interval length)
        var minHeap = new PriorityQueue<(int End, int Len), int>();
        var lookup = new Dictionary<int, int>();
        var index = 0;

        foreach(var query in sortedQueries)
        {
            while (index < intervals.Length && intervals[index][0] <= query)
            {
                var start = intervals[index][0];
                var end = intervals[index][1];
                var len = end - start + 1;
                minHeap.Enqueue((end, len), len);
                index++;
            }

            while (minHeap.Count != 0 && minHeap.Peek().End < query)
            {
                minHeap.Dequeue();
            }

            lookup[query] = minHeap.Count != 0 ? minHeap.Peek().Len : -1;
        }

        var results = new int[queries.Length];
        for (var i = 0; i < queries.Length; i++)
        {
            results[i] = lookup[queries[i]];
        }

        return results;
    }
}
