public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // median value will be at (nums1.Count + nums2.Count / 2)
        // if it was a single sorted array
        // we could combine the arrays in o(n+m) time, but we can probably do better
        // pointers track min and max for each array and we search within each one
        // monitoring the count
        var (l1, l2) = (0, 0);
        var halfOfTotal = (nums1.Length + nums2.Length) / 2;

        var prev = 0;
        var current = 0;
        // Go through half the total number of elements, the last result read
        // should be the median if the total is odd, otherwise it needs to be
        // (prev + current) / 2
        for (var i = 0; i <= halfOfTotal; i++) {
            prev = current;
            if (l1 < nums1.Length && l2 < nums2.Length) {    
                if (nums1[l1] <= nums2[l2]) {
                    current = nums1[l1++];
                } else {
                    current = nums2[l2++];
                }
            } else if (l1 < nums1.Length) {
                current = nums1[l1++];
            } else {
                current = nums2[l2++];
            }
        }

        if ((nums1.Length + nums2.Length) % 2 == 1) {
            return current;
        }

        return (current + prev) / 2.0;
    }
}
