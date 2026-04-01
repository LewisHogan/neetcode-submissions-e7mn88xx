public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        // highest eating rate is going to be max(piles)
        // lowest eating rate needs to be found through binary search but we can assume
        // 1 and work up
        var lowEatingRate = 1;
        var highEatingRate = Math.Max(piles.Length / h, piles.Max());

        var bestEatingRate = highEatingRate;

        while (lowEatingRate <= highEatingRate) {
            var midEatingRate = lowEatingRate + (highEatingRate - lowEatingRate) / 2;

            var timeToEat = (int) piles.Select(pile => Math.Ceiling((double) pile / midEatingRate)).Sum();

            if (timeToEat <= h) {
                bestEatingRate = midEatingRate;
                highEatingRate = midEatingRate - 1;
            } else {
                lowEatingRate = midEatingRate + 1;
            }
        }

        return bestEatingRate;
    }
}
