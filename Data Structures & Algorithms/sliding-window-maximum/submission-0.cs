public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var steps = nums.Length - k + 1;
        var res = new int[steps];

        var maxHeap = new PriorityQueue<(int Index, int Value), int>();
        for (var i = 0; i < k; i++) {
            maxHeap.Enqueue((i, nums[i]), -nums[i]);
        }

        for (var i = 0; i < steps; i++) {
            while (maxHeap.Peek().Index < i) {
                maxHeap.Dequeue();
            }

            res[i] = maxHeap.Peek().Value;
            if (i + k < nums.Length) {
                maxHeap.Enqueue((i + k, nums[i + k]), -nums[i + k]);
            }
        }

        return res;
    }
}