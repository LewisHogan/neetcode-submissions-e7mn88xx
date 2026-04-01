public class Solution {
    public int GetSum(int a, int b) {
        var sum = a ^ b;
        var carry = (a & b) << 1;
        while (carry != 0)
        {
            a = sum;
            b = carry;

            sum = a ^ b;
            carry = (a & b) << 1;
        }

        return sum;
    }
}
