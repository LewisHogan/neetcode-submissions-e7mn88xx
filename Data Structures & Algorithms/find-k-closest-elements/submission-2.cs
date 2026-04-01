public class Solution {
    public List<int> FindClosestElements(int[] arr, int k, int x) {
        // Binary search for the closest element
        // then grow pointers outwards
        var index = FindClosest(arr, x);

        // Our results are going to be somewhere
        // between [index-k..index+k]

        var left = index - k;
        var right = index + k;

        // We need to shrink the window until we have k elements
        while ((right - left + 1) > k)
        {
            var lDist = left >= 0 ? Math.Abs(arr[left] - x) : int.MaxValue;
            var rDist = right < arr.Length ? Math.Abs(arr[right] - x) : int.MaxValue;

            if (lDist > rDist)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return arr[left..(right+1)].ToList();
    }

    int FindClosest(int[] arr, int target)
    {
        var left = 0;
        var right = arr.Length - 1;

        var closest = -1;
        var closestDist = int.MaxValue;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            var value = arr[mid];
            var dist = Math.Abs(value - target);
            if (dist < closestDist)
            {
                closest = mid;
                closestDist = dist;
            }

            if (value < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return closest;
    }
}