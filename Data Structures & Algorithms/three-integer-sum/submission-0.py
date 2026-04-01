class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        nums.sort()
        res = []

        for i, n in enumerate(nums):
            l, r = i + 1, len(nums) - 1

            if n > 0: # Since n is our smallest number, if it's bigger then 0 no combinations will be valid
                break

            if i > 0 and nums[i-1] == n: # If we have any duplicate numbers, this will skip them
                continue

            while l < r:
                total = n + nums[l] + nums[r]
                if total > 0:
                    r -= 1
                elif total < 0:
                    l += 1
                else:
                    res.append([n, nums[l], nums[r]])
                    l += 1
                    r -= 1
                    while nums[l] == nums[l - 1] and l < r: # skip past any identical numbers
                        l += 1
        return res