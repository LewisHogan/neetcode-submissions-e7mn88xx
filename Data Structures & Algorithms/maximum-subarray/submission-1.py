class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        max_total, total = nums[0], 0
        for n in nums:
            total += n
            max_total = max(max_total, total)
            if total < 0:
                total = 0

        return max_total