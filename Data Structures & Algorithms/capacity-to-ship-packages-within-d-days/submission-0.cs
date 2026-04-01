public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        // Binary search should be able to do this
        var left = weights.Max(); // Min capacity must be the largest single weight we need to move
        var right = weights.Sum(); // Max capacity would be all the weights in one day
        var best = right;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            var daysToShip = CalcDaysToShip(weights, mid);

            if (daysToShip <= days)
            {
                best = Math.Min(best, mid);
                right = mid - 1;
            }
            else
            {
                // This is a valid solution, but it might not be the optimal solution, so keep searching
                left = mid + 1;
            }
        }

        return best;
    }

    int CalcDaysToShip(int[] weights, int shipCapacity)
    {
        var weightsToShip = new Queue<int>();
        foreach (var weight in weights)
        {
            weightsToShip.Enqueue(weight);
        }

        var days = 0;
        while (weightsToShip.Count > 0)
        {
            var capacityRemaining = shipCapacity;
            while (weightsToShip.Count > 0 && capacityRemaining > 0)
            {
                if (weightsToShip.Peek() > capacityRemaining) break;
                capacityRemaining -= weightsToShip.Dequeue();
            }
            days++;
        }

        return days;
    }
}