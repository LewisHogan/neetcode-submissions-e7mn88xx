public class Solution {
    public int MostBooked(int n, int[][] meetings) {
        Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));
        var count = new int[n];
        
        var meetingRooms = new PriorityQueue<(int RoomId, int EndTime), int>();
        for (var i = 0; i < n; i++)
        {
            meetingRooms.Enqueue((i, 0), 0);
        }

        for (var i = 0; i < meetings.Length; i++)
        {
            var meeting = meetings[i];
            var startTime = meeting[0];
            var duration = meeting[1] - meeting[0];

            var availableRooms = new PriorityQueue<(int RoomId, int EndTime), int>();

            while (meetingRooms.Count > 0 && meetingRooms.Peek().EndTime <= startTime)
            {
                var availableRoom = meetingRooms.Dequeue();
                availableRooms.Enqueue(availableRoom, availableRoom.RoomId);
            }

            if (availableRooms.Count == 0)
            {
                var earliestTime = meetingRooms.Peek().EndTime;
                while (meetingRooms.Count > 0 && meetingRooms.Peek().EndTime <= earliestTime)
                {
                    var availableRoom = meetingRooms.Dequeue();
                    availableRooms.Enqueue(availableRoom, availableRoom.RoomId);
                }
            }

            var room = availableRooms.Dequeue();
            var roomEndTime = Math.Max(startTime + duration, room.EndTime + duration);
            count[room.RoomId]++;
            meetingRooms.Enqueue((room.RoomId, roomEndTime), roomEndTime);

            while (availableRooms.Count > 0)
            {
                var unusedRoom = availableRooms.Dequeue();
                meetingRooms.Enqueue(unusedRoom, unusedRoom.EndTime);
            }
        }

        var busiestRoom = 0;
        for (var i = 0; i < n; i++)
        {
            if (count[i] > count[busiestRoom]) busiestRoom = i;
        }
        
        return busiestRoom;
    }
}