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
    public int MinMeetingRooms(List<Interval> intervals) {
        if (intervals.Count == 0) return 0;
        
        var sorted = intervals
            .OrderBy(interval => interval.start)
            .ThenBy(interval => interval.end)
            .ToList();
        
        var activeMeetings = new PriorityQueue<Interval, int>();
        var overlaps = 0;

        foreach (var interval in sorted)
        {
            if (activeMeetings.Count > 0)
            {
                if (interval.start < activeMeetings.Peek().end)
                {
                    overlaps++;
                }
                else
                {
                    activeMeetings.Dequeue();
                }
            }
            
            activeMeetings.Enqueue(interval, interval.end);
        }

        return 1 + overlaps;
    }
}
