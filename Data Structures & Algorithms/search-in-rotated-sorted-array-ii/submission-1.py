class Solution:
    def search(self, nums: List[int], target: int) -> bool:
        left, right = 0, len(nums) - 1
        while left <= right:
            mid = (left + (right - left) // 2)

            if nums[mid] == target:
                return True

            if nums[left] == nums[mid] == nums[right]:
                left += 1
                right -= 1
                continue
            
            if nums[left] <= nums[mid]:
                # left section of the array must be sorted
                if nums[left] <= target < nums[mid]:
                    right = mid - 1
                else:
                    left = mid + 1
            else:
                # right section must be sorted
                if nums[right] >= target > nums[mid]:
                    left = mid + 1
                else:
                    right = mid - 1


        return False