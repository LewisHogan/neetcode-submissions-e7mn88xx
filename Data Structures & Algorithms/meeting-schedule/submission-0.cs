/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        if (intervals.Count == 0) return true;
        intervals.Sort((a, b) => a.start.CompareTo(b.start));

        var latestEnding = int.MinValue;

        foreach (var interval in intervals)
        {
            if (interval.start >= latestEnding)
            {
                latestEnding = Math.Max(latestEnding, interval.end);
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}
