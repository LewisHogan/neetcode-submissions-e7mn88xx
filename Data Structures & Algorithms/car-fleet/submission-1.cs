public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        // Simulate steps, group any cars which are then in the same position
        // as another car

        var carOrder = Enumerable
            .Range(0, position.Length)
            .Zip(position)
            .OrderByDescending(pair => pair.Item2)
            .Select(pair => pair.Item1);

        var stack = new Stack<decimal>();
        foreach (var car in carOrder)
        {
            // Anything after this will never reach the target
            if (speed[car] == 0) return stack.Count;

            var timeToReachEnd = (target - position[car]) / (decimal)speed[car];

            if (stack.Count == 0)
            {
                stack.Push(timeToReachEnd);
            }
            else if (timeToReachEnd > stack.Peek())
            {
                stack.Push(timeToReachEnd);
            }
        }

        return stack.Count;
    }
}
