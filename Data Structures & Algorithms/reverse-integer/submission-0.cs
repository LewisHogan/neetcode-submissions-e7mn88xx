public class Solution {
    public int Reverse(int x) {
        var res = 0;

        while (x != 0)
        {
            var digit = x % 10;
            x /= 10;

            if (res > (int.MaxValue / 10) - digit) return 0;
            if (res < (int.MinValue / 10) + digit) return 0;

            res *= 10;
            res += digit;
        }

        return res;
    }
}
