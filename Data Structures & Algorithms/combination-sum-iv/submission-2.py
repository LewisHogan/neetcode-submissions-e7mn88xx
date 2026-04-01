from functools import cache

class Solution:
    def combinationSum4(self, nums: List[int], target: int) -> int:
        nums.sort()
        count = 0

        if target == 0:
            return 1
        
        @cache
        def search(total=target):
            count = 0
            for n in nums:
                if n == total:
                    count += 1
                elif n > total:
                    return count
                
                count += search(total - n)
            return count

                
        
        return search(target)
