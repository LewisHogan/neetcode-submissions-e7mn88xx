public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var i = 1;
        while (m > 0 && n > 0)
        {
            if (nums1[m-1] >= nums2[n-1])
            {
                nums1[^i++] = nums1[m-1];
                m--;
            }
            else
            {
                nums1[^i++] = nums2[n-1];
                n--;
            }
        }

        while (m > 0)
        {
            nums1[^i++] = nums1[m-1];
            m--;
        }

        while (n > 0)
        {
            nums1[^i++] = nums2[n-1];
            n--;
        }
    }
}