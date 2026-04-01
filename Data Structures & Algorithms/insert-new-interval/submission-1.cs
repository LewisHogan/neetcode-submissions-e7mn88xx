public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        // An interval is overlapping if the one with the later start
        // time starts before the end of the interval before it
        if (intervals.Length == 0) return [newInterval];

        var res = new List<int[]>(intervals);

        var newIntervalIndex = res.FindIndex(res => res[0] > newInterval[0]);
        if (newIntervalIndex != -1)
        {
            res.Insert(newIntervalIndex, newInterval);
        }
        else
        {
            res.Add(newInterval);
        }

        var previousEnd = res[0][1];

        for (var i = 1; i < res.Count; i++)
        {
            if (res[i][0] <= previousEnd)
            {
                res[i-1][1] = Math.Max(res[i][1], res[i-1][1]);
                res.RemoveAt(i);
                i--;
            }

            if (i < res.Count - 1) previousEnd = res[i][1];
        }

        return res.ToArray();
    }
}
