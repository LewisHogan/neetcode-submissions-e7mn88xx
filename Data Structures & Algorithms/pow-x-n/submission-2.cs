public class Solution {
    public double MyPow(double x, int n) {
        var res = x;
        if (n > 0) {
            while (n-- > 1) {
                res *= x;
            }
        } else if (n < 0) {
            res = 1.0 / MyPow(x, -n);
        } else {
            return 1;
        }

        return res;
    }
}
