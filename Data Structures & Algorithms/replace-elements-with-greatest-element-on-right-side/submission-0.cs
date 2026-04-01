public class Solution {
    public int[] ReplaceElements(int[] arr) {
        var greatestSoFar = -1;
        for (var right = arr.Length - 1; right > 0; right--) {
            var next = Math.Max(arr[right], greatestSoFar);
            greatestSoFar = Math.Max(greatestSoFar, arr[right - 1]);
            arr[right - 1] = next;
        }
        arr[arr.Length - 1] = -1;

        return arr;
    }
}