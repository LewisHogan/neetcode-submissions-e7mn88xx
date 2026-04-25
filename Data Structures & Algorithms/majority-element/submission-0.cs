public class Solution {
    public int MajorityElement(int[] nums) {
        var candidate = 0;
        var count = 0;

        foreach (var n in nums) {
            if (count == 0) {
                candidate = n;
            }
            
            count += (n == candidate) ? 1 : -1;
        }

        return candidate;

    }
}