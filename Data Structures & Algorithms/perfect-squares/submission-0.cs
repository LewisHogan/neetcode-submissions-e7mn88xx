public class Solution {
    public int NumSquares(int n) {
        var perfectSquares = Enumerable
            .Range(1, (int)Math.Sqrt(n))
            .Select(i => i * i)
            .ToArray();
        
        return NumSquares(perfectSquares, n, new());
    }

    int NumSquares(int[] perfectSquares, int n, Dictionary<int, int> cache)
    {
        if (n == 0) return 0;
        if (cache.ContainsKey(n)) return cache[n];

        var bestResult = int.MaxValue;
        
        var index = Array.BinarySearch(perfectSquares, n);
        if (index < 0)
        {
            // if we didn't find n, 
            // binary search returns the negative complement of the first index greater
            // then n, or n + 1 if no element is greater
            index = ~index;
            if (index == perfectSquares.Length) index -= 1;
        }

        for (var i = index; i >= 0; i--)
        {
            var perfectSquare = perfectSquares[i];
            if (perfectSquare <= n)
            {
                var res = NumSquares(perfectSquares, n - perfectSquare, cache);
                if ((res + 1) < bestResult)
                {
                    bestResult = res + 1;
                }
            }
        }

        cache[n] = bestResult;
        return bestResult;
    }
}