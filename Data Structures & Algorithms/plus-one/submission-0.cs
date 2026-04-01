public class Solution {
    public int[] PlusOne(int[] digits) {
        var carry = 0;
        for (var i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] == 9)
            {
                carry = 1;
                digits[i] = 0;
            }
            else
            {
                carry = 0;
                digits[i]++;
                break;
            }
        }

        if (carry == 1)
        {
            return [1, ..digits];
        }

        return digits;
    }
}
