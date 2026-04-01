public class Solution {
    public List<List<int>> Combine(int n, int k) {
        var numbers = Enumerable
            .Range(1, n + 1)
            .ToArray();
        
        var results = new List<List<int>>();

        for (var i = 0; i < Math.Pow(2, n); i++)
        {
            var combo = new List<int>();
            if (CountBits(i) != k) continue;

            for (var j = 0; j < numbers.Length; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    combo.Add(numbers[j]);
                }
            }
            results.Add(combo);
        }

        return results;
    }

    int CountBits(int x)
    {
        var count = 0;
        while (x != 0)
        {
            count += (x & 1);
            x >>= 1;
        }

        return count;
    }
}