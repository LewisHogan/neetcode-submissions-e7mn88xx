public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        if (hand.Length % groupSize != 0) return false;

        Array.Sort(hand);

        var freq = new Dictionary<int, int>();
        foreach (var n in hand)
        {
            if (freq.ContainsKey(n))
            {
                freq[n]++;
            }
            else
            {
                freq[n] = 1;
            }
        }

        foreach (var num in hand)
        {
            if (freq.ContainsKey(num) && freq[num] > 0)
            {
                for (var i = 0; i < groupSize; i++)
                {
                    if (!freq.ContainsKey(num + i) || freq[num + i] == 0) return false;
                    freq[num + i]--;
                }
            }
        }

        return true;
    }
}
