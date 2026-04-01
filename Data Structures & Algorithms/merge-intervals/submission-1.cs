public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var results = new List<int[]>();

        for (var i = 0; i < intervals.Length; i++)
        {
            if (i == 0)
            {
                results.Add(intervals[i]);
            }
            else
            {
                var start = intervals[i][0];
                var prevEnd = results[^1][1];
                if (prevEnd >= start)
                {
                    results[^1][1] = Math.Max(intervals[i][1], results[^1][1]);
                }
                else
                {
                    results.Add(intervals[i]);
                }
            }
        }

        return results.ToArray();
    }
}
