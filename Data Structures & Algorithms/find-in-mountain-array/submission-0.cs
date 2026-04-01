/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

class Solution {
    public int FindInMountainArray(int target, MountainArray mountainArray) {
        if (mountainArray.Length() < 3) return -1;
        
        var cache = new Dictionary<int, int>();
        var peak = FindPeak(mountainArray, cache);

        var lower = BinarySearch(mountainArray, target, cache, true, peak);
        if (lower != -1) return lower;

        return BinarySearch(mountainArray, target, cache, false, peak);
    }

    int BinarySearch(MountainArray mountainArr, int target, Dictionary<int, int> cache, bool ascending, int peakIndex)
    {
        var left = ascending ? 0 : peakIndex;
        var right = ascending ? peakIndex : mountainArr.Length() - 1;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (!cache.ContainsKey(mid)) cache[mid] = mountainArr.Get(mid);
            var value = cache[mid];

            if ((ascending && value < target) || (!ascending && value > target))
            {
                left = mid + 1;
            }
            else if ((ascending && value > target) || (!ascending && value < target))
            {
                right = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }

    int FindPeak(MountainArray mountainArr, Dictionary<int, int> cache)
    {
        var left = 1;
        var right = mountainArr.Length() - 2;

        while (left <= right)
        {
            var mid = left + (right - left) / 2;

            if (!cache.ContainsKey(mid)) cache[mid] = mountainArr.Get(mid);
            if (!cache.ContainsKey(mid-1)) cache[mid-1] = mountainArr.Get(mid-1);
            if (!cache.ContainsKey(mid+1)) cache[mid+1] = mountainArr.Get(mid+1);
            
            var val = cache[mid];
            var leftVal = cache[mid-1];
            var rightVal = cache[mid+1];

            if (leftVal > val)
            {
                right = mid - 1;
            }
            else if (rightVal > val)
            {
                left = mid + 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }
}