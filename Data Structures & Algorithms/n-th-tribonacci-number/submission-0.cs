public class Solution {
    public int Tribonacci(int n) {
        var cache = new int[Math.Max(3, n+1)];
        Array.Fill(cache, -1);
        cache[0] = 0;
        cache[1] = 1;
        cache[2] = 1;

        int Calc(int i)
        {
            if (cache[i] != -1) return cache[i];
            cache[i] = Calc(i-1) + Calc(i - 2) + Calc(i - 3);
            return cache[i];
        }

        return Calc(n);
    }
}