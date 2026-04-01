public class Solution {
    public int[] SortArray(int[] nums) {
        var buffer = new int[nums.Length];

        void MergeSort(Span<int> span, Span<int> buffer)
        {
            if (span.Length == 1) return;

            var mid = span.Length / 2;

            var left = span.Slice(0, mid);
            var leftBuffer = buffer.Slice(0, mid);

            var right = span.Slice(mid);
            var rightBuffer = buffer.Slice(mid);
            
            MergeSort(left, leftBuffer);
            MergeSort(right, rightBuffer);
            
            Merge(left, right, buffer);

            buffer.CopyTo(span);
        }

        void Merge(Span<int> left, Span<int> right, Span<int> buffer)
        {
            var i = 0;
            var j = 0;
            var k = 0;
            while (i < left.Length && j < right.Length)
            {
                buffer[k++] = left[i] <= right[j] ? left[i++] : right[j++];
            }

            if (i < left.Length) left.Slice(i).CopyTo(buffer.Slice(k));
            if (j < right.Length) right.Slice(j).CopyTo(buffer.Slice(k));
        }

        MergeSort(nums, buffer);
        return nums;
    }
}