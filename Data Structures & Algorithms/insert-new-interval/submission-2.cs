public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        if (intervals.Length == 0) return [newInterval];

        var results = new List<int[]>();
        for (var i = 0; i < intervals.Length; i++)
        {
            if (intervals[i][1] < newInterval[0])
            {
                // interval is entirely smaller, add it to the results since it's already sorted
                results.Add(intervals[i]);
            }
            else if (newInterval[1] < intervals[i][0])
            {
                // All the ones from here on are bigger, so we can put the new interval in and then
                // just add the rest in one go
                results.Add(newInterval);
                results.AddRange(intervals.AsEnumerable().Skip(i));

                return results.ToArray();
            }
            else
            {
                // Overlapping, merge them and don't add to the results yet
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            }
        }

        results.Add(newInterval);

        return results.ToArray();
    }
}
