public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if (intervals.Length <= 1) return 0;

        var sorted = intervals
            .OrderBy(i => i[0])
            .ThenBy(i => i[1])
            .ToList();
        
        var removed = 0;
        var prevEnd = sorted[0][1];
        for (var i = 1; i < sorted.Count; i++)
        {
            if (sorted[i][0] < prevEnd)
            {
                removed++;
                prevEnd = Math.Min(prevEnd, sorted[i][1]);
            }
            else
            {
                prevEnd = sorted[i][1];
            }
        }

        return removed;
    }
}
