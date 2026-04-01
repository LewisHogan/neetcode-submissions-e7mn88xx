public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        // At each station we need to compute the difference between the amount of gas we can gain and the amount of gas we hold

        if (gas.Sum() < cost.Sum()) return -1;

        var total = 0;
        var result = 0;
        for (var i = 0; i < cost.Length; i++)
        {
            total += gas[i] - cost[i];
            if (total < 0) 
            {
                total = 0;
                result = (i + 1) % cost.Length;
                continue;
            }
        }

        return result;
    }
}
