public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        var left = 0;
        var right = numbers.Length - 1;

        while (numbers[left] + numbers[right] != target) {
            if (numbers[left] + numbers[right] < target) {
                left++;
            } else {
                right--;
            }
        }

        return new int[] { left + 1, right + 1 };
    }
}
