class Solution:
    def containsNearbyDuplicate(self, nums: List[int], k: int) -> bool:
        window_nums = set()

        if k == 0:
            return False

        for i, num in enumerate(nums):
            if num in window_nums:
                return True

            if i >= k:
                window_nums.remove(nums[i - k])
            window_nums.add(num)
        
        return False