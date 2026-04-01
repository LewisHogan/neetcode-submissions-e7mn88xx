public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var largestKElements = new int[k];

        // TODO: loop through nums and
        // compare every element we find to the sorted set
        // of largestKElements

        for (var i = 0; i < k; i++) {
            largestKElements[i] = int.MinValue;
        }

        for (var i = 0; i < nums.Length; i++) {
            UpdateLargestElements(largestKElements, nums[i]);
        }

        return largestKElements[0];
    }

    private void UpdateLargestElements(int[] largestElements, int n) {
        if (n < largestElements[0]) {
            return;
        }

        for (var i = 0; i < largestElements.Length; i++) {
            if (n > largestElements[i]) {
                largestElements[i] = n;
                break;
            }
        }

        Array.Sort(largestElements);
    }
}
