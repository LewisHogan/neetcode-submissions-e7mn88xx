class Solution:
    def minSubArrayLen(self, target: int, nums: List[int]) -> int:
        sum = 0
        left = 0
        window = len(nums) + 1
        for right, num in enumerate(nums):
            sum += num
            while sum >= target:
                window = min(window, right - left + 1)
                sum -= nums[left]
                left += 1

        return 0 if window == len(nums) + 1 else window