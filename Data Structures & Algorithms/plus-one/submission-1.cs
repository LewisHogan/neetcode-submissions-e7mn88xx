public class Solution {
    public int[] PlusOne(int[] digits) {
        for (var i = digits.Length -1; i >= 0; i--)
        {
            if (digits[i] == 9)
            {
                digits[i] = 0;
            }
            else
            {
                digits[i]++;
                return digits;
            }
        }

        return [1, ..digits];
    }
}
